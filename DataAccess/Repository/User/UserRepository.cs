using Domain.Repository;
using Infrastructure.Dto.User;
using Infrastructure.Model;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlDataAccess Db;
        public UserRepository(ISqlDataAccess dataAccess)
        {
            this.Db = dataAccess;
        }

        public Task<int> CreateUser(CreateUserDTO userDto) => Db.SaveData(Procedures.InsertUser, userDto);

        public async Task<LoginModel> Login(LoginDTO loginDto)
        {
            var result = await Db.Single<LoginModel, LoginDTO>(Procedures.LoginUser, loginDto);
            return result;
        }

        public Task UpdatePassword(UpdatePasswordDTO updatePasswordDto)
        {
            throw new NotImplementedException();
        }
    }
}
