using System;
using System.Collections.Generic;
using System.Text;

namespace Static.VM
{
    public class RPTAccountStatementVM
    {
        public Nullable<int> AccountId { get; set; }
        public string DocTrNo { get; set; }
        public Nullable<System.DateTime> TrDate { get; set; }
        public string DocType { get; set; }
        public string CurrencyDesc { get; set; }
        public decimal DebitLocal { get; set; }
        public decimal CreditLocal { get; set; }
        public decimal BalancLocal { get; set; }
        public decimal BalancCurrency { get; set; }
        public decimal DebitCurrency { get; set; }
        public decimal CreditCurrency { get; set; }
        public string Remarks { get; set; }
        public decimal PreviousBalance { get; set; }
        public string NatureAccount { get; set; }
    }
}
