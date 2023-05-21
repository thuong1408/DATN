using DemoCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.Interfaces.Infracstructure
{
    public interface IUsersRepository
    {
        object GetAllUsers();
        Users GetUsersByUserID(string UserID);
    }
}
