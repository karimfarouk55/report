using BLL.Authentication;
using BLL.DTO;
using DAL.Context;
using DAL.Models;
using DAL.Repository;
using Microsoft.Identity.Client.Extensions.Msal;
using Static.VM;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Service
{
    public class ItemsBll
    {
        private readonly IRepository<MsItemCard> _repository;
        //private readonly IRepository<MsItemVendors> _itemVendors;
        //private readonly IRepository<MsVendor> _vendor;
        //private readonly IRepository<MsItemImages> _ItemImages;
        private SmartERPStandardContext db;

        public ItemsBll(IRepository<MsItemCard> repository , SmartERPStandardContext _db)
        {
            _repository = repository;
            db = _db;
         
        }

        public ResultDTO GetAllItems(int? Page_No, int? Size_No)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = "خطا بالبيانات" };
            try
            {
                int Size_Of_Page = (Size_No ?? 9);
                int No_Of_Page = (Page_No ?? 1);

                List<VendorVM> data = _repository.GetAll().ToList().Select(p => new VendorVM
                {
                    ItemCardId = p.ItemCardId,
                    itemcode = p.ItemCode,
                    itemname = p.ItemDescA,
                    Qty = p.QtyInBox,
                    Price = p.FirstPrice,
                    Price2 = p.SecandPrice,
                    Price3 = p.ThirdPrice,
                    CoastAVG = p.CoastAverage,
                    Vendors = GetVendors(p.ItemCardId),
                    image = GetImages(p.ItemCardId),
                }).Skip((No_Of_Page - 1) * Size_Of_Page).Take(Size_Of_Page).ToList();

                resultDTO.Page_No = No_Of_Page;
                resultDTO.Size_No = Size_Of_Page;
                resultDTO.data = data;
                resultDTO.Status = true;
                resultDTO.Message = "تم عرض البيانات بنجاح";
                return resultDTO;
            }
            catch(Exception ex)
            {
                return resultDTO;
            }
        }

        public object GetVendors(int ItemCardId)
        {
            using (db = new SmartERPStandardContext())
            {
                var vendors = (from ItemVendors in db.MsItemVendors
                               join Vendor in db.MsVendor on ItemVendors.VendorId equals Vendor.VendorId
                               join ItemCard in db.MsItemCard on ItemVendors.ItemCardId equals ItemCard.ItemCardId
                               where ItemVendors.ItemCardId == ItemCardId
                               select new { VendorCode = Vendor.VendorCode, VendorDescA = Vendor.VendorDescA }).ToList();
                return vendors;
            }
        }

        public string GetImages(int ItemCardId)
        {
            using (db = new SmartERPStandardContext())
            {
                MsItemImages Item = db.MsItemImages.FirstOrDefault(v => v.ItemCardId == ItemCardId);
                string image = string.Empty;
                if (Item != null)
                    image = Item.Image != null ? Item.Image.ToString().Replace('"', ' ').Trim() : null;
                return image;
            }
        }

        public ResultDTO barcode(string qr)
        {
            ResultDTO resultDTO = new ResultDTO() { Status = false, Message = "خطا بالبيانات" };
            try
            {
                VendorVM data = _repository.Find(x => x.ItemCode == qr).Select(p => new VendorVM
                {
                    ItemCardId = p.ItemCardId,
                    itemcode = p.ItemCode,
                    itemname = p.ItemDescA,
                    Qty = p.QtyInBox,
                    Price = p.FirstPrice,
                    Price2 = p.SecandPrice,
                    Price3 = p.ThirdPrice,
                    CoastAVG = p.CoastAverage,
                    Vendors = GetVendors(p.ItemCardId),
                    image = GetImages(p.ItemCardId),
                }).FirstOrDefault();

                resultDTO.data = data;
                resultDTO.Status = true;
                resultDTO.Message = "تم عرض البيانات بنجاح";
                return resultDTO;
            }
            catch
            {
                return resultDTO;
            }
        }

      

        public ItemNameDto GetItems(int? Page_No, int? Size_No)
        {
            ItemNameDto itmDto = new ItemNameDto();
            int Size_Of_Page = (Size_No ?? 9);
            int No_Of_Page = (Page_No ?? 1);

            var ItemsName = (from item in db.MsItemCard
                             join img in db.MsItemImages
                             on item.ItemCardId equals img.ItemCardId
                             
                            select new ItemNameDto
                            {
                                ItemCardId=item.ItemCardId,
                                ItemDescA = item.ItemDescA,
                                ItemDescE = item.ItemDescE,
                                ItemCode = item.ItemCode,
                                ItemType = (int)item.ItemType,
                                IsSerialItem = (bool)item.IsSerialItem,
                                IsExpir = (bool)item.IsExpir,
                                IsDimension = (bool)item.IsDimension,
                                IsAttributeItem = (bool)item.IsAttributeItem,
                                IsCommisionPercent = (bool)item.IsCommisionPercent,
                                TaxesId1 = (int)item.TaxesId1,
                                Tax1Rate = (int)item.Tax1Rate,
                                TaxesId2 = (int)item.TaxesId2,
                                Tax2Rate= (decimal)item.Tax2Rate,
                                Tax3Rate= (int)item.Tax3Rate,
                                TaxesId3 = (int)item.TaxesId3,
                                Tax1ForPurch = (bool)item.Tax1ForPurch,
                                Tax2ForPurch= (bool)item.Tax2ForPurch,
                                Tax3ForPurch= (bool)item.Tax3ForPurch,
                                Tax1ForSale = (bool)item.Tax1ForSale,
                                Tax2ForSale= (bool)item.Tax2ForSale,
                                Tax3ForSale= (bool)item.Tax3ForSale,
                                Tax1PlusOrMinus = (bool)item.Tax1PlusOrMinus,
                                Tax2PlusOrMinus= (bool)item.Tax2PlusOrMinus,
                                Tax3PlusOrMinus = (bool)item.Tax3PlusOrMinus,
                                Tax1IsAccomulative = (bool)item.Tax1IsAccomulative,
                                Tax2IsAccomulative= (bool)item.Tax2IsAccomulative,
                                Tax3IsAccomulative= (bool)item.Tax3IsAccomulative,
                                Tax1Style= (int)item.Tax1Style,
                                Tax2Style = (int)item.Tax2Style,
                                Tax3Style= (int)item.Tax3Style,
                                
                                imagePath=img.ImgPath
                            }).Skip((No_Of_Page - 1) * Size_Of_Page).Take(Size_Of_Page);
            itmDto.Page_No = No_Of_Page;
            itmDto.Size_No = Size_Of_Page;
            itmDto.data = ItemsName;

            return itmDto;
        }


        public ItemNameDto GetItemscode(string code)
        {
            ItemNameDto itmDto = new ItemNameDto();


            var ItemsName = (from item in db.MsItemCard
                             join img in db.MsItemImages
                             on item.ItemCardId equals img.ItemCardId
                             where item.ItemCode == code
                             select new ItemNameDto
                             {
                                 ItemCardId = item.ItemCardId,
                                 ItemDescA = item.ItemDescA,
                                 ItemDescE = item.ItemDescE,
                                 ItemCode = item.ItemCode,
                                 ItemType = (int)item.ItemType,
                                 IsSerialItem = (bool)item.IsSerialItem,
                                 IsExpir = (bool)item.IsExpir,
                                 IsDimension = (bool)item.IsDimension,
                                 IsAttributeItem = (bool)item.IsAttributeItem,
                                 IsCommisionPercent = (bool)item.IsCommisionPercent,
                                 TaxesId1 = (int)item.TaxesId1,
                                 Tax1Rate = (int)item.Tax1Rate,
                                 TaxesId2 = (int)item.TaxesId2,
                                 Tax2Rate = (decimal)item.Tax2Rate,
                                 Tax3Rate = (int)item.Tax3Rate,
                                 TaxesId3 = (int)item.TaxesId3,
                                 Tax1ForPurch = (bool)item.Tax1ForPurch,
                                 Tax2ForPurch = (bool)item.Tax2ForPurch,
                                 Tax3ForPurch = (bool)item.Tax3ForPurch,
                                 Tax1ForSale = (bool)item.Tax1ForSale,
                                 Tax2ForSale = (bool)item.Tax2ForSale,
                                 Tax3ForSale = (bool)item.Tax3ForSale,
                                 Tax1PlusOrMinus = (bool)item.Tax1PlusOrMinus,
                                 Tax2PlusOrMinus = (bool)item.Tax2PlusOrMinus,
                                 Tax3PlusOrMinus = (bool)item.Tax3PlusOrMinus,
                                 Tax1IsAccomulative = (bool)item.Tax1IsAccomulative,
                                 Tax2IsAccomulative = (bool)item.Tax2IsAccomulative,
                                 Tax3IsAccomulative = (bool)item.Tax3IsAccomulative,
                                 Tax1Style = (int)item.Tax1Style,
                                 Tax2Style = (int)item.Tax2Style,
                                 Tax3Style = (int)item.Tax3Style,

                                 imagePath = img.ImgPath
                             });

            itmDto.data = ItemsName;

            return itmDto;
        }

        public IEnumerable<TaxesDto> GetTaxes()
        {
            var TaxesItem = from itm in db.MsTaxes
                            select new TaxesDto
                            {
                                TaxesId = itm.TaxesId,
                                TaxCode = itm.TaxCode,
                                TaxNameA = itm.TaxNameA,
                                TaxNameE = itm.TaxNameE,
                                TaxRate = (decimal)itm.TaxRate,
                                TaxStyle= (int)itm.TaxStyle,
                                IsAccomulative = (bool)itm.IsAccomulative,
                                PlusOrMinus= (bool)itm.PlusOrMinus
                            };
            return TaxesItem;
             
        }

        public IEnumerable<ItemByIdDto> ItemsByID(int id)
        {
           
            var items = from itmCard in db.MsItemCard
                        join itmUnit in db.MsItemUnit on itmCard.ItemCardId equals itmUnit.ItemCardId 
                        join img in db.MsItemImages on itmCard.ItemCardId equals img.ItemCardId 
                        where itmCard.ItemCardId == id 
                        select new ItemByIdDto
                        {
                            UnitNam = itmUnit.UnitNam,
                            UnitNamE = itmUnit.UnitNameE,
                            IsDefaultPurchas = (bool)itmUnit.IsDefaultPurchas,
                            IsDefaultSale= (bool)itmUnit.IsDefaultSale,
                            Price1= (decimal)itmUnit.Price1,
                            Price2= (decimal)itmUnit.Price2,
                            Price3= (decimal)itmUnit.Price3,
                            Price4= (decimal)itmUnit.Price4,
                            Price5= (decimal)itmUnit.Price5,
                            Price6= (decimal)itmUnit.Price6,
                            Price7= (decimal)itmUnit.Price7,
                            Price8= (decimal)itmUnit.Price8,
                            Price9= (decimal)itmUnit.Price9,
                            Price10= (decimal)itmUnit.Price10,
                            Quantity1= (decimal)itmUnit.Quantity1,
                            Quantity2= (decimal)itmUnit.Quantity2,
                            Quantity3= (decimal)itmUnit.Quantity3,
                            Quantity4= (decimal)itmUnit.Quantity4,
                            Quantity5= (decimal)itmUnit.Quantity5,                            
                            UnitCode=itmUnit.UnitCode,
                            UnittRate= (decimal)itmUnit.UnittRate,
                        };
            return items;
        }

        public IEnumerable<ItemSerialAndPartitionDto> GetSerialAndpartition(int id)
        {
            var items = from itmSerial in db.MsItemSerials
                        join itmPart in db.MsItemPartition
                        on itmSerial.ItemCardId equals itmPart.ItemCardId join part in db.MsPartition on itmPart.StorePartId equals part.StorePartId
                        where itmSerial.ItemCardId == id && itmSerial.IsInOrOut == true
                        select new ItemSerialAndPartitionDto
                        {
                            ItemSerialId = itmSerial.ItemSerialId,
                            SRNo1 = itmSerial.Srno1,
                            Color= itmSerial.Color,
                            Height= (decimal)itmSerial.Height,
                            PartCode=part.PartCode,
                            PartDescA= part.PartDescA,
                            PartDescE=part.PartDescE,
                           StorePartId= part.StorePartId,
                           CoastAverage= (decimal)itmPart.CoastAverage,
                           QtyInNotebook = (decimal)itmPart.QtyInNotebook,
                           ReservedQty = (decimal)itmPart.ReservedQty   
                        };

            return items;
        }

        public IEnumerable<GetPartitionAndStoreDto> GetPartitionWithStores(int id , int storeid)
        {
            var items = from Partition in db.MsPartition
                        join itmPartition in db.MsItemPartition
                        on Partition.StorePartId equals itmPartition.StorePartId
                        join store in db.MsStores on itmPartition.StoreId equals store.StoreId
                        where itmPartition.ItemCardId == id
                        select new GetPartitionAndStoreDto
                        {
                            PartCode = Partition.PartCode,
                            PartDescA = Partition.PartDescA,
                            PartDescE = Partition.PartDescE,
                            StorePartId = Partition.StorePartId,
                            QtyInNotebook = (decimal)itmPartition.QtyInNotebook,
                            CoastAverage = (decimal)itmPartition.CoastAverage,
                            ReservedQty = (decimal)itmPartition.ReservedQty,
                            StoreId = store.StoreId,
                            StoreCode = store.StoreCode,
                            StoreDescA = store.StoreDescA,
                            StoreDescE = store.StoreDescE
                        };

            var st = from part in db.MsPartition
                     where part.StoreId == storeid
                     select new GetPartitionAndStoreDto
                     {
                         PartCode = part.PartCode,
                         PartDescA = part.PartDescA,
                         PartDescE = part.PartDescE,
                         StoreId = (int)part.StoreId,
                         StorePartId = part.StorePartId
                         
                     };


            if (items.Any())
            {
                return items;
            }
            return st;

        }



    }
}
