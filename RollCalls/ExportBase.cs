using System.Data;

namespace RollCalls
{
    /// <summary>
    /// Base export in case we need to support different exports types (CSV, etc.
    /// </summary>
    public abstract class ExportBase
    {
        public virtual DataTable DataTable { get; set; }
        public ExportBase()
        {
            this.DataTable = new DataTable();
        }
        public ExportBase(DataTable dt)
        {
            this.DataTable = dt;
        }

        public abstract byte[] GetBytes(bool includeHeaders = true);

        public virtual void AddHeaders(params string[] headers)
        {
            foreach (var header in headers)
            {
                DataTable.Columns.Add(new DataColumn(header, typeof(string)));
            }
        }

        public virtual void AddRow(params string[] row)
        {
            DataTable.Rows.Add(row);
        }
    }
}
