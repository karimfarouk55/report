﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class HrVacationEdit
    {
        public int VacationEditDocId { get; set; }
        public int? VacationDocId { get; set; }
        public int? StoreId { get; set; }
        public int? BookId { get; set; }
        public int? TermId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? Aid { get; set; }
        public int? EmpId { get; set; }
        public int? EmpApprovedById { get; set; }
        public int? PeriodTableId { get; set; }
        public int? PeriodTablDetailId { get; set; }
        public int? AttendElementId { get; set; }
        public int TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? NewReturnDate { get; set; }
        public int? DayCount { get; set; }
        public int? NewDayCount { get; set; }
        public int? NetDaysCount { get; set; }
        public int? NewNetDaysCount { get; set; }
        public int? AnnualVacsBalance { get; set; }
        public int? ReservedVacsBalance { get; set; }
        public byte? AnnualVacs { get; set; }
        public byte? ReservedVacs { get; set; }
        public byte? VacationType { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public bool? Closed { get; set; }
        public bool? IsPrinted { get; set; }
        public bool? IsDelivered { get; set; }
        public bool? IsPosted { get; set; }
        public string Postedby { get; set; }
        public DateTime? PostedDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? UncloseDate { get; set; }
        public int? ClosedBy { get; set; }
        public int? UnclosedBy { get; set; }
        public int? PermPrinted { get; set; }
        public DateTime? PermPrintedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? ShiftId { get; set; }
    }
}
