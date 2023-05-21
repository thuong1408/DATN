using Dapper;
using DemoCore.Entities;
using DemoCore.Exceptions;
using DemoCore.Interfaces.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoInfracstructure.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private string _connectString;
        public SqlConnection SqlServerConnection;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration"></param>
        public AuthenticationRepository(IConfiguration configuration)
        {
            
            _connectString = configuration.GetConnectionString("THUONGTD");
        }

        /// <summary>
        /// Lấy thông tin tài khoản
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Account GetAccount(string username, string password)
        {
            using (SqlServerConnection = new SqlConnection(_connectString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", username);
                parameters.Add("@Password", password);

                var account = SqlServerConnection.QueryFirstOrDefault<Account>("sp_GetAccountByUsernamePassword", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return account;
            }
        }
    }
}
