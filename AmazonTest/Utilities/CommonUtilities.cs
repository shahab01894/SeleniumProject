using NPOI.XSSF.UserModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonTest.Utilities
{
    internal class CommonUtilities
    {
        private readonly IWebDriver driver;
        public string ReadDataFromExcel()
        {
            string path = @"D:\TestData\Book1.xlsx";
            using (FileStream fs=new FileStream(path,FileMode.Open,FileAccess.Read))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(fs);
                var sheet = workbook.GetSheetAt(0);
                var row = sheet.GetRow(0);
                var value = row.GetCell(0).ToString();
                return value;
            }
        }
        public Dictionary<string, string> GetEmployeeData()
        {
           
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(baseDirectory, "TestData", "Book1.xlsx");
            //string path = @"D:\TestData\Book1.xlsx";
            var dataMap = new Dictionary<string, string>();

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(fs);
                var sheet = workbook.GetSheetAt(0);

                var headerRow = sheet.GetRow(0); // Row 1 in Excel (Headers)
                var valueRow = sheet.GetRow(1);  // Row 2 in Excel (Shahab's Data)

                // Loop through columns A to F dynamically 
                for (int i = 0; i < headerRow.LastCellNum; i++)
                {
                    string header = headerRow.GetCell(i)?.ToString() ?? $"Column{i}";
                    string cellValue = valueRow?.GetCell(i)?.ToString() ?? string.Empty;

                    dataMap[header] = cellValue;
                }
            }
            return dataMap;
        }
      
    }
}
