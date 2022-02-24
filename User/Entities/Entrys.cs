using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User.Entities
{
    public class Entrys
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string JEntry { get; set; }
        public string Title { get; set; }

        public Entrys()
        {

        }

        public Entrys(String Name, String Date, string JEntry, String Title)
        {
            this.Name = Name;
            this.Date = Date;
            this.JEntry = JEntry;
            this.Title = Title;
        }
    }
}