using Malchikov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Malchikov.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : Controller
    {
        private readonly MvContext mvContext = new MvContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(mvContext.Suppliers
                .AsNoTracking()
                .ToList());
        }
        [HttpPost]
        public IActionResult PostNewSupplier([FromBody] Supplier supplier)
        {
            var NewSupplier = new Supplier
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Type = supplier.Type,
                Quatity = supplier.Quatity,
                PriceSupplier = supplier.PriceSupplier,
                Address = supplier.Address,


            };
            mvContext.Suppliers.Add(NewSupplier);
            mvContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteSupplier(int Id)
        {
            mvContext.Suppliers.Where(p => p.Id == Id).ExecuteDelete();
            mvContext.SaveChanges();
            return Ok(Id);
        }
        [HttpPut("{Id}")]
        public IActionResult PutSupplier(int Id, Supplier supplier)
        {
            var putSupplier = mvContext.Suppliers.Find(Id);
            if (putSupplier is null)
            {
                return NotFound();
            }
            putSupplier.Id = supplier.Id;
            putSupplier.Name = supplier.Name;
            putSupplier.Type = supplier.Type;
            putSupplier.Quatity = supplier.Quatity;
            putSupplier.PriceSupplier = supplier.PriceSupplier;
            putSupplier.Address = supplier.Address;
            mvContext.SaveChanges();
            return Ok(putSupplier);
        }
    }
}
