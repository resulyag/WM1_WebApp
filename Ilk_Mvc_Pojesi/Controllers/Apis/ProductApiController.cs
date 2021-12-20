using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ilk_Mvc_Pojesi.Models;
using Ilk_Mvc_Pojesi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ilk_Mvc_Pojesi.Controllers.Apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly NorthwindContext _dbContext;

        public ProductApiController(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Add(ProductViewModel model)
        {
            var product = new Product()
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice
            };
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return Ok(new
                {
                    Message = "Ürün ekleme işlemi başarılı",
                    Model = product
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu:{ex.Message}");
            }
        }
        [HttpPost]
        [Route("~/api/productapi/delete/{id?}")]
        public IActionResult Delete(int id=0)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.CategoryId == id);
            if (product == null)
            {
                return NotFound("Ürün Bulunamadı");
            }

            try
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return Ok(new
                {
                    Message = $"{product.ProductName} isimli ürün başarıyla silindi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu : {ex.Message}");
            }
        }
    }
}
