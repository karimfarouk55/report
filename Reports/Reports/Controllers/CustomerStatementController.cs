using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Service;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Static.Helper;

namespace Reports.Controllers
{
    public class CustomerStatementController : BaseController
    {
        private readonly CustomerStatementBll _serviceBll;
        public CustomerStatementController(CustomerStatementBll serviceBll)
        {
            _serviceBll = serviceBll;
        }

        #region تحميل الحسابات
        [HttpPost, AllowAnonymous]
        public ResultDTO GetCustomerStatementSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = _serviceBll.GetCustomerAccountSelect(parametersDTO);
            return resultDTO;
        }
        #endregion

        #region الحصول على التقرير
        [HttpPost, AllowAnonymous]
        public ResultDTO GetCustomerAccountStatementRpt(int CustAccountId, string vendorCode, string from, string to, string lang)
        {
            ResultDTO resultDTO = _serviceBll.GetCustomerAccountStatementRpt(CustAccountId, vendorCode, from, to, lang);
            return resultDTO;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult GetCustomerWithAcount()
        {
            CreateCustomerDto CustomerResultDto = new CreateCustomerDto();

            DataTable dt = _serviceBll.GetCustomerWithAcounts();
          
            int CustomerId = Convert.ToInt32(dt.Rows[0][0].ToString());
            string CustomerDescA = dt.Rows[0][1].ToString();
            string CustomerDescE = dt.Rows[0][2].ToString();
            int CustomerCode = Convert.ToInt32(dt.Rows[0][3].ToString());
            int BalanceDebitLocal = Convert.ToInt32(dt.Rows[0][4].ToString());

            CustomerResultDto.CustomerId = CustomerId;
            CustomerResultDto.CustomerDescA = CustomerDescA;
            CustomerResultDto.CustomerDescE = CustomerDescE;
            CustomerResultDto.TotalAccount = BalanceDebitLocal;

            return Ok(CustomerResultDto);

        }

        [HttpPost, AllowAnonymous]
        public CreateCustomerDto GetCustomerWithAcounts2(int? Page_No, int? Size_No)
        {
             return _serviceBll.GetCustomerWithAcounts2(Page_No, Size_No);
                
        }

        //nextTry
      
        #endregion
    }
}
