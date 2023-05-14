using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ItemByIdDto
    {
        public string UnitCode { get; set; }
        public string UnitNam { get; set; }
        public string UnitNamE { get; set; }
        public decimal UnittRate { get; set; }
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
        public decimal Price4 { get; set; }
        public decimal Price5 { get; set; }
        public decimal Price6 { get; set; }
        public decimal Price7 { get; set; }
        public decimal Price8 { get; set; }
        public decimal Price9 { get; set; }
        public decimal Price10 { get; set; }
        public decimal Quantity1 { get; set; }
        public decimal Quantity2 { get; set; }
        public decimal Quantity3 { get; set; }
        public decimal Quantity4 { get; set; }
        public decimal Quantity5 { get; set; }
        public bool IsDefaultSale { get; set; }
        public bool IsDefaultPurchas { get; set; }

    }
}
