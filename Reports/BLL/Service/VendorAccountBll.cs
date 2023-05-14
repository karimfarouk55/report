using BLL.Authentication;
using BLL.DTO;
using DAL.Context;
using DAL.Models;
using DAL.Repository;
using Microsoft.Data.SqlClient;
using Static.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.Service
{
    public class VendorAccountBll
    {
        private readonly IRepository<MsVendor> _repository;
        private string language = "ar";

        public VendorAccountBll(IRepository<MsVendor> repository)
        {
            _repository = repository;
        }

        #region تحميل الحسابات
        public ResultDTO GetVendorAccountSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = parametersDTO.lang == "ar" ? "خطا بالبيانات" : "Invalid data" };

            var tbl = _repository.Find(p => !p.DeletedAt.HasValue);
            if (tbl != null)
            {
                var data = tbl.Select(p => new { Id = p.VendorId, Code = p.VendorCode, Name = (parametersDTO.lang == "ar" ? p.VendorDescA : p.VendorDescE) });
                resultDTO.data = data;
                resultDTO.Status = true;
                resultDTO.Message = parametersDTO.lang == "ar" ? "تم عرض البيانات بنجاح" : "Data is displayed correctly";
            }

            return resultDTO;
        }
        #endregion


        #region الحصول على التقرير
        public ResultDTO GetVendorAccountStatementRpt(int vendAccountId, string vendorCode, string from, string to, string lang)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = lang == "ar" ? "خطا بالبيانات" : "Invalid data" };
            DateTime? fromDate = null, toDate = null;
            DateTime fromOutDate, toOutDate;
            language = lang;

            List<RPTVendorStatement_Result> rPTAccounts = null;

            try
            {
                if (!string.IsNullOrEmpty(from))
                    if (DateTime.TryParseExact(from, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromOutDate))
                        fromDate = fromOutDate;

                if (!string.IsNullOrEmpty(to))
                    if (DateTime.TryParseExact(to, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out toOutDate))
                        toDate = toOutDate;

                SqlParameter[] parameters = new[] {
                    new SqlParameter("@VendorCodeFrom", vendorCode) , new SqlParameter("@VendorCodeTo", vendorCode),
                    new SqlParameter("@TrdateFrom", fromDate) ,new SqlParameter("@TrdateTo", toDate),
                    new SqlParameter("@VendAccountId", vendAccountId)
                };

                rPTAccounts = _repository.ExecuteStoredProcedure<RPTVendorStatement_Result>("RPTVendorStatement", parameters).ToList();
            }
            catch (Exception ex)
            {
                resultDTO.Message = resultDTO.Message = ex?.Message + "\n \n " + ex.InnerException?.Message; ;
                return resultDTO;
            }

            resultDTO.data = GertResult(rPTAccounts);
            resultDTO.Status = true;
            resultDTO.Message = lang == "ar" ? "تم عرض البيانات بنجاح" : "Data is displayed correctly";
            return resultDTO;
        }

        public List<RPTAccountStatementVM> GertResult(List<RPTVendorStatement_Result> rPTAccounts)
        {
            decimal PreviousBalance = 0; int decCount = 3;
            List<RPTAccountStatementVM> accountStatement = new List<RPTAccountStatementVM>();
            foreach (var item in rPTAccounts)
            {
                RPTAccountStatementVM newAccountStatement = new RPTAccountStatementVM()
                {
                    AccountId = item.AccountId,
                    DocTrNo = item.DocTrNo,
                    TrDate = item.TrDate,
                    CurrencyDesc = item.CurrencyDescA,
                    DebitLocal = item.DebitLocal,
                    CreditLocal = item.CreditLocal,
                    CreditCurrency = item.CreditCurrency,
                    DebitCurrency = item.DebitCurrency,
                    Remarks = item.Remarks,
                    DocType = GetDocType(item),
                };
                accountStatement.Add(newAccountStatement);
                PreviousBalance = GetBalanceBeforeLocal(item);
                newAccountStatement.BalancLocal = decimal.Round(GetBalancLocal(accountStatement, item, PreviousBalance), decCount);
            }

            foreach (RPTAccountStatementVM item in accountStatement)
            {
                item.PreviousBalance = decimal.Round(PreviousBalance, decCount);
                item.DebitLocal = decimal.Round(item.DebitLocal, decCount);
                item.CreditLocal = decimal.Round(item.CreditLocal, decCount);
                item.CreditCurrency = decimal.Round(item.CreditCurrency, decCount);
                item.DebitCurrency = decimal.Round(item.DebitCurrency, decCount);
            }

            return accountStatement;
        }

        #region DocType
        public string GetDocType(RPTVendorStatement_Result item)
        {
            string DocType = string.Empty;
            if (item.TableCode == "Cal_JurnalEntry") DocType = "قيد يوميه";
            else if (item.TableCode == "Ms_AdjustMents") DocType = "تسويات";
            else if (item.TableCode == "Ms_KeeperBank") DocType = "حافظه بنكيه";
            else if (item.TableCode == "MS_PaymentNote") DocType = "مستند صرف";
            else if (item.TableCode == "Ms_PurchasInvoice") DocType = "فاتورة مشتريات";
            else if (item.TableCode == "Ms_ReceiptNote") DocType = "مستند قبض";
            else if (item.TableCode == "MS_ReturnSales") DocType = "مرتجع مبيعات";
            else if (item.TableCode == "Ms_SalesInvoice") DocType = "فاتورة مبيعات";
            else if (item.TableCode == "MS_Pettycash") DocType = "مستند عهده";
            else if (item.TableCode == "Ms_DeliverSalesInvoice") DocType = "صرف مخزنى";
            else if (item.TableCode == "Ms_ItemStockAdjustment") DocType = "جرد مخزنى";
            else if (item.TableCode == "Ms_SalesOffer") DocType = "عرض سعر";
            else if (item.TableCode == "Ms_PurchasOrder") DocType = "أمر شراء";
            else if (item.TableCode == "MS_StockRecript") DocType = "توريد مخزنى";
            else if (item.TableCode == "MS_StockTransferNote") DocType = "تحويل مخزنى";
            else if (item.TableCode == "BNk_BankNotice") DocType = "اشعار بنكى";
            else if (item.TableCode == "MS_BoxTransferNote") DocType = "تحويل مالى";
            else if (item.TableCode == "Ms_SalesOrder") DocType = "أمر بيع";
            return DocType;
        }
        #endregion

        #region LocalBalance
        ////رصيد محلى
        public decimal GetBalancLocal(List<RPTAccountStatementVM> accountStatement, RPTVendorStatement_Result rPTAccounts, decimal BalanceBeforeLocal)
        {
            decimal BalancLocal = 0;
            string NatureAccount = string.Empty;
            if (rPTAccounts.CalcMethod == false)
            {
                BalancLocal = accountStatement.Sum(x => x.CreditLocal) - accountStatement.Sum(x => x.DebitLocal) + BalanceBeforeLocal;
                NatureAccount = BalancLocal < 0 ? (language == "ar" ? "مدين" : "Debtor") : (language == "ar" ? "دائن" : "Creditor");
            }
            else if (rPTAccounts.CalcMethod == true)
            {
                BalancLocal = accountStatement.Sum(x => x.DebitLocal) - accountStatement.Sum(x => x.CreditLocal) + BalanceBeforeLocal;
                NatureAccount = BalancLocal < 0 ? (language == "ar" ? "دائن" : "Creditor") : (language == "ar" ? "مدين" : "Debtor");
            }


            accountStatement.ForEach(x => x.NatureAccount = NatureAccount);
            accountStatement.ForEach(x => x.PreviousBalance = BalancLocal);
            return BalancLocal;
        }

        public decimal GetBalanceBeforeLocal(RPTVendorStatement_Result rPTAccounts)
        {
            decimal BalanceBeforeLocal = 0;
            if (rPTAccounts.CalcMethod == false)
                BalanceBeforeLocal = rPTAccounts.CreditLocalWithoutOpen - rPTAccounts.DebitLocalWithoutOpen + GetOpenBalanceLocal(rPTAccounts);
            else if (rPTAccounts.CalcMethod == true)
                BalanceBeforeLocal = rPTAccounts.DebitLocalWithoutOpen - rPTAccounts.CreditLocalWithoutOpen + GetOpenBalanceLocal(rPTAccounts);

            return BalanceBeforeLocal;
        }

        public decimal GetOpenBalanceLocal(RPTVendorStatement_Result rPTAccounts)
        {
            decimal? OpenBalanceLocal = 0;
            if (rPTAccounts.CalcMethod == false)
            {
                if (rPTAccounts.OpenningBalanceCredit == null || rPTAccounts.OpenningBalanceCredit == 0)
                    OpenBalanceLocal = rPTAccounts.OpenningBalanceDepit.Value * -1;
                else OpenBalanceLocal = rPTAccounts.OpenningBalanceCredit;
            }
            else if (rPTAccounts.CalcMethod == true)
            {
                if (rPTAccounts.OpenningBalanceDepit == null || rPTAccounts.OpenningBalanceDepit == 0)
                    OpenBalanceLocal = rPTAccounts.OpenningBalanceCredit * -1;
                else OpenBalanceLocal = rPTAccounts.OpenningBalanceDepit;
            }
            return OpenBalanceLocal.GetValueOrDefault(0);
        }
        #endregion

        #endregion
    }
}
