using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class HrPeriodTableVacations
    {
        public int PeriodVacatId { get; set; }
        public int? PeriodTableId { get; set; }
        public DateTime? VacationDate { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }

        public virtual HrPeriodsTables PeriodTable { get; set; }
    }
}
