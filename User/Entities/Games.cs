using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User.Entities
{
    //Entity used to retrieve game data from SQL and repackage them back into objects for display
    public class Games
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Genre { get; set; }


        public Games()
        {
        }

        public Games( String Name, int Price, String Genre)
        {
            this.Name = Name;
            this.Price = Price;
            this.Genre = Genre;
        }
    }
}