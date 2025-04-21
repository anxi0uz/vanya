using Malchikov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Malchikov.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AssortmentController : Controller
    {
        private readonly MvContext mvContext = new MvContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(mvContext.Assortments
                .AsNoTracking()
                .ToList());
        }
        [HttpPost]
        public IActionResult PostNewAssortment([FromBody] Assortment assortment)
        {
            var NewAssortment = new Assortment
            {
                Id = assortment.Id,
                Name = assortment.Name,
                Type = assortment.Type,
                Volume = assortment.Volume,
                PriceShop = assortment.PriceShop,

            };
            mvContext.Assortments.Add(NewAssortment);
            mvContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteAssortment(int Id)
        {
            mvContext.Assortments.Where(p => p.Id == Id).ExecuteDelete();
            mvContext.SaveChanges();
            return Ok(Id);
        }
        [HttpPut("{Id}")]
        public IActionResult PutAssortment(int Id, Assortment assortment)
        {
            var putAssortment = mvContext.Assortments.Find(Id);
            if (putAssortment is null)
            {
                return NotFound();
            }
            putAssortment.Name = assortment.Name;
            putAssortment.Type = assortment.Type;
            putAssortment.Volume = assortment.Volume;
            putAssortment.PriceShop = assortment.PriceShop;
            mvContext.SaveChanges();
            return Ok(putAssortment);
        }
    }
}
