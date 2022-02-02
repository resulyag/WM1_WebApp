using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItServiceApp.Data;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ItServiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _dbContext;

        public HomeController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<PricingTableViewModel> result = new List<PricingTableViewModel>();

            var data = _dbContext.SubscriptionTypes.ToList();
            
            foreach (var item in data)
            {
                result.Add(new PricingTableViewModel
                {
                    PricingName = item.Name,
                    PricingDescription = item.Description,
                    PricingMonth = item.Month,
                    PricingPrice = item.Price
                });
            }
            return View(result);
        }
    }
}
