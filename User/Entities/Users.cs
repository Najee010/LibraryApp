using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User.Entities
{
    //User entity, used to create and hold all retrieved Data on users from MySql
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }

        public Users() { }
        public Users( String Name, String Password, String Description)
        {
            this.Name = Name;
            this.Password = Password;
            this.Description = Description;
        }
    }
}