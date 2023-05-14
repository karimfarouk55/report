using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Static.Helper;

namespace Reports.Controllers
{
    public class AccountController : BaseController
    {
        private readonly AccountBll _accountBll;
        public AccountController(AccountBll accountBll)
        {
            _accountBll = accountBll;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = "خطا بالبيانات" };
            if (username.IsEmpty())
                return NotFound(new { status = 500, Token = "", Message = "ادخل اسم المستخدم" });

            else if (password.IsEmpty())
                return NotFound(new { status = 500, Token = "", Message = "ادخل كلمة السر" });
            
            string token = _accountBll.UserLogin(username, password);
        DataTable dt  = _accountBll.Usernameemp(username);
            if (dt.Rows.Count == 0)
            {
                return NotFound(new { status = 500, Token = "", Message = "  اسم المستخدم غير صحيح" });
            }
            string name = dt.Rows[0][0].ToString();
            int usertid = Convert.ToInt32(dt.Rows[0][1].ToString());
            DataTable dtst = _accountBll.Usernammsettinges();
            if (dtst.Rows.Count == 0)
            {
                return NotFound(new { status = 500, Token = "", Message = "  اسم المستخدم غير صحيح" });
            }
            if (dtst.Rows[0][0] == DBNull.Value)
            {
                dtst.Rows[0][0] = false;
            }
            if (dtst.Rows[0][1] == DBNull.Value)
            {
                dtst.Rows[0][1] = false;
            }
            if (dtst.Rows[0][2] == DBNull.Value)
            {
                dtst.Rows[0][2] = false;
            }
            if (dtst.Rows[0][3] == DBNull.Value)
            {
                dtst.Rows[0][3] = false;
            }
            bool UseBrancheCodeColumn = Convert.ToBoolean(dtst.Rows[0][0]);
            bool UsePartitionCodeColumn = Convert.ToBoolean(dtst.Rows[0][1]);
            bool UseItemTaxInSales= Convert.ToBoolean(dtst.Rows[0][2]);
            bool UseItemTaxInPurch = Convert.ToBoolean(dtst.Rows[0][3]);
            if (dtst.Rows[0][4] == DBNull.Value)
            {
                dtst.Rows[0][4] = false;
            }
            if (dtst.Rows[0][5] == DBNull.Value)
            {
                dtst.Rows[0][5] = false;
            }
            if (dtst.Rows[0][6] == DBNull.Value)
            {
                dtst.Rows[0][6] = false;
            }


            bool PriceIncludTaxInSales= Convert.ToBoolean(dtst.Rows[0][4]);
            bool PriceIncludTaxInPurch= Convert.ToBoolean(dtst.Rows[0][5]);
            bool ActivateUnit2 = Convert.ToBoolean(dtst.Rows[0][6]);

            DataTable dtauth = _accountBll.Userauth(usertid);
            if (dtauth.Rows.Count == 0)
            {
                return NotFound(new { status = 500, Token = "", Message = "  اسم المستخدم غير صحيح" });
            }
            //string authcode = dtauth.Rows[0][0].ToString();


            if (token.IsEmpty()) return NotFound(resultDTO);

            resultDTO.data = token;
            resultDTO.Status = true;
            resultDTO.Name = name;
            resultDTO.UserId = usertid;
            resultDTO.UseBrancheCodeColumn = UseBrancheCodeColumn;
            resultDTO.UsePartitionCodeColumn = UsePartitionCodeColumn;
            resultDTO.UseItemTaxInSales = UseItemTaxInSales;
            resultDTO.UseItemTaxInPurch = UseItemTaxInPurch;
            resultDTO.PriceIncludTaxInSales = PriceIncludTaxInSales;
            resultDTO.PriceIncludTaxInPurch = PriceIncludTaxInPurch;
            resultDTO.ActivateUnit2 = ActivateUnit2;

            var dict = new Dictionary<string, dynamic>();



            foreach (DataRow dtRow in dtauth.Rows)
            {
              
                dict[(string)dtRow[0]] = dtRow[1];
                if((string)dtRow[0]== "Discs")
                {
                    dict[(string)dtRow[0]] = dtRow[2];

                }
                if ((string)dtRow[0] == "UsePricesInSals")
                {
                    dict[(string)dtRow[0]] = dtRow[2];

                }
                


            }
            resultDTO.authcode = dict;
            resultDTO.Message = "تم تسجيل الدخول بنجاح";
            return Ok(resultDTO);
        }

        [HttpGet , AllowAnonymous]
        public IActionResult GetAll()
        {
            var user =  _accountBll.GetAll();




            return Ok(user);
        }


    }
}
