using BLL.Authentication;
using BLL.DTO;
using DAL.Context;
using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Static.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.Service
{
    public class QuantityAndPlacesOfItemsBll
    {
        private readonly IRepository<MsStores> _stores;
        private readonly IRepository<MsItemCategory> _itemCategory;
        private readonly IRepository<MsItemCard> _items;
        private readonly IRepository<MsPartition> _partition;

        private string language = "ar";

        public QuantityAndPlacesOfItemsBll(IRepository<MsStores> stores,IRepository<MsItemCategory> itemCategory,
            IRepository<MsItemCard> items, IRepository<MsPartition> partition)
        {
            _stores = stores;
            _itemCategory = itemCategory;
            _items = items;
            _partition = partition;
        }

        #region تحميل الفروع
        public ResultDTO GetBranchesSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = parametersDTO.lang == "ar" ? "خطا بالبيانات" : "Invalid data" };

            var tbl = _stores.Find(p => !p.DeletedAt.HasValue);
            if (tbl != null)
            {
                var data = tbl.Select(p => new { Id = p.StoreId, Name = (parametersDTO.lang == "ar" ? p.StoreDescA : p.StoreDescE) });
                resultDTO.data = data;
                resultDTO.Status = true;
                resultDTO.Message = parametersDTO.lang == "ar" ? "تم عرض البيانات بنجاح" : "Data is displayed correctly";
            }

            return resultDTO;
        }
        #endregion
         
        #region تحميل فئات الاصناف
        public ResultDTO GetCategoriesSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = parametersDTO.lang == "ar" ? "خطا بالبيانات" : "Invalid data" };
            var tbl = _itemCategory.Find(p => !p.DeletedAt.HasValue);
            if (tbl != null)
            {
                var data = tbl.Select(p => new { Code = p.ItemCatCode, Name = (parametersDTO.lang == "ar" ? p.ItemCatDescA : p.ItemCatDescE ) });
                resultDTO.data = data;
                resultDTO.Status = true;
                resultDTO.Message = parametersDTO.lang == "ar" ? "تم عرض البيانات بنجاح" : "Data is displayed correctly";
            }

            return resultDTO;
        }
        #endregion

        #region تحميل الاصناف
        public ResultDTO GetItemsSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = parametersDTO.lang == "ar" ? "خطا بالبيانات" : "Invalid data" };
            var tbl = _items.Find(p => !p.DeletedAt.HasValue);
            if (tbl != null)
            {
                var data = tbl.Select(p => new { Code = p.ItemCode, Name = (parametersDTO.lang == "ar" ? p.ItemDescA : p.ItemDescE ) });
                resultDTO.data = data;
                resultDTO.Status = true;
                resultDTO.Message = parametersDTO.lang == "ar" ? "تم عرض البيانات بنجاح" : "Data is displayed correctly";
            }

            return resultDTO;
        }
        #endregion

        #region تحميل المخازن
        public ResultDTO GetPartitionsSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = parametersDTO.lang == "ar" ? "خطا بالبيانات" : "Invalid data" };
            var tbl = _partition.Find(p => !p.DeletedAt.HasValue);
            if (tbl != null)
            {
                var data = tbl.Select(p => new { Code = p.PartCode, Name = (parametersDTO.lang == "ar" ? p.PartDescA : p.PartDescE ) });
                resultDTO.data = data;
                resultDTO.Status = true;
                resultDTO.Message = parametersDTO.lang == "ar" ? "تم عرض البيانات بنجاح" : "Data is displayed correctly";
            }

            return resultDTO;
        }
        #endregion

        #region الحصول على التقرير
        public ResultDTO GetQuantityAndPlacesOfItemsRpt(RPTQuantityAndPlacesOfItemsDTO dTO)
        {
            language = dTO.lang;
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = language == "ar" ? "خطا بالبيانات" : "Invalid data" };

            List<MS_Rpt_ItemCardQtyListPart_Result> rPTAccounts = null;
            try
            {
                SqlParameter[] parameters = new[] {
                   new SqlParameter("StoreId", dTO.StoreId),
                    new SqlParameter("ItemCodeFrom", dTO.ItemCode),
                    new SqlParameter("ItemCodeTo", dTO.ItemCode),
                    new SqlParameter("PartFrom", dTO.PartitionCode),
                    new SqlParameter("PartTo", dTO.PartitionCode),
                    new SqlParameter("fromQtyPart", dTO.fromQtyPart),
                    new SqlParameter("toQtyPart", dTO.toQtyPart),
                    new SqlParameter("fromQtyNote", dTO.fromQtyNote),
                    new SqlParameter("toQtyNote", dTO.toQtyNote),
                    new SqlParameter("ItemCatFrom", dTO.ItemCatCode),
                    new SqlParameter("ItemCatTo", dTO.ItemCatCode),
                    new SqlParameter("LotNumberExpiry", dTO.LotNumberExpiry),
                };

                rPTAccounts = _stores.ExecuteStoredProcedure<MS_Rpt_ItemCardQtyListPart_Result>("MS_Rpt_ItemCardQtyListPart", parameters).ToList();
            }
            catch (Exception ex)
            {
                resultDTO.Message = resultDTO.Message = ex?.Message + "\n \n " + ex.InnerException?.Message;
                return resultDTO;
            }

            resultDTO.data = GertResult(rPTAccounts, dTO.StoreId);
            resultDTO.Status = true;
            resultDTO.Message = language == "ar" ? "تم عرض البيانات بنجاح" : "Data is displayed correctly";
            return resultDTO;
        }

        public List<Stores> GertResult(List<MS_Rpt_ItemCardQtyListPart_Result> rPTAccounts,int ? storeId)
        {
            int decCount = 3;
            List<Stores> res = rPTAccounts.GroupBy(x => x.StoreId).Select(group => new Stores
                {
                    key = group.Key,
                    StoreDesc = storeId.HasValue ? group.FirstOrDefault().StoreDescA : (language == "ar" ? "الكــــل" : "All"),
                    ItemsInBranchs = GertBranchsOfStore(group.Select(x=>x).ToList(), decCount)
            }).ToList();

            return res;
        }

        public List<BranchsOfStore> GertBranchsOfStore(List<MS_Rpt_ItemCardQtyListPart_Result> rPTAccounts, int decCount)
        {
            List<BranchsOfStore> branchs = new List<BranchsOfStore>();
            List<string> ItemsCatCode = rPTAccounts.Select(x => x.ItemCatCode).Distinct().ToList();

            foreach (string item in ItemsCatCode)
            {
                List<MS_Rpt_ItemCardQtyListPart_Result> rPTAccount = rPTAccounts.Where(x => x.ItemCatCode == item).ToList();
                branchs.Add(new BranchsOfStore
                {
                    Items = rPTAccount.Select(x => new QuantityAndPlacesOfItemsVM
                    {
                        StoreId = x.StoreId,
                        StoreDescA = x.StoreId.HasValue ? x.StoreDescA : (language == "ar" ? "الكــــل" : "All"),
                        ItemCatCode = x.ItemCatCode,
                        ItemCatDescA = x.ItemCatDescA,
                        ItemCode = x.ItemCode,
                        ItemDescA = x.ItemDescA,
                        ItemDescE = x.ItemDescE,
                        PartDescA = x.PartDescA,
                        QtyInNotebook = decimal.Round(x.QtyInNotebook.Value, decCount),
                        QtyPartiation = decimal.Round(x.QtyPartiation.Value, decCount)
                    }).ToList(),
                    BranchDesc = rPTAccount.FirstOrDefault().ItemCatDescA
                });
            }

            return branchs;
        }

        public string GetStoreName(QuantityAndPlacesOfItemsVM rPTAccount)
        {
            string StoreName = string.Empty;
            if (rPTAccount == null) return StoreName;

            if (!rPTAccount.StoreId.HasValue) StoreName = language== "ar" ? "الكــــل" : "All";
            else StoreName = rPTAccount.StoreDescA;
            return StoreName;
        }

       
        #endregion
    }
}
