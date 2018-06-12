using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace WpfApp1
{
    [Serializable]
    public class Advertisment
    {
       public string Name { get; set; }
        public int Price { get; set; }
        public string Descript { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public User user { get; set; }

        public Advertisment()
        {

        }

        public Advertisment(string Name,
                            int Price,
                            string Descript,
                            string Type,
                            string City,
                            DateTime Date,
                            User user
            )
        {
            this.Name = Name;
            this.Price = Price;
            this.Descript = Descript;
            this.City = City;
            this.Type = Type;
            this.Date = Date;
            this.user = user;
        }
        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {

            get
            {
                List<Advertisment> list = new List<Advertisment>();
                string error = "";

                switch (columnName)
                {
                    case "login":
                        if (Name.Contains("lox") || Name.Contains("RAB"))
                        {
                            error = "Bad name";
                            //    MessageBox.Show("Valid");
                        }
                        else
                        {
                            if (File.Exists("tovar.xml") == true)
                            {

                                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
                                using (FileStream fs = new FileStream("tovar.xml", FileMode.Open))
                                {
                                    list = (List<Advertisment>)xmlSerializer.Deserialize(fs);
                                }
                                foreach (var el in list)
                                    if (el.Name.ToLower() == this.Name.ToLower())
                                    {
                                        //MessageBox.Show("Login exist");
                                        error = "Name exist";
                                    }
                            }

                        }
  
                        break;
                }
                return error;
            }
        }
    }
}