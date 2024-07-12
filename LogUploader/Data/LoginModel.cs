﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Data
{
    public class LoginModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        public LoginModel(string username, string password)
        {
            UserName = username;
            Password = password;
        }

    }
}
