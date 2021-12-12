using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ilk_Mvc_Pojesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ilk_Mvc_Pojesi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly NorthwindContext _context;
        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Products.Include(x=>x.Category).ToList();
            return View(model);
        }
        public IActionResult Detail(int? id)
        {
            var model = _context.Products.Include(x=>x.Category).FirstOrDefault(x => x.ProductId == id);
            return View(model);
        }

    }
}
