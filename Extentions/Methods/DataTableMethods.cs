using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Extensions
{
    public static class DataTableExtensions
    {
        public static void ToCSV(this DataTable dtDataTable, string FilePath, bool IncludeHeaders = true, string delimiter = ",")
        {
            int ColumnAmount = dtDataTable.Columns.Count;

            StreamWriter sw = new StreamWriter(FilePath, false);

            if (IncludeHeaders.Equals(true))
            {
                for (int i = 0; i < ColumnAmount; i++)
                {
                    sw.Write(dtDataTable.Columns[i]);
                    if (i < ColumnAmount - 1)
                    {
                        sw.Write(delimiter);
                    }
                }
                sw.Write(sw.NewLine);
            }

            //Writing out the rows
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < ColumnAmount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(delimiter))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }

                        sw.Write(value);
                    }
                    if (i < ColumnAmount - 1)
                    {
                        sw.Write(delimiter);
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

    }
}
