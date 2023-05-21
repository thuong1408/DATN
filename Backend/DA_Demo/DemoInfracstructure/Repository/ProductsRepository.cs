using Dapper;
using DemoCore.Entities;
using DemoCore.Interfaces.Infracstructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInfracstructure.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private string? _connectString;
        public SqlConnection? SqlServerConnection;
        public ProductsRepository(IConfiguration configuration)
        {
            _connectString = configuration.GetConnectionString("THUONGTD");
        }
        public int DeleteProductByProductID(int productID)
        {
            throw new NotImplementedException();
        }

        public Products GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public object GetProductByProductID(int productID)
        {
            using (SqlServerConnection = new SqlConnection(_connectString))
            {
                string sqlcommand = "sp_GetProductByProductID";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@productID", productID);
                
                var product = SqlServerConnection.Query<Products>(sqlcommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                
                return product;
            }
        }

        public object GetSearchAndPaging(int? pageSize, int? pageNumber, string? keyFilter)
        {
            using (SqlServerConnection = new SqlConnection(_connectString))
            {
                string sqlcommand = "sp_ProductFilter";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@KeyFilter", keyFilter);
                parameters.Add("@PageSize", pageSize);
                parameters.Add("@PageIndex", pageNumber);
                parameters.Add("@TotalPage", DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@TotalRecord", DbType.Int32, direction: ParameterDirection.Output);
                var Data = SqlServerConnection.Query<object>(sqlcommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                var TotalPage = parameters.Get<int>("@TotalPage");
                var TotalRecord = parameters.Get<int>("@TotalRecord");
                Object data = new
                {
                    TotalPage,
                    TotalRecord,
                    Data
                };
                return data;
            }
        }
    }
}
