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
    }
}
