using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;

namespace PivotController.Controllers
{
    public class DataSource
    {

        public class ProductDetails
        {
            public int Sold { get; set; }
            public double Amount { get; set; }
            public string Country { get; set; }
            public string Products { get; set; }
            public string Year { get; set; }
            public string Quarter { get; set; }

            public List<ProductDetails> GetProductData()
            {
                List<ProductDetails> productData = new List<ProductDetails>();
                productData.Add(new ProductDetails { Sold = 31, Amount = 52824, Country = "France", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 51, Amount = 86904, Country = "France", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 90, Amount = 153360, Country = "France", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 25, Amount = 42600, Country = "France", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 27, Amount = 46008, Country = "France", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 49, Amount = 83496, Country = "France", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 95, Amount = 161880, Country = "France", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 67, Amount = 114168, Country = "France", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 75, Amount = 127800, Country = "France", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 67, Amount = 114168, Country = "France", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 69, Amount = 117576, Country = "France", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 90, Amount = 153360, Country = "France", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 16, Amount = 27264, Country = "France", Products = "Mountain Bikes", Year = "FY 2018", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 83, Amount = 124422, Country = "France", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 57, Amount = 85448, Country = "France", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 20, Amount = 29985, Country = "France", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 67, Amount = 70008, Country = "France", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 89, Amount = 60496, Country = "France", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 75, Amount = 801880, Country = "France", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 57, Amount = 204168, Country = "France", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 75, Amount = 737800, Country = "France", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 87, Amount = 884168, Country = "France", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 39, Amount = 729576, Country = "France", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 90, Amount = 38860, Country = "France", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 93, Amount = 139412, Country = "France", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 51, Amount = 92824, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 61, Amount = 76904, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 70, Amount = 43360, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 85, Amount = 62600, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 97, Amount = 86008, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 69, Amount = 93496, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 45, Amount = 301880, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 77, Amount = 404168, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 15, Amount = 137800, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 37, Amount = 184168, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 49, Amount = 89576, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 40, Amount = 33360, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 96, Amount = 77264, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2018", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 23, Amount = 24422, Country = "Germany", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 67, Amount = 75448, Country = "Germany", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 70, Amount = 52345, Country = "Germany", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 13, Amount = 135612, Country = "Germany", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 57, Amount = 90008, Country = "Germany", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 29, Amount = 90496, Country = "Germany", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 45, Amount = 301880, Country = "Germany", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 77, Amount = 404168, Country = "Germany", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 15, Amount = 137800, Country = "Germany", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 37, Amount = 184168, Country = "Germany", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 99, Amount = 829576, Country = "Germany", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 80, Amount = 38360, Country = "Germany", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 91, Amount = 67824, Country = "United States", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 81, Amount = 99904, Country = "United States", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 70, Amount = 49360, Country = "United States", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 65, Amount = 69600, Country = "United States", Products = "Mountain Bikes", Year = "FY 2015", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 57, Amount = 90008, Country = "United States", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 29, Amount = 90496, Country = "United States", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 85, Amount = 391880, Country = "United States", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 97, Amount = 904168, Country = "United States", Products = "Mountain Bikes", Year = "FY 2016", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 85, Amount = 237800, Country = "United States", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 77, Amount = 384168, Country = "United States", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 99, Amount = 829576, Country = "United States", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 80, Amount = 38360, Country = "United States", Products = "Mountain Bikes", Year = "FY 2017", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 76, Amount = 97264, Country = "United States", Products = "Mountain Bikes", Year = "FY 2018", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 53, Amount = 94422, Country = "United States", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 90, Amount = 45448, Country = "United States", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 29, Amount = 92345, Country = "United States", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 67, Amount = 235612, Country = "United States", Products = "Road Bikes", Year = "FY 2015", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 97, Amount = 90008, Country = "United States", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 79, Amount = 90496, Country = "United States", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 95, Amount = 501880, Country = "United States", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 97, Amount = 104168, Country = "United States", Products = "Road Bikes", Year = "FY 2016", Quarter = "Q4" });
                productData.Add(new ProductDetails { Sold = 95, Amount = 837800, Country = "United States", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q1" });
                productData.Add(new ProductDetails { Sold = 87, Amount = 684168, Country = "United States", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q2" });
                productData.Add(new ProductDetails { Sold = 109, Amount = 29576, Country = "United States", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q3" });
                productData.Add(new ProductDetails { Sold = 99, Amount = 345860, Country = "United States", Products = "Road Bikes", Year = "FY 2017", Quarter = "Q4" });
                return productData;
            }
        }

        public class GroupData
        {
            public int Id { get; set; }
            public string TimeLine { get; set; }
            public string Sector { get; set; }
            public string EnerType { get; set; }
            public string EneSource { get; set; }
            public int PowUnits { get; set; }
            public int ProCost { get; set; }
            public string Year { get; set; }
            public string Quarter { get; set; }
            public string HalfYear { get; set; }
            public List<GroupData> GetGroupData()
            {
                List<GroupData> groupData = new List<GroupData>();
                groupData.Add(new GroupData
                {
                    Id = 1001,
                    TimeLine = "1/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 46,
                    ProCost = 43
                });
                groupData.Add(new GroupData
                {
                    Id = 1002,
                    TimeLine = "2/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 30,
                    ProCost = 29
                });
                groupData.Add(new GroupData
                {
                    Id = 1003,
                    TimeLine = "3/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 125,
                    ProCost = 96
                });
                groupData.Add(new GroupData
                {
                    Id = 1004,
                    TimeLine = "4/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 215,
                    ProCost = 123
                });
                groupData.Add(new GroupData
                {
                    Id = 1005,
                    TimeLine = "5/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 263,
                    ProCost = 125
                });
                groupData.Add(new GroupData
                {
                    Id = 1006,
                    TimeLine = "6/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 61,
                    ProCost = 50
                });
                groupData.Add(new GroupData
                {
                    Id = 1007,
                    TimeLine = "7/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 20,
                    ProCost = 31
                });
                groupData.Add(new GroupData
                {
                    Id = 1008,
                    TimeLine = "8/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 133,
                    ProCost = 110
                });
                groupData.Add(new GroupData
                {
                    Id = 1009,
                    TimeLine = "9/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 33,
                    ProCost = 65
                });
                groupData.Add(new GroupData
                {
                    Id = 1010,
                    TimeLine = "10/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 37,
                    ProCost = 20
                });
                groupData.Add(new GroupData
                {
                    Id = 1011,
                    TimeLine = "11/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 109,
                    ProCost = 96
                });
                groupData.Add(new GroupData
                {
                    Id = 1012,
                    TimeLine = "12/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 266,
                    ProCost = 139
                });
                groupData.Add(new GroupData
                {
                    Id = 1013,
                    TimeLine = "1/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 257,
                    ProCost = 143
                });
                groupData.Add(new GroupData
                {
                    Id = 1014,
                    TimeLine = "2/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 79,
                    ProCost = 53
                });
                groupData.Add(new GroupData
                {
                    Id = 1015,
                    TimeLine = "3/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 28,
                    ProCost = 48
                });
                groupData.Add(new GroupData
                {
                    Id = 1016,
                    TimeLine = "4/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 128,
                    ProCost = 117
                });
                groupData.Add(new GroupData
                {
                    Id = 1017,
                    TimeLine = "5/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 68,
                    ProCost = 48
                });
                groupData.Add(new GroupData
                {
                    Id = 1018,
                    TimeLine = "6/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 26,
                    ProCost = 32
                });
                groupData.Add(new GroupData
                {
                    Id = 1019,
                    TimeLine = "7/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 141,
                    ProCost = 98
                });
                groupData.Add(new GroupData
                {
                    Id = 1020,
                    TimeLine = "8/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 281,
                    ProCost = 134
                });
                groupData.Add(new GroupData
                {
                    Id = 1021,
                    TimeLine = "9/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 228,
                    ProCost = 107
                });
                groupData.Add(new GroupData
                {
                    Id = 1022,
                    TimeLine = "10/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 73,
                    ProCost = 49
                });
                groupData.Add(new GroupData
                {
                    Id = 1023,
                    TimeLine = "11/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 19,
                    ProCost = 44
                });
                groupData.Add(new GroupData
                {
                    Id = 1024,
                    TimeLine = "12/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 149,
                    ProCost = 82
                });
                groupData.Add(new GroupData
                {
                    Id = 1025,
                    TimeLine = "1/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 47,
                    ProCost = 58
                });
                groupData.Add(new GroupData
                {
                    Id = 1026,
                    TimeLine = "2/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 25,
                    ProCost = 40
                });
                groupData.Add(new GroupData
                {
                    Id = 1027,
                    TimeLine = "3/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 127,
                    ProCost = 93
                });
                groupData.Add(new GroupData
                {
                    Id = 1028,
                    TimeLine = "4/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 216,
                    ProCost = 124
                });
                groupData.Add(new GroupData
                {
                    Id = 1029,
                    TimeLine = "5/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 267,
                    ProCost = 100
                });
                groupData.Add(new GroupData
                {
                    Id = 1030,
                    TimeLine = "6/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 52,
                    ProCost = 65
                });
                groupData.Add(new GroupData
                {
                    Id = 1031,
                    TimeLine = "7/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 39,
                    ProCost = 33
                });
                groupData.Add(new GroupData
                {
                    Id = 1032,
                    TimeLine = "8/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 142,
                    ProCost = 97
                });
                groupData.Add(new GroupData
                {
                    Id = 1033,
                    TimeLine = "9/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 53,
                    ProCost = 49
                });
                groupData.Add(new GroupData
                {
                    Id = 1034,
                    TimeLine = "10/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 23,
                    ProCost = 44
                });
                groupData.Add(new GroupData
                {
                    Id = 1035,
                    TimeLine = "11/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 113,
                    ProCost = 106
                });
                groupData.Add(new GroupData
                {
                    Id = 1036,
                    TimeLine = "12/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 270,
                    ProCost = 101
                });
                groupData.Add(new GroupData
                {
                    Id = 1037,
                    TimeLine = "1/1/2018",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 284,
                    ProCost = 105
                });
                groupData.Add(new GroupData
                {
                    Id = 1038,
                    TimeLine = "2/1/2018",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 62,
                    ProCost = 43
                });
                groupData.Add(new GroupData
                {
                    Id = 1039,
                    TimeLine = "1/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 32,
                    ProCost = 26
                });
                groupData.Add(new GroupData
                {
                    Id = 1040,
                    TimeLine = "2/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 133,
                    ProCost = 83
                });
                groupData.Add(new GroupData
                {
                    Id = 1041,
                    TimeLine = "3/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 51,
                    ProCost = 65
                });
                groupData.Add(new GroupData
                {
                    Id = 1042,
                    TimeLine = "4/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 13,
                    ProCost = 25
                });
                groupData.Add(new GroupData
                {
                    Id = 1043,
                    TimeLine = "5/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 139,
                    ProCost = 101
                });
                groupData.Add(new GroupData
                {
                    Id = 1044,
                    TimeLine = "6/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 297,
                    ProCost = 130
                });
                groupData.Add(new GroupData
                {
                    Id = 1045,
                    TimeLine = "7/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 236,
                    ProCost = 119
                });
                groupData.Add(new GroupData
                {
                    Id = 1046,
                    TimeLine = "8/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 57,
                    ProCost = 66
                });
                groupData.Add(new GroupData
                {
                    Id = 1047,
                    TimeLine = "9/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 16,
                    ProCost = 27
                });
                groupData.Add(new GroupData
                {
                    Id = 1048,
                    TimeLine = "10/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 110,
                    ProCost = 93
                });
                groupData.Add(new GroupData
                {
                    Id = 1049,
                    TimeLine = "11/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 55,
                    ProCost = 49
                });
                groupData.Add(new GroupData
                {
                    Id = 1050,
                    TimeLine = "12/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 32,
                    ProCost = 39
                });
                groupData.Add(new GroupData
                {
                    Id = 1051,
                    TimeLine = "1/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 128,
                    ProCost = 120
                });
                groupData.Add(new GroupData
                {
                    Id = 1052,
                    TimeLine = "2/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 290,
                    ProCost = 128
                });
                groupData.Add(new GroupData
                {
                    Id = 1053,
                    TimeLine = "3/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 201,
                    ProCost = 105
                });
                groupData.Add(new GroupData
                {
                    Id = 1054,
                    TimeLine = "4/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 55,
                    ProCost = 46
                });
                groupData.Add(new GroupData
                {
                    Id = 1055,
                    TimeLine = "5/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 20,
                    ProCost = 37
                });
                groupData.Add(new GroupData
                {
                    Id = 1056,
                    TimeLine = "6/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 122,
                    ProCost = 118
                });
                groupData.Add(new GroupData
                {
                    Id = 1057,
                    TimeLine = "7/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 69,
                    ProCost = 54
                });
                groupData.Add(new GroupData
                {
                    Id = 1058,
                    TimeLine = "8/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 21,
                    ProCost = 41
                });
                groupData.Add(new GroupData
                {
                    Id = 1059,
                    TimeLine = "9/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 140,
                    ProCost = 83
                });
                groupData.Add(new GroupData
                {
                    Id = 1060,
                    TimeLine = "10/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 239,
                    ProCost = 121
                });
                groupData.Add(new GroupData
                {
                    Id = 1061,
                    TimeLine = "11/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 283,
                    ProCost = 127
                });
                groupData.Add(new GroupData
                {
                    Id = 1062,
                    TimeLine = "12/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 80,
                    ProCost = 40
                });
                groupData.Add(new GroupData
                {
                    Id = 1063,
                    TimeLine = "1/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 33,
                    ProCost = 40
                });
                groupData.Add(new GroupData
                {
                    Id = 1064,
                    TimeLine = "2/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 120,
                    ProCost = 81
                });
                groupData.Add(new GroupData
                {
                    Id = 1065,
                    TimeLine = "3/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 41,
                    ProCost = 69
                });
                groupData.Add(new GroupData
                {
                    Id = 1066,
                    TimeLine = "4/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 14,
                    ProCost = 21
                });
                groupData.Add(new GroupData
                {
                    Id = 1067,
                    TimeLine = "5/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 144,
                    ProCost = 93
                });
                groupData.Add(new GroupData
                {
                    Id = 1068,
                    TimeLine = "6/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 294,
                    ProCost = 146
                });
                groupData.Add(new GroupData
                {
                    Id = 1069,
                    TimeLine = "7/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 217,
                    ProCost = 103
                });
                groupData.Add(new GroupData
                {
                    Id = 1070,
                    TimeLine = "8/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 49,
                    ProCost = 44
                });
                groupData.Add(new GroupData
                {
                    Id = 1071,
                    TimeLine = "9/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 36,
                    ProCost = 21
                });
                groupData.Add(new GroupData
                {
                    Id = 1072,
                    TimeLine = "10/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 118,
                    ProCost = 115
                });
                groupData.Add(new GroupData
                {
                    Id = 1073,
                    TimeLine = "11/1/2017",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 56,
                    ProCost = 41
                });
                groupData.Add(new GroupData
                {
                    Id = 1074,
                    TimeLine = "12/1/2017",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 17,
                    ProCost = 36
                });
                groupData.Add(new GroupData
                {
                    Id = 1075,
                    TimeLine = "1/1/2018",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 140,
                    ProCost = 81
                });
                groupData.Add(new GroupData
                {
                    Id = 1076,
                    TimeLine = "2/1/2018",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 274,
                    ProCost = 109
                });
                groupData.Add(new GroupData
                {
                    Id = 1077,
                    TimeLine = "1/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 284,
                    ProCost = 145
                });
                groupData.Add(new GroupData
                {
                    Id = 1078,
                    TimeLine = "2/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 40,
                    ProCost = 49
                });
                groupData.Add(new GroupData
                {
                    Id = 1079,
                    TimeLine = "3/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 12,
                    ProCost = 28
                });
                groupData.Add(new GroupData
                {
                    Id = 1080,
                    TimeLine = "4/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 150,
                    ProCost = 115
                });
                groupData.Add(new GroupData
                {
                    Id = 1081,
                    TimeLine = "5/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 73,
                    ProCost = 64
                });
                groupData.Add(new GroupData
                {
                    Id = 1082,
                    TimeLine = "6/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 23,
                    ProCost = 47
                });
                groupData.Add(new GroupData
                {
                    Id = 1083,
                    TimeLine = "7/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 102,
                    ProCost = 112
                });
                groupData.Add(new GroupData
                {
                    Id = 1084,
                    TimeLine = "8/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 252,
                    ProCost = 112
                });
                groupData.Add(new GroupData
                {
                    Id = 1085,
                    TimeLine = "9/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 222,
                    ProCost = 131
                });
                groupData.Add(new GroupData
                {
                    Id = 1086,
                    TimeLine = "10/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 52,
                    ProCost = 46
                });
                groupData.Add(new GroupData
                {
                    Id = 1087,
                    TimeLine = "11/1/2015",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 35,
                    ProCost = 30
                });
                groupData.Add(new GroupData
                {
                    Id = 1088,
                    TimeLine = "12/1/2015",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 104,
                    ProCost = 101
                });
                groupData.Add(new GroupData
                {
                    Id = 1089,
                    TimeLine = "1/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 46,
                    ProCost = 40
                });
                groupData.Add(new GroupData
                {
                    Id = 1090,
                    TimeLine = "2/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 19,
                    ProCost = 31
                });
                groupData.Add(new GroupData
                {
                    Id = 1091,
                    TimeLine = "3/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 118,
                    ProCost = 89
                });
                groupData.Add(new GroupData
                {
                    Id = 1092,
                    TimeLine = "4/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 227,
                    ProCost = 130
                });
                groupData.Add(new GroupData
                {
                    Id = 1093,
                    TimeLine = "5/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 226,
                    ProCost = 144
                });
                groupData.Add(new GroupData
                {
                    Id = 1094,
                    TimeLine = "6/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 40,
                    ProCost = 52
                });
                groupData.Add(new GroupData
                {
                    Id = 1095,
                    TimeLine = "7/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 19,
                    ProCost = 40
                });
                groupData.Add(new GroupData
                {
                    Id = 1096,
                    TimeLine = "8/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 127,
                    ProCost = 91
                });
                groupData.Add(new GroupData
                {
                    Id = 1097,
                    TimeLine = "9/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Hydro-electric",
                    PowUnits = 70,
                    ProCost = 66
                });
                groupData.Add(new GroupData
                {
                    Id = 1098,
                    TimeLine = "10/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Geo-thermal",
                    PowUnits = 36,
                    ProCost = 21
                });
                groupData.Add(new GroupData
                {
                    Id = 1099,
                    TimeLine = "11/1/2016",
                    Sector = "Public Sector",
                    EnerType = "Free Energy",
                    EneSource = "Solar",
                    PowUnits = 144,
                    ProCost = 85
                });
                groupData.Add(new GroupData
                {
                    Id = 1100,
                    TimeLine = "12/1/2016",
                    Sector = "Private Sector",
                    EnerType = "Free Energy",
                    EneSource = "Wind",
                    PowUnits = 212,
                    ProCost = 130
                });

                return groupData;
            }
        }

        public class PivotCSVData
        {
            public string Region { get; set; }
            public string Country { get; set; }
            public string ItemType { get; set; }
            public string SalesChannel { get; set; }
            public string OrderPriority { get; set; }
            public string OrderDate { get; set; }
            public int OrderID { get; set; }
            public string ShipDate { get; set; }
            public int UnitsSold { get; set; }
            public double UnitPrice { get; set; }
            public double UnitCost { get; set; }
            public double TotalRevenue { get; set; }
            public double TotalCost { get; set; }
            public double TotalProfit { get; set; }


            public List<string[]> ReadCSVData(string url)
            {
                List<string[]> data = new List<string[]>();
                using (StreamReader reader = new StreamReader(new WebClient().OpenRead(url)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();

                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            data.Add(line.Split(','));
                        }
                    }
                    return data;
                }
            }
        }

        //public class PivotJSONData
        //{
        //    public string Date { get; set; }
        //    public string Sector { get; set; }
        //    public string EnerType { get; set; }
        //    public string EneSource { get; set; }
        //    public int PowUnits { get; set; }
        //    public int ProCost { get; set; }


        //    public List<PivotJSONData> ReadJSONData(string url)
        //    {
        //        WebClient myWebClient = new WebClient();
        //        Stream myStream = myWebClient.OpenRead(url);
        //        StreamReader stream = new StreamReader(myStream);
        //        string result = stream.ReadToEnd();
        //        stream.Close();
        //        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<PivotJSONData>>(result);
        //    }
        //}

        public class PivotViewData
        {
            public string ProductID { get; set; }
            public string Country { get; set; }
            public string Product { get; set; }
            public double Sold { get; set; }
            public double Price { get; set; }
            public string Year { get; set; }

            public List<PivotViewData> GetVirtualData()
            {
                List<PivotViewData> VirtualData = new List<PivotViewData>();

                for (int i = 1; i <= 100; i++)
                {
                    PivotViewData p = new PivotViewData
                    {
                        ProductID = "PRO-" + (100 + i),
                        Year = (new string[] { "FY 2015", "FY 2016", "FY 2017", "FY 2018", "FY 2019" })[new Random().Next(5)],
                        Country = (new string[] { "Canada", "France", "Australia", "Germany", "France" })[new Random().Next(5)],
                        Product = (new string[] { "Car", "Van", "Bike", "Flight", "Bus" })[new Random().Next(5)],
                        Price = (3.4 * i) + 500,
                        Sold = (i * 15) + 10
                    };
                    VirtualData.Add(p);
                }
                return VirtualData;
            }
        }

        public class BusinessObjectsDataView
        {
            public DataTable GetDataTable()
            {
                DataTable dt = new DataTable("BusinessObjectsDataTable");
                PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(typeof(PivotViewData));
                foreach (PropertyDescriptor pd in pdc)
                {
                    dt.Columns.Add(new DataColumn(pd.Name, pd.PropertyType));
                }
                List<PivotViewData> list = new PivotViewData().GetVirtualData();
                foreach (PivotViewData bo in list)
                {
                    DataRow dr = dt.NewRow();
                    foreach (PropertyDescriptor pd in pdc)
                    {
                        dr[pd.Name] = pd.GetValue(bo);
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }
    }
}
