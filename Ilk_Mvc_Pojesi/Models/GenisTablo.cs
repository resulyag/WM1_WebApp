using System;
using System.Collections.Generic;

#nullable disable

namespace Ilk_Mvc_Pojesi.Models
{
    public partial class GenisTablo
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustName { get; set; }
        public string Shipper { get; set; }
        public string City { get; set; }
        public string CustomerCount { get; set; }
        public string SupplierName { get; set; }
        public string SatıcıUlke { get; set; }
        public string Salesman { get; set; }
    }
}
