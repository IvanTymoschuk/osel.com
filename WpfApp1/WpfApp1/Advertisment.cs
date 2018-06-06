using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Advertisment
    {
       public string Name { get; set; }
        public string Price { get; set; }
        public string Descript { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }


        public Advertisment(string Name,
                            string Price,
                            string Descript,
                            string Type,
                            string City,
                            DateTime Date)
        {
            this.Name = Name;
            this.Price = Price;
            this.Descript = Descript;
            this.City = City;
            this.Type = Type;
            this.Date = Date;
        }
    }
}