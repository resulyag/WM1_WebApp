using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ItServiceApp.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ItServiceApp.Models.Identity
{
    public class ApplicationUser:IdentityUser
    {
        [Required, StringLength(50)]
        [PersonalData]
        public string Name { get; set; }
        [Required,StringLength(50)]
        [PersonalData]
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public virtual List<Address> Addresses { get; set; }
        public virtual List<Subscription> Subscriptions { get; set; }
    }
}
