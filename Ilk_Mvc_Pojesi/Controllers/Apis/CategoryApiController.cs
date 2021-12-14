using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ilk_Mvc_Pojesi.Models;
using Ilk_Mvc_Pojesi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ilk_Mvc_Pojesi.Controllers.Apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly NorthwindContext _dbContext;
        public CategoryApiController(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _dbContext.Categories
                    .OrderBy(x => x.CategoryName)
                    .Select(x=>new CategoryViewModel
                    {
                        CategoryId = x.CategoryId,
                        CategoryName = x.CategoryName,
                        Description=x.Description,
                        ProductCount = x.Products.Count
                    })
                    .ToList();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = new Category
            {
                CategoryName=model.CategoryName,
                Description =model.Description
            };

            _dbContext.Categories.Add(category);
            try
            {
                _dbContext.SaveChanges();
                return Ok(new 
                {
                    Message = "Kategori ekleme işlemi başarılı",
                    Model = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("~/api/categoryapi/updatecategory/{id?}")]
        public IActionResult UpdateCategory(int? id,CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category==null)
            {
                return NotFound("Kategori Bulunamadı");
            }

            category.CategoryName = model.CategoryName;
            category.Description = model.Description;

            try
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                return Ok(new 
                {
                    Message = "Kategori güncelleme işlemi başarılı",
                    Model = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult DeleteCategory(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound("Kategori Bulunamadı");
            }

            try
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                return Ok(new
                {
                    Message = "Kategori silme işlemi başarılı",
                    Model = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
