using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Extentions
{
    public static class DataTableExtention
    {
        public static DataTable ToDataTable( this IQueryable data) 
        {
            var Columns = data.ElementType.GetProperties().Select(x => new { x.Name,x.PropertyType }).ToList();
            DataTable dt = new DataTable();
            foreach (var col in Columns)
            {
                //dt.Columns.Add(col.Name,col.PropertyType);
                dt.Columns.Add(col.Name, Nullable.GetUnderlyingType(
                col.PropertyType) ?? col.PropertyType); 
            }
            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
                foreach (var col in Columns)
                {
                    dr[col.Name] = item.GetType().GetProperty(col.Name).GetValue(item)??DBNull.Value;

                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
       
    }
}
