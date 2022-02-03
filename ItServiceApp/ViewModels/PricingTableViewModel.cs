using System;

namespace ItServiceApp.ViewModels
{
    public class PricingTableViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Month { get; set; }
    }
}
