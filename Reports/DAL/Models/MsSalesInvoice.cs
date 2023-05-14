﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsSalesInvoice
    {
        public MsSalesInvoice()
        {
            MsReceiptNote = new HashSet<MsReceiptNote>();
            MsSalesInvJobOrderJoin = new HashSet<MsSalesInvJobOrderJoin>();
            MsSalesInvVehiclJobOrderJoin = new HashSet<MsSalesInvVehiclJobOrderJoin>();
            MsSalesInvoiceCostDeliver = new HashSet<MsSalesInvoiceCostDeliver>();
            MsSalesInvoiceCurrencies = new HashSet<MsSalesInvoiceCurrencies>();
            MsSalesInvoiceExpenses = new HashSet<MsSalesInvoiceExpenses>();
            MsSalesInvoiceItemCard = new HashSet<MsSalesInvoiceItemCard>();
            MsSalesInvoiceMultiAccounts = new HashSet<MsSalesInvoiceMultiAccounts>();
            MsSalesInvoiceQualityDeliveryDocs = new HashSet<MsSalesInvoiceQualityDeliveryDocs>();
            MsSalesInvoiceQualityMissedItems = new HashSet<MsSalesInvoiceQualityMissedItems>();
            SrVehicleRentSalesInvJoin = new HashSet<SrVehicleRentSalesInvJoin>();
        }

        public int InvId { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreId { get; set; }
        public int? CurrencyId { get; set; }
        public int? ExpensesId { get; set; }
        public int? BookId { get; set; }
        public int? TermId { get; set; }
        public int? SalesOfferId { get; set; }
        public int? SalesOrderId { get; set; }
        public int? EmpId { get; set; }
        public int? CustBranchId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? PayMethodId { get; set; }
        public decimal? PayMethodPercent { get; set; }
        public decimal? PayMethodValue { get; set; }
        public string PayMethodDatafield { get; set; }
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
        public int TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string InvDescA { get; set; }
        public string InvDescE { get; set; }
        public string Remarks { get; set; }
        public string AddField3 { get; set; }
        public string AddField4 { get; set; }
        public string AddField5 { get; set; }
        public string AddField6 { get; set; }
        public string AddField7 { get; set; }
        public byte? InvoiceType { get; set; }
        public DateTime? InvDueDate { get; set; }
        public decimal? InvQuantity { get; set; }
        public decimal? TotalItemTax1 { get; set; }
        public decimal? TotalItemTax2 { get; set; }
        public decimal? TotalItemTax3 { get; set; }
        public decimal? TotalTaxValu { get; set; }
        public decimal? InvTotal { get; set; }
        public decimal? TotalItemsCost { get; set; }
        public decimal? TotalItemsProfit { get; set; }
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
        public decimal? PaidPriceVisa { get; set; }
        public decimal? BankTransfer { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? TotalJobOrders { get; set; }
        public decimal? Commision { get; set; }
        public decimal? ItemCommision { get; set; }
        public decimal? Rate { get; set; }
        public decimal? NetPriceBeforCurr { get; set; }
        public decimal? ExpenValueBeforCurr { get; set; }
        public decimal? ExpenValueWithCurr { get; set; }
        public bool? Closed { get; set; }
        public bool? IsPrinted { get; set; }
        public bool? IsDelivered { get; set; }
        public int? TermCostCenterId { get; set; }
        public decimal? TermCostCenterValue { get; set; }
        public bool? IsPosted { get; set; }
        public string Postedby { get; set; }
        public DateTime? PostedDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? UncloseDate { get; set; }
        public int? ClosedBy { get; set; }
        public int? UnclosedBy { get; set; }
        public int? PermPrinted { get; set; }
        public DateTime? PermPrintedAt { get; set; }
        public bool? IsPaid { get; set; }
        public int? PaidDocId { get; set; }
        public decimal? NotPaid { get; set; }
        public decimal? TotalQtyPump { get; set; }
        public decimal? TotalQtyCar { get; set; }
        public decimal? TotalQtyNoVehicl { get; set; }
        public bool? IsPos { get; set; }
        public bool? IsHold { get; set; }
        public bool? IsShippingInv { get; set; }
        public bool? MultiResourceDeliver { get; set; }
        public bool? EtaxSent { get; set; }
        public DateTime? EtaxSentTime { get; set; }
        public string EtaxRemarks { get; set; }
        public string EtaxReference { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsReturned { get; set; }
        public int? ShiftId { get; set; }
        public byte[] LastUpdateTime { get; set; }
        public bool? IsRemoteEntity { get; set; }
        public int? RemotId { get; set; }
        public int? MainCustServerId { get; set; }

        public virtual MsSalesOffer SalesOffer { get; set; }
        public virtual ICollection<MsReceiptNote> MsReceiptNote { get; set; }
        public virtual ICollection<MsSalesInvJobOrderJoin> MsSalesInvJobOrderJoin { get; set; }
        public virtual ICollection<MsSalesInvVehiclJobOrderJoin> MsSalesInvVehiclJobOrderJoin { get; set; }
        public virtual ICollection<MsSalesInvoiceCostDeliver> MsSalesInvoiceCostDeliver { get; set; }
        public virtual ICollection<MsSalesInvoiceCurrencies> MsSalesInvoiceCurrencies { get; set; }
        public virtual ICollection<MsSalesInvoiceExpenses> MsSalesInvoiceExpenses { get; set; }
        public virtual ICollection<MsSalesInvoiceItemCard> MsSalesInvoiceItemCard { get; set; }
        public virtual ICollection<MsSalesInvoiceMultiAccounts> MsSalesInvoiceMultiAccounts { get; set; }
        public virtual ICollection<MsSalesInvoiceQualityDeliveryDocs> MsSalesInvoiceQualityDeliveryDocs { get; set; }
        public virtual ICollection<MsSalesInvoiceQualityMissedItems> MsSalesInvoiceQualityMissedItems { get; set; }
        public virtual ICollection<SrVehicleRentSalesInvJoin> SrVehicleRentSalesInvJoin { get; set; }
    }
}
