using RollCalls.Properties;
using System.IO;

namespace RollCalls
{
    class Program
    {
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
