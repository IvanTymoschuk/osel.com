using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Windows;

namespace WpfApp1
{
    [Serializable]
    public class User : IDataErrorInfo
    {

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
                List<User> list = new List<User>();
               string error = "";
              
                switch (columnName)
                {
                    case "login":
                        if (login.Contains("lox"))
                        {
                            error = "Bad login";
                        //    MessageBox.Show("Valid");
                        }
                        else
                        {
                            if (File.Exists("user.xml") == true)
                            {

                                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
                                using (FileStream fs = new FileStream("user.xml", FileMode.Open))
                                {
                                    list = (List<User>)xmlSerializer.Deserialize(fs);
                                }
                                foreach (var el in list)
                                    if (el.login == this.login)
                                    {
                                        //MessageBox.Show("Login exist");
                                        error = "Login exist";
                                    }
                            }
                        }
                        break;
                }
                return error;


            }
        } 
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
