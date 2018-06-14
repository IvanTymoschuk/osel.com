﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace WpfApp1
{
    [Serializable]
    public class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private bool isValid;
        private bool[] iv = new bool[3];

        public User()
        {
            login = null;
            password = null;
            phone = null;
            city = null;
            isBanned = false;
        }

        public User(string login, string password, string city, string phone)
        {
            this.login = login;
            this.password = password;
            this.city = city;
            this.phone = phone;
            isBanned = false;
        }

        public bool IsValid
        {
            get => isValid;
            set
            {
                isValid = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
            }
        }

        public string login { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public bool isBanned { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                var list = new List<User>();
                var error = "";
                var xmlSerializer = new XmlSerializer(typeof(List<User>));
                using (var fs = new FileStream("user.xml", FileMode.Open))
                {
                    list = (List<User>)xmlSerializer.Deserialize(fs);
                    //    MessageBox.Show(list.Count.ToString());
                }

                switch (columnName)
                {
                    case "login":
                        if (login.Contains("lox"))
                        {
                            error = "Bad login";

                            //    MessageBox.Show("Valid");
                        }
                        else
                            if (String.IsNullOrEmpty(login))
                            error = "Login is empty";
                        else
                        {
                            if (File.Exists("user.xml"))
                            {

                                foreach (var el in list)
                                    if (el.login.ToLower() == login.ToLower())
                                        error = "Login exist";
                            }
                        }

                        break;
                    //case "password":
                    //    if (password.Length < 7)

                    //        error = "Password min length 7 symvol";
                    //    break;
                    case "city":
                        if (String.IsNullOrEmpty(city))
                            error = "City is empty";
                        break;
                    case "phone":
                        if (Regex.IsMatch(phone, @"\d{12}") == false)
                            error = "Phone error";
                        else
                            foreach (var el in list)
                                if (el.phone == phone)
                                    error = "Phone exist";

                        break;
                }

                // MessageBox.Show(error);
                return error;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //private string random_login()
        //{
        //    string log;
        //    var rnd = new Random();
        //    log = rnd.Next(999999).ToString();
        //    return log;
        //}
    }
}