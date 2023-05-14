using BLL.DTO;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Reports.Controllers
{
    public class AddCustomerController : BaseController
    {
        public readonly SmartERPStandardContext _context;
        public AddCustomerController(SmartERPStandardContext context)
        {
            _context = context;
        }
        [HttpPost, AllowAnonymous]
        public IActionResult CreateCustomer(CreateCustomerDto dto)
        {
            var customer = new MsCustomer { CustomerDescA = dto.CustomerDescA , CustomerDescE = dto.CustomerDescE , Tel = dto.Tel};
           
            _context.MsCustomer.Add(customer);
            _context.SaveChanges();

            return Ok (customer);
        }

        
    }
}
