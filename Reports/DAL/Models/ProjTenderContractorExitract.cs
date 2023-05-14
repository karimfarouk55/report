using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProjTenderContractorExitract
    {
        public ProjTenderContractorExitract()
        {
            ProjTenderContractorExitractAdds = new HashSet<ProjTenderContractorExitractAdds>();
            ProjTenderContractorExitractDetail = new HashSet<ProjTenderContractorExitractDetail>();
            ProjTenderContractorExitractDiscounts = new HashSet<ProjTenderContractorExitractDiscounts>();
        }

        public int ContractorExitractId { get; set; }
        public int? ContractorContractId { get; set; }
        public int? TenderId { get; set; }
        public int? TenderQoutationId { get; set; }
        public int? StoreId { get; set; }
        public int? BookId { get; set; }
        public int? TermId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? Aid { get; set; }
        public int? CurrencyId { get; set; }
        public int? ContractorAccountId { get; set; }
        public string ContractorHelpAccType { get; set; }
        public int? OwnerAccountId { get; set; }
        public string OwnerHelpAccType { get; set; }
        public int TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public DateTime? EstimateDeliverDate { get; set; }
        public DateTime? FinalDeliverDate { get; set; }
        public DateTime? ConsultAgreeDate { get; set; }
        public DateTime? CustomerAgreeDate { get; set; }
        public decimal? Rate { get; set; }
        public decimal? TotalValue { get; set; }
        public int? ReviewReasonId { get; set; }
        public byte? ReviewStatus { get; set; }
        public byte? PlanStatus { get; set; }
        public bool? IsInternal { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public bool? Closed { get; set; }
        public bool? IsPrinted { get; set; }
        public bool? IsPosted { get; set; }
        public string Postedby { get; set; }
        public DateTime? PostedDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? UncloseDate { get; set; }
        public int? ClosedBy { get; set; }
        public int? UnclosedBy { get; set; }
        public int? PermPrinted { get; set; }
        public DateTime? PermPrintedAt { get; set; }
        public int? TermCostCenterId { get; set; }
        public decimal? TermCostCenterValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? ShiftId { get; set; }

        public virtual ICollection<ProjTenderContractorExitractAdds> ProjTenderContractorExitractAdds { get; set; }
        public virtual ICollection<ProjTenderContractorExitractDetail> ProjTenderContractorExitractDetail { get; set; }
        public virtual ICollection<ProjTenderContractorExitractDiscounts> ProjTenderContractorExitractDiscounts { get; set; }
    }
}
