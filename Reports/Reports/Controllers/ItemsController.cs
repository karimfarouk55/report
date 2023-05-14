using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure;
using BLL.DTO;
using BLL.Service;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Static.Helper;
using Static.VM;

namespace Reports.Controllers
{
    public class ItemsController : BaseController
    {
        private readonly ItemsBll _itemsBll;
        private readonly SmartERPStandardContext _db;

        public ItemsController(ItemsBll itemsBll , SmartERPStandardContext db)
        {
            _itemsBll = itemsBll;
            _db = db;
        }

        [HttpPost, AllowAnonymous]
        public ResultDTO GetAllItems(int? Page_No, int? Size_No)
        {
            //HttpContext.Current.Server.ScriptTimeout = 2000;
            ResultDTO resultDTO = _itemsBll.GetAllItems(Page_No, Size_No);
            return resultDTO;
        }

        [HttpGet]
        public IEnumerable<TaxesDto> GetTaxes()
        {
            return _itemsBll.GetTaxes();
        }
        
        [HttpPost, AllowAnonymous]
        public ResultDTO barcode(string qr)
        {
            ResultDTO resultDTO = _itemsBll.barcode(qr);
            return resultDTO;
        }




        [HttpPost, AllowAnonymous]
        public ItemNameDto GetItems(int page_number, int page_size)
        {
            return _itemsBll.GetItems(page_number,page_size);
        }

        [HttpPost, AllowAnonymous]
        public ItemNameDto GetItemsbarcode(string code)
        {
            return _itemsBll.GetItemscode(code);
        }

        [HttpPost, AllowAnonymous]
        public IEnumerable<ItemByIdDto> GetItemsById(int CardItemId)
        {
            return _itemsBll.ItemsByID(CardItemId);
        }

        [HttpPost,AllowAnonymous]
        public IEnumerable<ItemSerialAndPartitionDto> GetItemSerialAndPartitions(int ItemCardId)
        {
            return _itemsBll.GetSerialAndpartition(ItemCardId);
        }

        

        [HttpPost, AllowAnonymous]
        public IEnumerable<GetPartitionAndStoreDto> GetPartitionWithStores(int ItemCardId, int storeid)
        {
            return _itemsBll.GetPartitionWithStores(ItemCardId , storeid);

        }

        [HttpPost, AllowAnonymous]
        public IActionResult TestHeader([FromBody] HeaderDtoTest dto)
        {
            var salesInvoice = new MsSalesInvoice
            {

                BookId = dto.Header_BookId,
                TrNo = dto.Header_TrNo,
                TermId = dto.Header_TermId,
                CurrencyId = dto.Header_CurrencyId,
                CustomerId = dto.Header_CustomerId,
                RectSourceType = (byte)dto.Header_RectSourceType,
                Rate = dto.Header_Rate,
                NotPaid = dto.NotPaid,
                CreatedAt = dto.Header_CreatedAt,
                InvTotal = dto.Header_InvTotal,
                DiscAmount = dto.Header_DiscAmount,
                DiscPercent = dto.Header_DiscPercent,
                DiscAmount2 = dto.Header_DiscAmount2,
                DiscPercent2 = dto.Header_DiscPercent2,
                TotalItemTax1 = dto.Header_TotalItemTax1,
                TotalItemTax2 = dto.Header_TotalItemTax2,
                TotalItemTax3 = dto.Header_TotalItemTax3
                //TaxValue1 = dto.Header_TaxValue1,
                //TaxValue2 = dto.Header_TaxValue2,
                //TaxValue3 = dto.Header_TaxValue3,
                //TaxesId1 = dto.Header_TaxesId1,
                //TaxesId2 = dto.Header_TaxesId2,
                //TaxesId3 = dto.Header_TaxesId3,
                //PriceAfterTax = dto.Header_PriceAfterTax,
                //NetPrice = dto.Header_NetPrice,
                //PaidPrice = dto.Header_PaidPrice,
                //PaidPriceVisa = dto.Header_PaidPriceVisa,
                //BankTransfer = dto.Header_BankTransfer

            };

            _db.MsSalesInvoice.Add(salesInvoice);
            _db.SaveChanges();
            ResultHeaderAndDetialDto res = new ResultHeaderAndDetialDto();
            res.Invid = salesInvoice.InvId;
            res.Message = "تم أضافه الداتا بنجاح";

            return Ok(res);

        }


