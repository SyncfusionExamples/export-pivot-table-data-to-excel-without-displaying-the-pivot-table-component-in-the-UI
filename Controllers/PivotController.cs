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
        public async Task<object> Post([FromBody] object args)
        {
            // Bind pivot report here
            string parameter = "{\"Action\":\"onRefresh\",\"DataSourceSettings\":{\"allowLabelFilter\":false,\"allowMemberFilter\":true,\"allowValueFilter\":false,\"alwaysShowValueHeader\":false,\"authentication\":{\"password\":\"\",\"userName\":\"\"},\"calculatedFieldSettings\":[],\"catalog\":\"\"," +
             "\"columns\":[{\"allowDragAndDrop\":true,\"isCalculatedField\":false,\"isNamedSet\":false,\"name\":\"Country\",\"showEditIcon\":true,\"showFilterIcon\":true,\"showNoDataItems\":false,\"showRemoveIcon\":true,\"showSortIcon\":true,\"showSubTotals\":true,\"showValueTypeIcon\":true,\"expandAll\":false,\"type\":\"Sum\"}]," +
             "\"conditionalFormatSettings\":[],\"cube\":\"\",\"enableServerSideAggregation\":true,\"drilledMembers\":[],\"emptyCellsTextContent\":\"\",\"enableSorting\":true,\"expandAll\":false,\"fieldMapping\":[],\"filterSettings\":[],\"filters\":[],\"formatSettings\":[],\"groupSettings\":[],\"localeIdentifier\":1033,\"providerType\":\"Relational\",\"grandTotalsPosition\":\"Bottom\",\"subTotalsPosition\":\"Auto\",\"roles\":\"\"," +
             "\"rows\":[{\"allowDragAndDrop\":true,\"isCalculatedField\":false,\"isNamedSet\":false,\"name\":\"ProductID\",\"showEditIcon\":true,\"showFilterIcon\":true,\"showNoDataItems\":false,\"showRemoveIcon\":true,\"showSortIcon\":true,\"showSubTotals\":true,\"showValueTypeIcon\":true,\"expandAll\":false,\"type\":\"Sum\"}]," +
             "\"showAggregationOnValueField\":true,\"showColumnGrandTotals\":true,\"showColumnSubTotals\":true,\"showGrandTotals\":true,\"showHeaderWhenEmpty\":true,\"showRowGrandTotals\":true,\"showRowSubTotals\":true,\"showSubTotals\":true,\"sortSettings\":[],\"type\":\"JSON\",\"url\":\"https://localhost:44350/api/pivot/post\",\"valueAxis\":\"column\",\"valueSortSettings\":{\"headerDelimiter\":\".\",\"headerText\":\"\",\"measure\":\"\",\"sortOrder\":\"None\"}," +
             "\"values\":[{\"allowDragAndDrop\":true,\"caption\":\"Price\",\"isCalculatedField\":false,\"isNamedSet\":false,\"name\":\"Price\",\"showEditIcon\":true,\"showFilterIcon\":true,\"showNoDataItems\":false,\"showRemoveIcon\":true,\"showSortIcon\":true,\"showSubTotals\":true,\"showValueTypeIcon\":true,\"expandAll\":false,\"type\":\"Sum\"}," +
             "{\"allowDragAndDrop\":true,\"caption\":\"Units Sold\",\"isCalculatedField\":false,\"isNamedSet\":false,\"name\":\"Sold\",\"showEditIcon\":true,\"showFilterIcon\":true,\"showNoDataItems\":false,\"showRemoveIcon\":true,\"showSortIcon\":true,\"showSubTotals\":true,\"showValueTypeIcon\":true,\"expandAll\":false,\"type\":\"Sum\"}]}," +
             "\"InternalProperties\":{\"EnablePaging\":false,\"EnableValueSorting\":true,\"EnableOptimizedRendering\":false,\"EnableVirtualization\":true,\"EnableDrillThrough\":false,\"locale\":\"{\\\"Null\\\":\\\"null\\\",\\\"Years\\\":\\\"Years\\\",\\\"Quarters\\\":\\\"Quarters\\\",\\\"Months\\\":\\\"Months\\\",\\\"Days\\\":\\\"Days\\\",\\\"Hours\\\":\\\"Hours\\\",\\\"Minutes\\\":\\\"Minutes\\\",\\\"Seconds\\\":\\\"Seconds\\\",\\\"QuarterYear\\\":\\\"Quarter Year\\\",\\\"Of\\\":\\\"of\\\",\\\"Qtr\\\":\\\"Qtr\\\",\\\"Undefined\\\":\\\"undefined\\\",\\\"GroupOutOfRange\\\":\\\"Out of Range\\\",\\\"Group\\\":\\\"Group\\\",\\\"GrandTotal\\\":\\\"Grand Total\\\",\\\"Total\\\":\\\"Total\\\"}\"," +
             "\"PageSettings\":{\"currentColumnPage\":1,\"columnPageSize\":5,\"currentRowPage\":1,\"rowPageSize\":13},\"IsWebAssembly\":false,\"AllowDataCompression\":false}," +
             "\"Hash\":\"a8016852-2c03-4f01-b7a8-cdbcfd820df1\",\"IsGroupingUpdated\":false,\"ExportAllPages\":true}";

            FetchData param = JsonConvert.DeserializeObject<FetchData>(parameter);

            PivotEngine.Data = new DataSource.PivotViewData().GetVirtualData();
            EngineProperties engine = engine = await PivotEngine.GetEngine(param); // Here we invoke the engine
            
            param.Action = "onExcelExport"; // Set the action name manully for excel exporting
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;
            IWorkbook book = application.Workbooks.Create(1);
            IWorksheet workSheet = book.Worksheets[0];

            if (param.Action == "onExcelExport" || param.Action == "onCsvExport")
            {
                if (param.InternalProperties.EnableVirtualization && param.ExportAllPages)
                {
                    engine = await PivotEngine.PerformAction(engine, param);
                }
                if (param.Action == "onExcelExport")
                {
                    excelExport.UpdateWorkSheet(string.Empty, engine, workSheet); // Here we update the work sheet
                }
                else
                {
                    excelExport.UpdateWorkSheet("CSV", engine, workSheet);
                }
            }
            MemoryStream memoryStream = new MemoryStream(); // Saved the book as memory stream
            book.SaveAs(memoryStream);

            MemoryStream copyOfStreamDoc1 = new MemoryStream(memoryStream.ToArray());

            //For creating the exporting location with file name, for this need to specify the physical exact path of the file
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
