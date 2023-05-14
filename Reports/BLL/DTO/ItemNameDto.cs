using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ItemNameDto
    {
        public string Message { get; set; }
        
        public object data { get; set; }
        public int Size_No { get; set; }
        public int Page_No { get; set; }
        public int ItemCardId { get; set; }
        public string ItemDescA { get; set; }
        public string ItemDescE { get; set; }
        public string ItemCode { get; set; }
        public int ItemType { get; set; }
        public bool IsSerialItem { get; set; }
        public bool IsExpir { get; set; }
        public bool IsDimension { get; set; }
        public bool IsAttributeItem { get; set; }
        public bool IsCommisionPercent { get; set; }

        //الضرايب
        public int TaxesId1 { get; set; }
        public int TaxesId2 { get; set; }
        public int TaxesId3 { get; set; }
        public decimal Tax1Rate { get; set; }
        public decimal Tax2Rate { get; set; }
        public decimal Tax3Rate { get; set; }
        public bool Tax1PlusOrMinus { get; set; }
        public bool Tax2PlusOrMinus { get; set; }
        public bool Tax3PlusOrMinus { get; set; }
        public bool Tax1IsAccomulative { get; set; }
        public bool Tax2IsAccomulative { get; set; }
        public bool Tax3IsAccomulative { get; set; }

        public int Tax1Style { get; set; }
        public int Tax2Style { get; set; }
        public int Tax3Style { get; set; }
        public bool Tax1ForSale { get; set; }
        public bool Tax2ForSale { get; set; }
        public bool Tax3ForSale { get; set; }
        public bool Tax1ForPurch { get; set; }
        public bool Tax2ForPurch { get; set; }
        public bool Tax3ForPurch { get; set; }
        public string imagePath { get; set; }
    }
}
