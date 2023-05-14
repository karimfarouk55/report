﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsPurchasOrder
    {
        public MsPurchasOrder()
        {
            MsPurchOrderDetail = new HashSet<MsPurchOrderDetail>();
            MsPurchasInvoice = new HashSet<MsPurchasInvoice>();
        }

        public int PurOrderId { get; set; }
        public int? VendorId { get; set; }
        public int? StorId { get; set; }
        public int? CurrencyId { get; set; }
        public int? BookId { get; set; }
        public int? VendBranchId { get; set; }
        public int? PurOrderReqId { get; set; }
        public int? ExpensesId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? TermId { get; set; }
        public string DbtableName { get; set; }
        public int? DbtableId { get; set; }
        public string AccountTableName { get; set; }
        public byte? RectSourceType { get; set; }
        public int? AccountId { get; set; }
        public int? TaxesId1 { get; set; }
        public decimal? TaxValue1 { get; set; }
        public int? TaxesId2 { get; set; }
        public decimal? TaxValue2 { get; set; }
        public int? TaxesId3 { get; set; }
        public decimal? TaxValue3 { get; set; }
        public int? Aid { get; set; }
        public int? TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? ExpiryPeriodDays { get; set; }
        public int? DeliveryPeriodDays { get; set; }
        public int? PayPeriodDays { get; set; }
        public string InvDescA { get; set; }
        public string InvDescE { get; set; }
        public string AddField3 { get; set; }
        public string AddField4 { get; set; }
        public string AddField5 { get; set; }
        public string AddField6 { get; set; }
        public string AddField7 { get; set; }
        public byte? InvoiceType { get; set; }
        public DateTime? InvDueDate { get; set; }
        public decimal? TotalItemTax1 { get; set; }
        public decimal? TotalItemTax2 { get; set; }
        public decimal? TotalItemTax3 { get; set; }
        public decimal? TotalTaxValu { get; set; }
        public decimal? InvTotal { get; set; }
        public decimal? DiscPercent { get; set; }
        public decimal? DiscAmount { get; set; }
        public decimal? DiscPercent2 { get; set; }
        public decimal? DiscAmount2 { get; set; }
        public decimal? DiscPercent3 { get; set; }
        public decimal? DiscAmount3 { get; set; }
        public decimal? DiscPercent4 { get; set; }
        public decimal? DiscAmount4 { get; set; }
        public decimal? PriceAfterTax { get; set; }
        public decimal? ExpenValue { get; set; }
        public decimal? PaidPrice { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? PaidPriceVisa { get; set; }
        public decimal? Rate { get; set; }
        public bool? Executed { get; set; }
        public bool? IsPosted { get; set; }
        public string Postedby { get; set; }
        public DateTime? PostedDate { get; set; }
        public bool? Closed { get; set; }
        public string Remarks { get; set; }
        public bool? IsPrinted { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? PermPrinted { get; set; }
        public DateTime? PermPrintedAt { get; set; }
        public bool? IsPaid { get; set; }
        public int? PaidDocId { get; set; }
        public decimal? NotPaid { get; set; }
        public int? TermCostCenterId { get; set; }
        public decimal? TermCostCenterValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? ShiftId { get; set; }

        public virtual ICollection<MsPurchOrderDetail> MsPurchOrderDetail { get; set; }
        public virtual ICollection<MsPurchasInvoice> MsPurchasInvoice { get; set; }
    }
}
