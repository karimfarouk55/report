using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Extentions
{
    public static class DataTableExtention
    {
        public static DataTable ToDataTable(IQueryable data) 
        {
            var Columns = data.ElementType.GetProperties().Select(x => new { x.Name,x.PropertyType }).ToList();
            DataTable dt = new DataTable();
            foreach (var col in Columns)
            {
                dt.Columns.Add(col.Name,col.PropertyType);
            }
            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
                foreach (var col in Columns)
                {
                    dr[col.Name] = item.GetType().GetProperty(col.Name).GetValue(item);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
       
    }
}
