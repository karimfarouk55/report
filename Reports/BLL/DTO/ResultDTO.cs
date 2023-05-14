using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class ResultDTO
    {
        public int Size_No { get; set; }
        public int Page_No { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object data { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }

        //public bool MinusNoteQty { get; set; }

        //public bool ShoCustBlncs { get; set; }

        //public bool ShoVendBlncs { get; set; }

        //public bool ShowDisC { get; set; }


        //public bool dateChange { get; set; }

        //public bool SeeItemCost { get; set; }


        //public bool SearchCurrentStor { get; set; }

        public bool UseBrancheCodeColumn { get; set; }

        public bool UsePartitionCodeColumn { get; set; }

        public bool UseItemTaxInSales { get; set; }


        public bool UseItemTaxInPurch { get; set; }

        public bool PriceIncludTaxInSales { get; set; }

        public bool PriceIncludTaxInPurch { get; set; }

        public bool ActivateUnit2 { get; set; }


        public Dictionary<string,dynamic> authcode { get; set; }
        //public bool UsePPolicy { get; set; }

        //public bool SalesProfit { get; set; }

        //public bool ChangeSalePrice { get; set; }


        //public bool SaleUnderCost { get; set; }

        //public bool CanSaleReservQty { get; set; }


        //public bool CanSeeSalesCommission { get; set; }

        //public bool CanSeeRecCommission { get; set; }

        //public bool BounusItem { get; set; }

        //public bool ChangePricList { get; set; }


        //public int UsePricesInSals { get; set; }



        //public int Discs { get; set; }


        //public int Count
        //{
        //    get
        //    {
        //        return Count;
        //    }

        //    set
        //    {
        //        Count = data.GetType().GetProperties().Length;
        //    }
        //}
    }
}