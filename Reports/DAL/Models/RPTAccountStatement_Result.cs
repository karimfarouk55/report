using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class RPTAccountStatement_Result
    {
        public Nullable<int> AccountId { get; set; }
        public string AccountCode { get; set; }
        public string AccountNameA { get; set; }
        public Nullable<int> TrNo { get; set; }
        public Nullable<System.DateTime> TrDate { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescA { get; set; }
        public Nullable<decimal> OpenningBalanceDepitCurncy { get; set; }
        public Nullable<decimal> OpenningBalanceCreditCurncy { get; set; }
        public Nullable<decimal> OpenningBalanceDepit { get; set; }
        public Nullable<decimal> OpenningBalanceCredit { get; set; }
        public Nullable<decimal> AccCurrTrancDepit { get; set; }
        public Nullable<decimal> AccTotaCredit { get; set; }
        public Nullable<decimal> AccTotalDebit { get; set; }
        public Nullable<decimal> BalanceDebitLocal { get; set; }
        public Nullable<decimal> BalanceCreditLocal { get; set; }
        public Nullable<decimal> AccCurrTrancCreditCurncy { get; set; }
        public Nullable<decimal> AccTotaCreditCurncy { get; set; }
        public Nullable<decimal> BalanceDebitCurncy { get; set; }
        public Nullable<decimal> BalanceCreditCurncy { get; set; }
        public decimal DebitLocal { get; set; }
        public decimal CreditLocal { get; set; }
        public decimal DebitCurrency { get; set; }
        public decimal CreditCurrency { get; set; }
        public decimal BalanceLocalAfterDebit { get; set; }
        public decimal BalanceLocalAfterCredit { get; set; }
        public decimal BalanceCurrencyAfterDebit { get; set; }
        public decimal BalanceCurrencyAfterCredit { get; set; }
        public string TableCode { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> DefualtCurrency { get; set; }
        public Nullable<long> ChrtAccountCode { get; set; }
        public decimal DebitLocalWithoutOpen { get; set; }
        public decimal CreditLocalWithoutOpen { get; set; }
        public decimal DebitCurrencyWithoutOpen { get; set; }
        public decimal CreditCurrencyWithoutOpen { get; set; }
        public bool IsOpenning { get; set; }
        public Nullable<bool> CalcMethod { get; set; }
        public string DocTrNo { get; set; }
        public Nullable<int> TableEntityId { get; set; }
        public Nullable<int> TermId { get; set; }
        public string IDname { get; set; }
        public string AffectedAccounts { get; set; }
        public string HelpAccType { get; set; }
        public int PostQueId { get; set; }
        public string SourcTyp { get; set; }
        public string SourceCode { get; set; }
        public string SourceName { get; set; }
        public string AffectedAccounts2 { get; set; }
        public string CheckNumber { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string JurDesc { get; set; }
    }
}
