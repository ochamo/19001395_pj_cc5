using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.User
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Pass { get; set; }

        public LoginDTO(string userName, string pass)
        {
            UserName = userName;
            Pass = pass;
        }
    }
}
