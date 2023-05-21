using DemoCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.Interfaces.Authentication
{
    public interface IAuthenticationRepository
    {
        /// <summary>
        /// Lấy thông tin tài khoản
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Account GetAccount(string username, string password);
    }
}
