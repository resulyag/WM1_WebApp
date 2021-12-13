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
        private int _pageSize = 10;
        public IActionResult Index(int? page = 1)
        {
            var model = _context.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .OrderBy(x => x.Category.CategoryName)
                .ThenBy(x => x.ProductName)
                .Skip((page.GetValueOrDefault() - 1) * _pageSize )
                .Take(_pageSize)
                .ToList();
            //ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            //ViewBag.Suppliers = _context.Suppliers.OrderBy(x => x.CompanyName).ToList();
            ViewBag.Page = page.GetValueOrDefault(1);
            ViewBag.Limit =(int)Math.Ceiling( _context.Products.Count() /(double) _pageSize);
            return View(model);
        }
        public IActionResult Detail(int? id)
        {
            var model = _context.Products
                .Include(x=>x.Category)
                .Include(x=>x.Supplier)
                .FirstOrDefault(x => x.ProductId == id);
            return View(model);
        }

    }
}
