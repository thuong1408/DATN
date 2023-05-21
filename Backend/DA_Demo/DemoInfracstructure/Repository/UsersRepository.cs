using DemoCore.Interfaces.Infracstructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using DemoCore.Entities;
using System.Reflection.Metadata;

namespace DemoInfracstructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private string _connectString;
        public SqlConnection SqlServerConnection;
        public UsersRepository(IConfiguration configuration)
        {
            _connectString = configuration.GetConnectionString("THUONGTD");
        }
        public object GetAllUsers()
        {
            using (SqlServerConnection = new SqlConnection(_connectString))
            {
                var sqlComand = "sp_GetAllUsers";
                return (SqlServerConnection.Query(sqlComand, commandType: System.Data.CommandType.StoredProcedure));
            }
        }

        public Users GetUsersByUserID(string UserID)
        {
            using (SqlServerConnection = new SqlConnection(_connectString))
            {
                var sqlComand = "sp_GetUserByUserID";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@userID", UserID);
                var result=SqlServerConnection.Query<Users>(sqlComand,param:dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                return (Users)result;
            }
        }
    }
}
