using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Syncfusion.Pivot.Engine;
using Syncfusion.XlsIO;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;


namespace PivotController.Controllers
{
    [Route("api/[controller]")]
    public class PivotController : Controller
    {
        private readonly IMemoryCache _cache;
        private IWebHostEnvironment _hostingEnvironment;
        private bool isRendered;
        private PivotEngine<DataSource.PivotViewData> PivotEngine = new PivotEngine<DataSource.PivotViewData>();
        private ExcelExport excelExport = new ExcelExport();

        public PivotController(IMemoryCache cache, IWebHostEnvironment environment)
        {
            _cache = cache;
            _hostingEnvironment = environment;
        }

        [Route("/api/pivot/post")]
        [HttpPost]
        public async Task<object> Post()
        {
            // Step 1: Set up the settings for the Pivot Table report
            FetchData param = new FetchData
            {
                Action = "onRefresh",
                Hash = "a8016852-2c03-4f01-b7a8-cdbcfd820df1",
                ExportAllPages = true,
                DataSourceSettings = new DataOptions
                {
                    EnableServerSideAggregation = true,
                    Rows = new List<FieldOptions>
                {
                    new FieldOptions
                    {
                        Name = "ProductID",
                    }
                },
                    Columns = new List<FieldOptions>
                {
                    new FieldOptions
                    {
                        Name = "Country",
                    }
                },
                    Values = new List<FieldOptions>
                {
                    new FieldOptions
                    {
                        Name = "Price",
                        Caption = "Price",
                    },
                    new FieldOptions
                    {
                        Name = "Sold",
                        Caption = "Units Sold",
                    }
                }
                },
                InternalProperties = new CustomProperties
                {
                    Locale = "{\"Null\":\"null\",\"Years\":\"Years\",\"Quarters\":\"Quarters\",\"Months\":\"Months\",\"Days\":\"Days\",\"Hours\":\"Hours\",\"Minutes\":\"Minutes\",\"Seconds\":\"Seconds\",\"QuarterYear\":\"Quarter Year\",\"Of\":\"of\",\"Qtr\":\"Qtr\",\"Undefined\":\"undefined\",\"GroupOutOfRange\":\"Out of Range\",\"Group\":\"Group\",\"GrandTotal\":\"Grand Total\",\"Total\":\"Total\"}"
                },
            };
            PivotEngine.Data = new DataSource.PivotViewData().GetVirtualData();
            // Pass the configuration to the pivot engine to generate the report
            EngineProperties engine = engine = await PivotEngine.GetEngine(param);
            // Step 2: Set the action name manually for Excel exporting.
            param.Action = "onExcelExport";
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;
            // Step 3: Initialize new workbook and worksheet.
            IWorkbook book = application.Workbooks.Create(1);
            IWorksheet workSheet = book.Worksheets[0];
            // Perform Excel exporting if the action matches
            if (param.Action == "onExcelExport")
            {
                // Handle specific situations like virtualization during export
                if (param.InternalProperties.EnableVirtualization && param.ExportAllPages)
                {
                    engine = await PivotEngine.PerformAction(engine, param);
                }
                // Update work sheet with engine data
                excelExport.UpdateWorkSheet(string.Empty, engine, workSheet); // Here we update the work sheet
            }
            // Step 4: Save workbook to memory stream
            MemoryStream memoryStream = new MemoryStream(); // Saved the book as memory stream
            book.SaveAs(memoryStream);
            // Prepare to save the memory stream to a file
            MemoryStream copyOfStreamDoc1 = new MemoryStream(memoryStream.ToArray());
            // Step 5: Specify the file path and write the memory stream contents to a file
            string filePaths = @"D:\Export\Sample.xlsx";

            // Create a FileStream to write the memoryStream contents to a file
            using (FileStream fileStream = new FileStream(filePaths, FileMode.Create))
            {
                // Copy the MemoryStream data to the FileStream
                copyOfStreamDoc1.CopyTo(fileStream);
            }

            //Reset the memory stream position.
            memoryStream.Position = 0;
            Attachment file = new Attachment(memoryStream, "PivotAttachment.xlsx", "application/xlsx");
            SendEMail("your email", "your email", "Pivot Excel document", "Create Excel MailBody", file);
            return null;

        }

