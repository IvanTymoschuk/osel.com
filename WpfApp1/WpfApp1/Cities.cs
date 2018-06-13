using System.Collections.Generic;
using System.Linq;

namespace WpfApp1
{
    public class Cities
    {
       List<string> cities;

        public Cities()
        {
            cities = new List<string>
            {
                "Rivne",
                "Lutsk",
                "Lviv",
                "Ternopil",
                "Kyiv",
                "Kharkiv",
                "Ushgorod",
                "Ivano-Frankivsk",
                "Donetsk",
                "Odessa",
                "Chernigiv",
                "Zhytomyr",
                "Poltava",
                "Sumy",
                "Kherson",
                "Simferopol",
                "Chernivtsi",
                "Vinnytsa",
                "Lugansk",
                "Dnipro",
                "Zaporizhya",
                "Mykolaiv",
                "Curved Rih",
                "Khmelnytsky"
            };
        }

        public List<string> getCities()
        {
            return cities.OrderBy(i => i).ToList();
        }
    }
}