using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Service;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Static.Helper;

namespace Reports.Controllers
{
    public class VendorAccountController : BaseController
    {
        private readonly VendorAccountBll _serviceBll;
        public VendorAccountController(VendorAccountBll serviceBll)
        {
            _serviceBll = serviceBll;
        }

        #region تحميل الحسابات
        [HttpPost, AllowAnonymous]
        public ResultDTO GetVendorAccountSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = _serviceBll.GetVendorAccountSelect(parametersDTO);
            return resultDTO;
        }
        #endregion

        #region الحصول على التقرير
        [HttpPost, AllowAnonymous]
        public ResultDTO GetVendorAccountStatementRpt(int vendAccountId, string vendorCode, string from, string to, string lang)
        {
            ResultDTO resultDTO = _serviceBll.GetVendorAccountStatementRpt(vendAccountId, vendorCode, from, to, lang);
            return resultDTO;
        }
        #endregion
    }
}
