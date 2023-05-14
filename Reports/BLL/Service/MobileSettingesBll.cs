using DAL.Context;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using BLL.Extentions;

namespace BLL.Service
{
  public  class MobileSettingesBll
    {
        private readonly IRepository<MsMobSettings> mobilesettinges;
        private readonly IRepository<MsTerms> term;
        private readonly SmartERPStandardContext db;

        public MobileSettingesBll(IRepository<MsMobSettings> mobilesettinges, IRepository<MsTerms> term, SmartERPStandardContext db)
        {
            this.mobilesettinges = mobilesettinges;
            this.term = term;
            this.db = db;
        }

        public DataTable getbookidby(int  userid,byte tramtype,int storid)
        {
            var context = new SmartERPStandardContext();


            return (from mssettingmob in context.MsMobSettings

                    join term in context.MsTerms on mssettingmob.BookId equals term.BookId 

                    where mssettingmob.UserId == userid && mssettingmob.TermType==tramtype&& mssettingmob.StoreId==storid && term.IsDefaultTerm==true

                    select new { mssettingmob.BookId,term.TermId,term.TermName,term.IsDefaultTerm}).ToDataTable();


        }
        public DataTable checkbookid(int userid)
        {
            var context = new SmartERPStandardContext();


            return (from mssettingmob in context.MsMobSettings

                 

                    where mssettingmob.UserId == userid 

                    select new { mssettingmob.BookId, mssettingmob.UserId, mssettingmob.TermType, mssettingmob.StoreId }).ToDataTable();


        }
    }
}
