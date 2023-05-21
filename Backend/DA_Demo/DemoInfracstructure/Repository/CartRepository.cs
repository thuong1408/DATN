using Dapper;
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
    public class CartRepository : ICartRepository
    {
        private string? _connectString;
        public SqlConnection? SqlServerConnection;
        public CartRepository(IConfiguration configuration)
        {
            _connectString = configuration.GetConnectionString("THUONGTD");
        }
        public object GetSearchAndPagingUserID(string UserID, int? pageSize, int? pageNumber, string? keyFilter)
        {
            using (SqlServerConnection = new SqlConnection(_connectString))
            {
                string sqlcommand = "sp_CartFilterUser";
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@UserID", UserID);
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

        public int UpdateCartUserID(string UserID,int ProductID, int soluong)
        {
            using (SqlServerConnection = new SqlConnection(_connectString))
            {
                string sqlcommand = "sp_UpdateCartNum";
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@userID", UserID);
                parameters.Add("productID", ProductID);
                parameters.Add("number", soluong);
                var res = SqlServerConnection.Execute(sqlcommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                
                return res;
            }
        }
    }
}
