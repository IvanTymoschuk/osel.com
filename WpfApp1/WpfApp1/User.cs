﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
   public class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public bool isBanned { get; set; }

        private string random_login()
        {
            string log;
            Random rnd = new Random();
            log = rnd.Next(999999).ToString();
            return log;
        }
        public User()
        {
            this.login = random_login();
            this.password = "pass";
            this.phone = "22221212";
            this.city = "None";
            this.isBanned = false;
        }
        public User(string login,string password,string city,string phone)
        {
            this.login = login;
            this.password = password;
            this.city = city;
            this.phone = phone;
            isBanned = false;   
        }

    }
}