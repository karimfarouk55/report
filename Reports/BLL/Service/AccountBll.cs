using BLL.Authentication;
using BLL.DTO;
using BLL.Extentions;
using DAL.Context;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace BLL.Service
{
    public class AccountBll
    {
        private readonly IRepository<GUsers> _user;
        private readonly IRepository<HrEmployees> emp;
        private readonly IRepository<MsSettings> settines;
        private readonly IRepository<MsUserAuthentications> userauth;
        private readonly IJwtAuthentication _jwtAuthentication;
        public readonly  SmartERPStandardContext _db;

        public AccountBll(IJwtAuthentication jwtAuthentication, IRepository<GUsers> user, IRepository<HrEmployees> emp, IRepository<MsSettings> settines, IRepository<MsUserAuthentications> userauth, IRepository<MsStores> store, SmartERPStandardContext db)
        {
            _jwtAuthentication = jwtAuthentication;
            _user = user;
            this.emp = emp;
            this.settines = settines;
            this.userauth = userauth;
            _db = db;
        } 

        public string UserLogin(string username, string password)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = "خطا بالبيانات" };
            GUsers user = _user.Find(x => x.UserName.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();

            if (user != null)
                return _jwtAuthentication.Authenticate(user.UserId + "");

            return "";
        }





        public IEnumerable<GUsers> GetAll()
        {
            var users =  _db.GUsers.ToList();
            return users;
        }


        public DataTable Usernameemp(string UserName)
        {
        
                return (from emp in _db.HrEmployees
                               join useres in _db.GUsers on emp.EmpId equals useres.EmpId
                             
                               where useres.UserName == UserName
                               select new  { emp.Name1, useres.UserId}).ToDataTable();


        }
        public DataTable storuser(int userid)
        {
            

            return (from stor in _db.MsStores
                    join useres in _db.GUsers on stor.StoreId equals useres.StoreId

                    where useres.UserId == userid
                    select new { stor.StoreId,stor.StoreDescA }).ToDataTable();


        }
        public DataTable checkuser(int userid)
        {


            return (from user in _db.GUsers
                  

                    where user.UserId == userid
                    select new { user.UserName,userid }).ToDataTable();


        }
        public DataTable getallstore()
        {

            return (from stor in _db.MsStores
                    

                 
                    select new { stor.StoreId, stor.StoreDescA }).ToDataTable();


        }

        public DataTable Usernammsettinges()
        {
            
            //return
            var settinges =
                   (from setting in _db.MsSettings


                        //where useres.UserName == UserName
                    select new { setting.UseBrancheCodeColumn, setting.UsePartitionCodeColumn, setting.UseItemTaxInSales, setting.UseItemTaxInPurch, setting.PriceIncludTaxInSales, setting.PriceIncludTaxInPurch ,setting.ActivateUnit2}).Take(1).ToDataTable();
            return settinges;


        }

        public DataTable Userauth(int userid)
        {

            return (from auth in _db.MsUserAuthentications
                    //join useres in _db.GUsers on auth.UserId equals useres.UserId

                    where auth.UserId == userid && (auth.AuthCode== "MinusNoteQty"  || auth.AuthCode == "ShoCustBlncs" || auth.AuthCode == "ShoVendBlncs" || auth.AuthCode == "ShowDisC" || auth.AuthCode == "dateChange" 
                    || auth.AuthCode == "SeeItemCost"  || auth.AuthCode == "SearchCurrentStor"|| auth.AuthCode == "UsePPolicy" || auth.AuthCode == "SeeSalesProfit" 
                    || auth.AuthCode == "ChangeSalePrice"  || auth.AuthCode == "SaleUnderCost"  || auth.AuthCode == "itemDiscPerLine"  || auth.AuthCode == "CanSaleReservQty"
                     || auth.AuthCode == "CanSeeSalesCommission"  || auth.AuthCode == "CanSeeRecCommission"  || auth.AuthCode == "BounusItem"|| auth.AuthCode == "SalInvChangePricList"
                      || auth.AuthCode == "UsePricesInSals"|| auth.AuthCode == "UsePricesInSals"  || auth.AuthCode == "Discs" )
                    select new { auth.AuthCode,auth.Authinticated,auth.AuthDesc}).ToDataTable();


        }
        public class foo 
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }


    }
}
