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
    public class UserStoreController : BaseController
    {
        private readonly AccountBll accountBll;

        public UserStoreController(AccountBll accountBll)
        {
            this.accountBll = accountBll;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult userstor(int userid)
        {
            StoreDTO resultDTO = new StoreDTO();
            if (userid.IsEmpty())
                return NotFound(new { status = 500, Token = "", Message = "ادخل كود المستخدم" });
            DataTable dtcheckuser = accountBll.checkuser(userid);
            if(dtcheckuser.Rows.Count==0)
            {
                return NotFound(new { status = 404, Token = "", Message = "كود المستخدم غير صحيح" });
            }
            DataTable dtstor = accountBll.storuser(userid);
            string storid;
            string storename;

            if (dtstor.Rows.Count == 0)

            {
                storid = null;
                storename = null;
            }
            else
            {
                storid = dtstor.Rows[0][0].ToString();
                storename = dtstor.Rows[0][1].ToString();
            }
            //resultDTO.userid = userid;
            resultDTO.storid = storid;
            resultDTO.namestore = storename;
            resultDTO.Status = true;
            resultDTO.store = new List<Storessss>();
            if (storid == null)
            {
                DataTable dtallstor = accountBll.getallstore();
                foreach (DataRow allstores in dtallstor.Rows)
                {
                    resultDTO.store.Add(new Storessss() { Id = (int)allstores[0], Name = allstores[1].ToString() });
                }
                resultDTO.Message = "success";
            }
            else
            {
                DataTable dtallstor = dtstor; // هتغيره انه يجيب الستورز بتاعت اليوزر
                foreach (DataRow allstores in dtallstor.Rows)
                {
                    resultDTO.store.Add(new Storessss() { Id = (int)allstores[0], Name = allstores[1].ToString() });
                }
                resultDTO.Message = "success";
            }


            return Ok(resultDTO);
        }
    }
}