        [HttpPost, AllowAnonymous]
        public IActionResult CreateHeader([FromBody]HeaderDto dto)
        {
            var salesInvoice = new MsSalesInvoice
            {
                BookId = dto.Header_BookId,
                TrNo = dto.Header_TrNo,
                TermId = dto.Header_TermId,
                CurrencyId = dto.Header_CurrencyId,
                CustomerId = dto.Header_CustomerId,
                RectSourceType = (byte)dto.Header_RectSourceType,
                Rate = dto.Header_Rate,
                NotPaid = dto.NotPaid,
                CreatedBy = dto.Header_CreatedBy,
                CreatedAt = dto.Header_CreatedAt,
                InvTotal = dto.Header_InvTotal,
                DiscAmount = dto.Header_DiscAmount,
                DiscPercent = dto.Header_DiscPercent,
                DiscAmount2 = dto.Header_DiscAmount2,
                DiscPercent2 = dto.Header_DiscPercent2,
                TotalItemTax1 = dto.Header_TotalItemTax1,
                TotalItemTax2 = dto.Header_TotalItemTax2,
                TotalItemTax3 = dto.Header_TotalItemTax3,
                TaxValue1 = dto.Header_TaxValue1,
                TaxValue2 = dto.Header_TaxValue2,
                TaxValue3 = dto.Header_TaxValue3,
                TaxesId1 = dto.Header_TaxesId1,
                TaxesId2 = dto.Header_TaxesId2,
                TaxesId3 = dto.Header_TaxesId3,
                PriceAfterTax = dto.Header_PriceAfterTax,
                NetPrice = dto.Header_NetPrice,
                PaidPrice = dto.Header_PaidPrice,
                PaidPriceVisa = dto.Header_PaidPriceVisa,
                BankTransfer = dto.Header_BankTransfer
            };

            _db.MsSalesInvoice.Add(salesInvoice);
            _db.SaveChanges();
            ResultHeaderAndDetialDto res = new ResultHeaderAndDetialDto();
            res.Invid = salesInvoice.InvId;
            res.Message = "تم أضافه الداتا بنجاح";

            return Ok(res);

        }

        [HttpPost]
        public IActionResult CreateDetail([FromBody]List<DetailDto> dto)
        {

            var InvD = 0;
            foreach (var item in dto)
            {
               
                _db.MsSalesInvoiceItemCard.Add(new MsSalesInvoiceItemCard()
                {
                    InvId = item.InvId,
                    ItemCardId = item.ItemCardId,
                    Price = item.Price,
                    //PriceAfterRate = item.PriceAfterRate,
                    QtyBeforRate = item.QtyBeforRate,
                    //Quantity = item.Quantity,
                    UnitId = item.UnitId,
                    UnitRate = item.UnitRate,
                    StoreId = item.StoreId,
                    StorePartId = item.StorePartId,
                    DisPercent = item.DisPercent,
                    DisAmount = item.DisAmount,
                    Tax1Percent = item.Tax1Percent,
                    Tax2Percent = item.Tax2Percent,
                    Tax3Percent = item.Tax3Percent,
                    TaxesId1 = item.Detail_TaxesId1,
                    TaxesId2 = item.Detail_TaxesId2,
                    TaxesId3 = item.Detail_TaxesId3,
                    Tax1IsAccomulative = item.Tax1IsAccomulative,
                    Tax2IsAccomulative = item.Tax2IsAccomulative,
                    Tax3IsAccomulative = item.Tax3IsAccomulative
                });
                InvD = item.InvId;
            }
            _db.SaveChanges();
            ResultHeaderAndDetialDto res = new ResultHeaderAndDetialDto();
            res.Invid = InvD;            
            res.Message = "تم أضافه الداتا بنجاح";
            return Ok(res);
        }

