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
    public class QuantityAndPlacesOfItemsController : BaseController
    {
        private readonly QuantityAndPlacesOfItemsBll _serviceBll;
        public QuantityAndPlacesOfItemsController(QuantityAndPlacesOfItemsBll serviceBll)
        {
            _serviceBll = serviceBll;
        }

        #region تحميل الفروع
        [HttpPost, AllowAnonymous]
        public ResultDTO GetBranchesSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = _serviceBll.GetBranchesSelect(parametersDTO);
            return resultDTO;
        }
        #endregion
        
        #region تحميل فئات الاصناف
        [HttpPost, AllowAnonymous]
        public ResultDTO GetItemsCategoriesSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = _serviceBll.GetCategoriesSelect(parametersDTO);
            return resultDTO;
        }
        #endregion
        
        #region تحميل الاصناف
        [HttpPost, AllowAnonymous]
        public ResultDTO GetItemsSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = _serviceBll.GetItemsSelect(parametersDTO);
            return resultDTO;
        }
        #endregion
        
        #region تحميل المخازن
        [HttpPost, AllowAnonymous]
        public ResultDTO GetPartitionsSelect(ParametersDTO parametersDTO)
        {
            ResultDTO resultDTO = _serviceBll.GetPartitionsSelect(parametersDTO);
            return resultDTO;
        }
        #endregion

        #region الحصول على التقرير
        [HttpPost, AllowAnonymous]
        public ResultDTO GetQuantityAndPlacesOfItemsRpt(RPTQuantityAndPlacesOfItemsDTO placesAndQuantityOfItemsDTO)
        {
            ResultDTO resultDTO = _serviceBll.GetQuantityAndPlacesOfItemsRpt(placesAndQuantityOfItemsDTO);
            return resultDTO;
        }
        #endregion
    }
}
