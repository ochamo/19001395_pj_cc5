using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.User
{
    public class TokenModel
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

        public TokenModel(int userId, string role, string email)
        {
            UserId = userId;
            Role = role;
            Email = email;
        }

        public TokenModel()
        {
            UserId = 0;
            Role = "";
            Email = "";
        }
    }
}
