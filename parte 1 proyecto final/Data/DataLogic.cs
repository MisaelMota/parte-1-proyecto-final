using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using parte_1_proyecto_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parte_1_proyecto_final.Data
{
    public class DataLogic
    {
        private readonly IConfiguration _configuration;

        public DataLogic(IConfiguration configuration )
        {
            this._configuration = configuration;
        }

        public IEnumerable<UserModel> UserL()
        {
            var connectionString = _configuration.GetConnectionString("newspage");
            var connection = new SqlConnection(connectionString);
            var resulset = connection.Query<UserModel>("select UserId,Email,UserType,Passw from users inner join UserType on users.UserTypeId=UserType.UserTypeId");

            return resulset;

        }

        public UserModel Uservalidation(string _email,string _passw)
        {
            return UserL().Where(item =>item.Email==_email && item.Passw== _passw).FirstOrDefault();

        }








    }
}