        private static void SendEMail(string from, string recipients, string subject, string body, Attachment attachment)
        {
            //Creates the email message
            MailMessage emailMessage = new MailMessage(from, recipients);
            //Adds the subject for email
            emailMessage.Subject = subject;
            //Sets the HTML string as email body
            emailMessage.IsBodyHtml = false;
            emailMessage.Body = body;
            //Add the file attachment to this e-mail message.
            emailMessage.Attachments.Add(attachment);
            //Sends the email with prepared message
            using (SmtpClient client = new SmtpClient())
            {
                //Update your SMTP Server address here"
                client.Host = "smtp.gmail.com";
                client.UseDefaultCredentials = false;
                //Update your email credentials here
                // Need to pass the app password here
                client.Credentials = new System.Net.NetworkCredential(from, "your-app-password");
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(emailMessage);
            }
        }

        private async Task<EngineProperties> GetEngine(FetchData param)
        {
            isRendered = false;
#pragma warning disable CS8603 // Possible null reference return.
            return await _cache.GetOrCreateAsync("engine" + param.Hash,
                async (cacheEntry) =>
                {
                    isRendered = true;
                    cacheEntry.SetSize(1);
                    cacheEntry.AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(60);
                    PivotEngine.Data = await GetData(param);
                    return await PivotEngine.GetEngine(param);
                });
#pragma warning restore CS8603 // Possible null reference return.
        }

        private async Task<object> GetData(FetchData param)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _cache.GetOrCreateAsync("dataSource" + param.Hash,
                async (cacheEntry) =>
                {
                    cacheEntry.SetSize(1);
                    cacheEntry.AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(60);

                    // Here, you can refer different kinds of data sources. We've bound a collection in this illustration.
                    // return new PivotViewData().GetVirtualData();
                    return new DataSource.PivotViewData().GetVirtualData();

                    // EXAMPLE:
                    // Other data sources, such as DataTable, CSV, JSON, etc., can be bound as shown below.
                    // return new DataSource.BusinessObjectsDataView().GetDataTable();
                    // return new DataSource.PivotJSONData().ReadJSONData(_hostingEnvironment.ContentRootPath + "\\DataSource\\sales-analysis.json");
                    // return new DataSource.PivotCSVData().ReadCSVData(_hostingEnvironment.ContentRootPath + "\\DataSource\\sales.csv");
                    // return new DataSource.PivotJSONData().ReadJSONData("http://cdn.syncfusion.com/data/sales-analysis.json");
                    // return new DataSource.PivotCSVData().ReadCSVData("http://cdn.syncfusion.com/data/sales-analysis.csv");
                });
#pragma warning restore CS8603 // Possible null reference return.
        }

        private async Task<object> GetMembers(FetchData param)
        {
            EngineProperties engine = await GetEngine(param);
            Dictionary<string, object> returnValue = new Dictionary<string, object>();
            returnValue["memberName"] = param.MemberName;
            if (engine.FieldList[param.MemberName].IsMembersFilled)
            {
                returnValue["members"] = JsonConvert.SerializeObject(engine.FieldList[param.MemberName].Members);
            }
            else
            {
                await PivotEngine.PerformAction(engine, param);
                returnValue["members"] = JsonConvert.SerializeObject(engine.FieldList[param.MemberName].Members);
            }
            return returnValue;
        }

        private async Task<object> GetRawData(FetchData param)
        {
            EngineProperties engine = await GetEngine(param);
            return PivotEngine.GetRawData(param, engine);
        }

        private async Task<object> GetPivotValues(FetchData param)
        {
            EngineProperties engine = await GetEngine(param);
            if (param.IsGroupingUpdated)
            {
                engine.Data = await GetData(param);
            }
            if (!isRendered)
            {
                engine = await PivotEngine.PerformAction(engine, param);
            }
            _cache.Remove("engine" + param.Hash);
            _cache.Set("engine" + param.Hash, engine, new MemoryCacheEntryOptions().SetSize(1).SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddMinutes(60)));
            return PivotEngine.GetPivotValues();
        }
    }
}
