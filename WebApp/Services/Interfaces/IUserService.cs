using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Entities;

namespace Services.Interfaces
{
    public interface IUserService
    {
        User CheckLogin(string username, string password);
        MailStatus ForgotPassword(string email);
    }
}
