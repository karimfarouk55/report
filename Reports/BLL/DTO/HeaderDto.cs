using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class HeaderDto
    {
        public int Header_BookId { get; set; }
        public int Header_TrNo { get; set; }
        public int Header_TermId { get; set; }
        public int Header_CurrencyId { get; set; }
        public int Header_CustomerId { get; set; }
        public int Header_RectSourceType { get; set; }
        public decimal Header_Rate { get; set; }
        public decimal NotPaid { get; set; }

        public string Header_CreatedBy { get; set; }
        public DateTime Header_CreatedAt { get; set; }
        public decimal Header_InvTotal { get; set; }
        public decimal Header_DiscAmount { get; set; }
        public decimal Header_DiscPercent { get; set; }
        public decimal Header_DiscAmount2 { get; set; }
        public decimal Header_DiscPercent2 { get; set; }
        public decimal Header_TotalItemTax1 { get; set; }
        public decimal Header_TotalItemTax2 { get; set; }
        public decimal Header_TotalItemTax3 { get; set; }
        public decimal Header_TaxValue1 { get; set; }
        public decimal Header_TaxValue2 { get; set; }
        public decimal Header_TaxValue3 { get; set; }
        public int Header_TaxesId1 { get; set; }
        public int Header_TaxesId2 { get; set; }
        public int Header_TaxesId3 { get; set; }
        public decimal Header_PriceAfterTax { get; set; }
        public decimal Header_NetPrice { get; set; }
        public decimal Header_PaidPrice { get; set; }
        public decimal Header_PaidPriceVisa { get; set; }
        public decimal Header_BankTransfer { get; set; }

        // another table

        //public int Detail_ItemCardId { get; set; }
        //public decimal Detail_Price { get; set; }
        //public decimal Detail_PriceAfterRate { get; set; }
        //public decimal Detail_QtyBeforRate { get; set; }
        //public decimal Detail_Quantity { get; set; }
        //public int Detail_UnitId { get; set; }
        //public decimal Detail_UnitRate { get; set; }

        //public int Detail_StoreId { get; set; }
        //public int Detail_StorePartId { get; set; }
        //public decimal Detail_DisPercent { get; set; }
        //public decimal Detail_DisAmount { get; set; }
        //public decimal Detail_Tax1Percent { get; set; }
        //public decimal Detail_Tax2Percent { get; set; }
        //public decimal Detail_Tax3Percent { get; set; }
        //public int Detail_TaxesId1 { get; set; }
        //public int Detail_TaxesId2 { get; set; }
        //public int Detail_TaxesId3 { get; set; }
        //public bool Detail_Tax1IsAccomulative { get; set; }
        //public bool Detail_Tax2IsAccomulative { get; set; }
        //public bool Detail_Tax3IsAccomulative { get; set; }


    }
}
