using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.Interfaces.Infracstructure
{
    public interface ICartRepository
    {
        object GetSearchAndPagingUserID(string UserID,int? pageSize, int? pageNumber, string? keyFilter);
        int UpdateCartUserID(string UserID,int ProductID,int soluong);
    }
}