        [HttpPost, AllowAnonymous]
        public IActionResult CreateOrderHeader(OrderHeaderDto dto)
        {
            var salesOrder = new MsSalesOrder
            {
                BookId = dto.Header_BookId,
                TrNo = dto.Header_TrNo,
                TermId = dto.Header_TermId,
                CurrencyId = dto.Header_CurrencyId,
                CustomerId = dto.Header_CustomerId,
                RectSourceType = (byte)dto.Header_RectSourceType,
                Rate = dto.Header_Rate,
                CreatedBy = dto.Header_CreatedBy,
                CreatedAt = dto.Header_CreatedAt,
                InvTotal = dto.Header_InvTotal,
                DiscAmount = dto.Header_DiscAmount,
                DiscPercent = dto.Header_DiscPercent,
                DiscAmount2 = dto.Header_DiscPercent2,
                DiscPercent2 = dto.Header_DiscPercent2,
                TotalItemTax1 = dto.Header_TotalItemTax1,
                TotalItemTax2 = dto.Header_TotalItemTax2,
                TotalItemTax3 = dto.Header_TotalItemTax3,
                TaxValue1 = dto.Header_TaxValue1,
                TaxValue2 = dto.Header_TaxValue2,
                TaxValue3 = dto.Header_TaxValue3,
                TaxesId1 = dto.Header_TaxesId1,
                TaxesId2 = dto.Header_TaxesId2,
                TaxesId3 = dto.Header_TaxesId3,
                PriceAfterTax = dto.Header_PriceAfterTax,
                NetPrice = dto.Header_NetPrice,
                PaidPrice = dto.Header_PaidPrice,
                PaidPriceVisa = dto.Header_PaidPriceVisa
            };

            _db.MsSalesOrder.Add(salesOrder);
            _db.SaveChanges();
            OrderResultHeaderAndDetailDto res = new OrderResultHeaderAndDetailDto();
            res.SalesOrderId = salesOrder.SalesOrderId;
            res.Message = "تم أضافه الداتا بنجاح";

            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateOrderDetail([FromBody]List<OrderDetailDto> dto)
        {
            var OrderId = 0;
            foreach (var item in dto)
            {
                _db.MsSalesOrderItemCard.Add(new MsSalesOrderItemCard()
                {
                    SalesOrderId = item.SalesOrderId,
                    ItemCardId = item.ItemCardId,
                    Price = item.Price,
                    PriceAfterRate = item.PriceAfterRate,
                    QtyBeforRate = item.QtyBeforRate,
                    Quantity = item.Quantity,
                    UnitId = item.UnitId,
                    UnitRate = item.UnitRate,
                    StoreId = item.StoreId,
                    StorePartId = item.StorePartId,
                    DisPercent = item.DisPercent,
                    DisAmount = item.DisAmount,
                    Tax1Percent = item.Tax1Percent,
                    Tax2Percent = item.Tax2Percent,
                    Tax3Percent = item.Tax3Percent,
                    TaxesId1 = item.Detail_TaxesId1,
                    TaxesId2 = item.Detail_TaxesId2,
                    TaxesId3 = item.Detail_TaxesId3,
                    Tax1IsAccomulative = item.Tax1IsAccomulative,
                    Tax2IsAccomulative = item.Tax2IsAccomulative,
                    Tax3IsAccomulative = item.Tax3IsAccomulative
                });
                OrderId = item.SalesOrderId;
            }
            _db.SaveChanges();
            OrderResultHeaderAndDetailDto res = new OrderResultHeaderAndDetailDto();
            res.SalesOrderId = OrderId;
            res.Message = "تم اضافه الداتا بنجاح";
            return Ok(res);
        }
    }
}
