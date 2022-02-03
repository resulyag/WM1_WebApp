using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ItServiceApp.Data;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ItServiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly IMapper _mapper;

        public HomeController(MyContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }



        public IActionResult Index()
        {
            //List<PricingTableViewModel> result = new List<PricingTableViewModel>();

            //var model = _dbContext.SubscriptionTypes
            //    .OrderBy(x => x.Price)
            //    .ToList()
            //    .Select(x=>_mapper.Map<PricingTableViewModel>(x))
            //    .ToList();

            //var data = _dbContext.SubscriptionTypes.ToList();
            
            //foreach (var item in data)
            //{
            //    result.Add(new PricingTableViewModel
            //    {
            //        Name = item.Name,
            //        Description = item.Description,
            //        Month = item.Month,
            //        Price = item.Price
            //    });
            //}
            return View();
        }
    }
}
