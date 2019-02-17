using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;
using System.Linq;

namespace RollCalls
{
    /// <summary>
    /// Takes data loaded into a DatTable and kicks it out into a 
    /// spreadhseet in OpenOffice XML format with a fancy header row
    /// </summary>
    public class ExcelExport : ExportBase
    {
        protected ExcelPackage mExcelPackage;
        protected ExcelPackage _excelPackage
        {
            get { return mExcelPackage ?? (mExcelPackage = new ExcelPackage()); }
        }

        protected virtual void StyleHeaderCell(ExcelStyle style)
        {
            style.Font.Bold = true;
            style.Font.Color.SetColor(Color.FromArgb(0, 0, 0));
            style.Border.Bottom.Style = ExcelBorderStyle.Thick;
            style.Border.Bottom.Color.SetColor(Color.FromArgb(33, 33, 33));
        }

        protected string _worksheetName;
        public virtual string WorksheetName
        {
            set
            {
                _worksheetName = value;
            }
            get
            {
                return string.IsNullOrEmpty(_worksheetName) ? "Sheet 1" : _worksheetName;
            }
        }

        public override byte[] GetBytes(bool includeHeaders = true)
        {
            if (DataTable.Rows.Count > 0) AddWorkSheet(WorksheetName, DataTable, includeHeaders);
            foreach (var ws in _excelPackage.Workbook.Worksheets)
            {
                for (int i = 1; i <= ws.Dimension.End.Column; i++)
                {
                    ws.Column(i).AutoFit();
                    if (ws.Column(i).Width > 80) ws.Column(i).Width = 80;
                }
            }
            return _excelPackage.GetAsByteArray();
        }

        public virtual void AddWorkSheet(string sheetTitle, DataTable sheetContent, bool includeHeaders = true)
        {
            var worksheet = _excelPackage.Workbook.Worksheets.Add(sheetTitle);
            int col = 1;
            int row = 1;
            if (includeHeaders)
            {
                foreach (DataColumn column in sheetContent.Columns)
                {
                    worksheet.Cells[row, col].Value = column.ColumnName;
                    StyleHeaderCell(worksheet.Cells[row, col].Style);
                    col++;
                }
                row++;
            }
            foreach (DataRow dtRow in sheetContent.Rows)
            {
                col = 1;
                foreach (var val in dtRow.ItemArray.Select(o => o.ToString()))
                {
                    worksheet.Cells[row, col].Value = val;
                    col++;
                }
                row++;
            }
        }
    }
}
