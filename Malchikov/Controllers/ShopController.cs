using Malchikov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Malchikov.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly MvContext mvContext = new MvContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IResult GetAll()
        {
            return Results.Json(mvContext.Shops.ToList());
            //return Ok(mvContext.Shops
            //    .AsNoTracking()
            //    .ToList());
        }
        [HttpPost]
        public IActionResult PostNewShop([FromBody] ShopDto shop)
        {
            var NewShop = new Shop
            {
               Name = shop.Name,
               Quantity = shop.Quantity,
               PriceShop = shop.PriceShop,
               SupplierId = shop.SupplierId,
               AssortmentId = shop.AssortmentId,

            };
            mvContext.Shops.Add(NewShop);
            mvContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteShop(int Id)
        {
            mvContext.Shops.Where(p => p.Id == Id).ExecuteDelete();
            mvContext.SaveChanges();
            return Ok(Id);
        }
        [HttpPut("{Id}")]
        public IActionResult PutShop(int Id, Shop shop) 
        {
            var putShop = mvContext.Shops.Find(Id);
            if (putShop is null)
            {
                return NotFound();
            }
            putShop.Id = shop.Id;
            putShop.Name = shop.Name;
            putShop.Quantity = shop.Quantity;
            putShop.PriceShop = shop.PriceShop;
            putShop.SupplierId = shop.SupplierId;
            putShop.AssortmentId = shop.AssortmentId;
            mvContext.SaveChanges();
            return Ok(putShop);
        }
     }  

}
