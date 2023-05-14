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
    public class AccountStatementController : BaseController
    {
        private readonly AccountStatementBll _serviceBll;
        public AccountStatementController(AccountStatementBll serviceBll)
        {
            _serviceBll = serviceBll;
        }

        #region تحميل الحسابات
        [HttpPost, AllowAnonymous]
        public ResultDTO GetAccountStatementSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = _serviceBll.GetAccountStatementSelect(parametersDTO);
            return resultDTO;
        }
        #endregion

        #region الحصول على التقرير
        [HttpPost, AllowAnonymous]
        public ResultDTO GetProfessorAccountStatementRpt(int accountId, string from, string to, string lang = "ar")
        {
            ResultDTO resultDTO = _serviceBll.GetProfessorAccountStatementRpt(accountId, from, to, lang);
            return resultDTO;
        }
        #endregion
    }
}
