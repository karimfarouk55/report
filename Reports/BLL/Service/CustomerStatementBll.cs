using BLL.Authentication;
using BLL.DTO;
using BLL.Extentions;
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
    public class CustomerStatementBll
    {
        private readonly IRepository<MsCustomer> _repository;
        private string language = "ar";
        public readonly SmartERPStandardContext _db;

        public string BasicAccCode { get;  set; }

        public CustomerStatementBll(IRepository<MsCustomer> repository, SmartERPStandardContext db)
        {
            _repository = repository;
            _db = db;
        }

        #region تحميل الحسابات
        public ResultDTO GetCustomerAccountSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = parametersDTO.lang == "ar" ? "خطا بالبيانات" : "Invalid data" };

            var tbl = _repository.Find(p => !p.DeletedAt.HasValue);
            if (tbl != null)
            {
                var data = tbl.Select(p => new { Id = p.CustomerId, Code = p.CustomerCode, Name = (parametersDTO.lang == "ar" ? p.CustomerDescA : p.CustomerDescE) });
                resultDTO.data = data;
                resultDTO.Status = true;
                resultDTO.Message = parametersDTO.lang == "ar" ? "تم عرض البيانات بنجاح" : "Data is displayed correctly";
            }

            return resultDTO;
        }
        #endregion


        #region الحصول على التقرير
        public ResultDTO GetCustomerAccountStatementRpt(int CustAccountId, string CustomerCode, string from, string to, string lang)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = lang == "ar" ? "خطا بالبيانات" : "Invalid data" };
            DateTime? fromDate = null, toDate = null;
            DateTime fromOutDate, toOutDate;
            language = lang;

            List<RPTCustomerStatement_Result> rPTAccounts = null;

            try
            {
                if (!string.IsNullOrEmpty(from))
                    if (DateTime.TryParseExact(from, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromOutDate))
                        fromDate = fromOutDate;

                if (!string.IsNullOrEmpty(to))
                    if (DateTime.TryParseExact(to, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out toOutDate))
                        toDate = toOutDate;

                SqlParameter[] parameters = new[] {
                    new SqlParameter("@CustomerCodeFrom", CustomerCode) , new SqlParameter("@CustomerCodeTo", CustomerCode),
                    new SqlParameter("@TrdateFrom", fromDate) ,new SqlParameter("@TrdateTo", toDate),
                    new SqlParameter("@CustAccountId", CustAccountId)
                };

                rPTAccounts = _repository.ExecuteStoredProcedure<RPTCustomerStatement_Result>("RPTCustomerStatement", parameters).ToList();
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

        public List<RPTAccountStatementVM> GertResult(List<RPTCustomerStatement_Result> rPTAccounts)
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
        public string GetDocType(RPTCustomerStatement_Result item)
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
        public decimal GetBalancLocal(List<RPTAccountStatementVM> accountStatement, RPTCustomerStatement_Result rPTAccounts, decimal BalanceBeforeLocal)
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

        public decimal GetBalanceBeforeLocal(RPTCustomerStatement_Result rPTAccounts)
        {
            decimal BalanceBeforeLocal = 0;
            if (rPTAccounts.CalcMethod == false)
                BalanceBeforeLocal = rPTAccounts.CreditLocalWithoutOpen - rPTAccounts.DebitLocalWithoutOpen + GetOpenBalanceLocal(rPTAccounts);
            else if (rPTAccounts.CalcMethod == true)
                BalanceBeforeLocal = rPTAccounts.DebitLocalWithoutOpen - rPTAccounts.CreditLocalWithoutOpen + GetOpenBalanceLocal(rPTAccounts);

            return BalanceBeforeLocal;
        }

        public decimal GetOpenBalanceLocal(RPTCustomerStatement_Result rPTAccounts)
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
        public DataTable GetCustomerWithAcounts()
        {

            return (from C in _db.MsCustomer
                    join AC in _db.CalCustAccounts on C.CustomerId equals AC.CustomerId
                    where AC.IsInUse == true && AC.IsPrimeAccount == true 
                    select new { C.CustomerId,C.CustomerDescA,C.CustomerDescE,C.CustomerCode,C.Tel,AC.BalanceDebitLocal}).ToDataTable();


        }

        //public CreateCustomerDto GetCustomerWithAcounts2(int? Page_No, int? Size_No)
        //{
        //    CreateCustomerDto customerDto= new CreateCustomerDto() { Status = false, Message = "خطا بالبيانات" };
        //    try
        //    {
        //        int Size_Of_Page = (Size_No ?? 9);
        //        int No_Of_Page = (Page_No ?? 1);

        //        List<CreateCustomerDto> customerList = (from C in _db.MsCustomer
        //                            join AC in _db.CalCustAccounts on C.CustomerId equals AC.CustomerId
        //                            where AC.IsInUse == true && AC.IsPrimeAccount == true && AC.AccountDescription == BasicAccCode
        //                            select new CreateCustomerDto
        //                            {
        //                                CustomerId = C.CustomerId,
        //                                CustomerDescA = C.CustomerDescA,
        //                                CustomerDescE = C.CustomerDescE,
        //                                CustomerCode = C.CustomerCode,
        //                                Tel = C.Tel,
        //                                TotalAccount = (decimal)(AC.BalanceDebitLocal - AC.BalanceCreditLocal),

        //                            }).Skip((No_Of_Page - 1) * Size_Of_Page).Take(Size_Of_Page).ToList();

        //        customerDto.Page_No = No_Of_Page;
        //        customerDto.Size_No = Size_Of_Page;
        //        customerDto.Status = true;
        //        customerDto.data = customerList;
        //        customerDto.Message = "تم عرض البيانات بنجاح";

        //        return customerDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        return customerDto;
        //    }

        //}

        //public IEnumerable<CreateCustomerDto> GetCustomerWithAcounts2()
        //{
        //    var customerList = (from C in _db.MsCustomer
        //                        join AC in _db.CalCustAccounts on C.CustomerId equals AC.CustomerId
        //                        where AC.IsInUse == true && AC.IsPrimeAccount == true
        //                        select new CreateCustomerDto
        //                        {
        //                            CustomerId = C.CustomerId,
        //                            CustomerDescA = C.CustomerDescA,
        //                            CustomerDescE = C.CustomerDescE,
        //                            CustomerCode = C.CustomerCode,
        //                            Tel = C.Tel,
        //                            TotalAccount = (decimal)(AC.BalanceDebitLocal - AC.BalanceCreditLocal)
        //                        }).ToList();

        //    return customerList;
        //}

        public CreateCustomerDto GetCustomerWithAcounts2(int? Page_No, int? Size_No)
        {
            CreateCustomerDto customerDto = new CreateCustomerDto() { Status = false, Message = "خطا بالبيانات" };

            int Size_Of_Page = (Size_No ?? 9);
            int No_Of_Page = (Page_No ?? 1);

            var customerList = (from C in _db.MsCustomer
                                join AC in _db.CalCustAccounts on C.CustomerId equals AC.CustomerId
                                where AC.IsInUse == true && AC.IsPrimeAccount == true
                                select new CreateCustomerDto
                                {
                                    CustomerId = C.CustomerId,
                                    CustomerDescA = C.CustomerDescA,
                                    CustomerDescE = C.CustomerDescE,
                                    SalPrice= (int)C.SalPrice,
                                    CustomerCode = C.CustomerCode,
                                    Tel = C.Tel,
                                    TotalAccount = (decimal)(AC.BalanceDebitLocal - AC.BalanceCreditLocal)                         
                                }).Skip((No_Of_Page - 1) * Size_Of_Page).Take(Size_Of_Page).ToList();

            customerDto.Page_No = No_Of_Page;
            customerDto.Size_No = Size_Of_Page;
            customerDto.data = customerList;
            customerDto.Status = true;
            customerDto.Message = "تم عرض البيانات بنجاح";

            return customerDto;
        }

        //try2

        #endregion
    }
}
