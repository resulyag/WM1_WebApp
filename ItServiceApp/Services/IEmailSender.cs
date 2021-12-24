using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItServiceApp.Models;

namespace ItServiceApp.Services
{
    public interface IEmailSender
    {
        Task SendAsync(EMailMessage message);
    }
}
