using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MS_Rpt_ItemCardQtyListPart_Result
    {
        public int ItemCardId { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescA { get; set; }
        public string ItemDescE { get; set; }
        public Nullable<decimal> QtyPartiation { get; set; }
        public Nullable<decimal> QtyInNotebook { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string PartCode { get; set; }
        public string PartDescA { get; set; }
        public Nullable<decimal> FirstPrice { get; set; }
        public Nullable<decimal> SecandPrice { get; set; }
        public Nullable<decimal> QtyInBox { get; set; }
        public Nullable<decimal> CoastAverage { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public string ItemCatCode { get; set; }
        public string ItemCatDescA { get; set; }
        public Nullable<decimal> ThirdPrice { get; set; }
        public Nullable<decimal> LargePrice { get; set; }
        public string ItemBatchCode { get; set; }
        public string ItemBatchName1 { get; set; }
        public Nullable<decimal> sqm { get; set; }
        public Nullable<decimal> TotalLengthMeter { get; set; }
        public Nullable<decimal> TotalWidthMeter { get; set; }
        public string LotNumberExpiry { get; set; }
        public Nullable<System.DateTime> ProdDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string FixedPart { get; set; }
        public string ManualPart { get; set; }
        public string ManualPart2 { get; set; }
        public string ManualPart3 { get; set; }
        public string ManualPart4 { get; set; }
        public string ManualPart5 { get; set; }
        public string ManualPart6 { get; set; }
        public string Remarks { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }
        public string Remarks5 { get; set; }
        public string Remarks6 { get; set; }
        public string Remarks7 { get; set; }
        public string Day { get; set; }
        public string Week { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public Nullable<decimal> LastCost { get; set; }
        public Nullable<decimal> TotalLastCost { get; set; }
        public string AddField1 { get; set; }
        public string BarCode1 { get; set; }
        public string SRNo1 { get; set; }
        public string rmas { get; set; }
    }
}
