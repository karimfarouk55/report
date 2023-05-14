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
    public class MobileSettingesController : BaseController
    {
        private readonly MobileSettingesBll mobileSettingesBll;

        public MobileSettingesController(MobileSettingesBll mobileSettingesBll)
        {
            this.mobileSettingesBll = mobileSettingesBll;
        }


        [HttpPost, AllowAnonymous]
        public IActionResult getbookidcontroller(int userid, byte termtype, int storid)
        {
            mobilesettingesDTO mobilesettingesDTO = new mobilesettingesDTO();
            if (userid.IsEmpty())
                return NotFound(new { status = 500, Token = "", Message = "ادخل كود المستخدم" });

            else if (termtype.IsEmpty())
                return NotFound(new { status = 500, Token = "", Message = "ادخل نوع الدفتر" });

            else if (storid.IsEmpty())
                return NotFound(new { status = 500, Token = "", Message = "ادخل الفرع " });

            DataTable dt = mobileSettingesBll.getbookidby(userid, termtype, storid);


            DataTable dtchekbookid = mobileSettingesBll.checkbookid(userid);

            if (dtchekbookid.Rows.Count == 0)
            {
                return NotFound(new { status = 500, Token = "", Message = "  راجع اسم المستخدم" });

            }


            if (Convert.ToInt32(dtchekbookid.Rows[0][0]) == 0)
            {
                return NotFound(new { status = 500, Token = "", Message = "  لايوجد دفتر" });

            }
            if (Convert.ToInt32(dtchekbookid.Rows[0][2]) == 0)
            {
                return NotFound(new { status = 500, Token = "", Message = "  لايوجد  نوع دفتر" });

            }

          

            if (Convert.ToInt32(dtchekbookid.Rows[0][3]) == 0)
            {
                return NotFound(new { status = 500, Token = "", Message = "  لايوجد مخزن" });

            }





            if (dt.Rows.Count == 0)
            {
                return NotFound(new { status = 500, Token = "", Message = "  لايوجد بيانات " });
            }

            if (Convert.ToInt32(dt.Rows[0][0] )== 0)
            {
                return NotFound(new { status = 500, Token = "", Message = "  لايوجد دفتر " });
            }

            int name = Convert.ToInt32(dt.Rows[0][0]);
            string termid = dt.Rows[0][1].ToString();
            string termname = dt.Rows[0][2].ToString();
            bool termdefualt = Convert.ToBoolean(dt.Rows[0][3]); 
            //DataTable dtchekbookid = mobileSettingesBll.checkbookid( userid);



            //if (Convert.ToInt32(dtchekbookid.Rows[0][0]) == 0)
            //{
            //    return NotFound(new { status = 500, Token = "", Message = "  لايوجد دفتر" });

            //}
            //if (Convert.ToInt32(dtchekbookid.Rows[0][0]) == 0)
            //{
            //    return NotFound(new { status = 500, Token = "", Message = "  لايوجد دفتر" });

            //}

            //if (Convert.ToInt32(dtchekbookid.Rows[0][0]) == 0)
            //{
            //    return NotFound(new { status = 500, Token = "", Message = "  لايوجد دفتر" });

            //}

            //if (dtchekbookid.Rows.Count == 0)
            //{
            //    return NotFound(new { status = 500, Token = "", Message = "  لايوجد دفتر" });

            //}
            //string token = mobileSettingesBll.(username, password);


            //DataTable dtchekbookid = mobileSettingesBll.checkbookid(name, userid);

            //if (dtchekbookid.Rows.Count == 0)
            //{
            //    return NotFound(new { status = 500, Token = "", Message = "  لايوجد دفتر" });

            //}

            //string authcode = dtauth.Rows[0][0].ToString();




            //resultDTO.data = token;
            mobilesettingesDTO.Status = true;
            mobilesettingesDTO.bookid = name;
            mobilesettingesDTO.termid = termid;
            mobilesettingesDTO.termname = termname;
            mobilesettingesDTO.termisdefualt = termdefualt;








            return Ok(mobilesettingesDTO);
        }


    }
}
