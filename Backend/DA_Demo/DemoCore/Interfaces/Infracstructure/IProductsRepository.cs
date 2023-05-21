using DemoCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.Interfaces.Infracstructure
{
    public interface IProductsRepository
    {
        Products GetAllProducts();
        object GetProductByProductID(int productID);
        int DeleteProductByProductID(int productID);
        object GetSearchAndPaging(int? pageSize, int? pageNumber, string? keyFilter);
    }
}
