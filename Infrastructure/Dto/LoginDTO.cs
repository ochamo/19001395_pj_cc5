﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginDTO(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
