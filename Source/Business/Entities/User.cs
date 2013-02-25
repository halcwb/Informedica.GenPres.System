﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Informedica.GenPres.Business.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        protected User()
        {
            Username = "";
            PasswordHash = "";
        }

        public static User CreateUser(string username, string password)
        {
            var user = new User()
            {
                Username = username,
                PasswordHash = password
            };

            return user;
        }
    }
}
