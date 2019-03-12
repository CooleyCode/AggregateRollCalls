using RollCalls.Properties;
using System.IO;

namespace RollCalls
{
    class Program
    {
        /// <summary>
        /// 1) Collect all the rollcall data that has been download
        /// 2) Build a datatable out of the data
        /// 3) Export data in Excel format
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var rollCalls = LoadXmlData.GetRollcallvotes(Settings.Default.XmlPath, Settings.Default.SearchPattern);
            var rollCallDataTable = GenerateRollCallDataTable.BuildTable(rollCalls);

            var excelExport = new ExcelExport();
            excelExport.AddWorkSheet(Settings.Default.ExcelWorkSheetName, rollCallDataTable);

            var byteArray = excelExport.GetBytes();
            using (var fs = new FileStream(Settings.Default.ExcelFilePathAndName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(byteArray, 0, byteArray.Length);
            }
        }
    }
}
