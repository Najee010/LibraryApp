using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Data

{
    //Creating Game class to send all information in one object as opposed to multiple vlaues
    public class Game
    {
        //can be created creat an instance of and empty game and add values later
        public Game() { }
        public Game(int ID, String Name, int Price, String Genre)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.Genre = Genre;
        }

        //Making all setters and getters
        [DataMember]
        public int ID
        {
            get { return ID; }
            set { ID = value; }
        }

        [DataMember]
        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }

        [DataMember]
        public int Price
        {
            get { return Price; }
            set { Price = value; }
        }

        [DataMember]
        public string Genre
        {
            get { return Genre; }
            set { Genre = value; }
        }


    }
    //May be unused, will delete if it is.
    /*
    [DataContract]
    public class Game2
    {
        public Game2() { }
        public Game2(int ID, String Name, int Price, String Genre)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.Genre = Genre;
        }

        [DataMember]
        public int ID
        {
            get { return ID; }
            set { ID = value; }
        }

        [DataMember]
        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }

        [DataMember]
        public int Price
        {
            get { return Price; }
            set { Price = value; }
        }

        [DataMember]
        public string Genre
        {
            get { return Genre; }
            set { Genre = value; }
        }

    }
    */
    //Class to create and store and send all user information packed into a single object
    public class User
    {
        public User() { }
        public User(int ID, String Name, String Password, String Description)
        {
            this.ID = ID;
            this.Name = Name;
            this.Password = Password;
            this.Description = Description;
        }

        //setters and getters
        public int ID
        {
            get { return ID; }
            set { ID = value; }
        }

        [DataMember]
        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }

        [DataMember]
        public String Password
        {
            get { return Password; }
            set { Password = value; }
        }

        [DataMember]
        public string Description
        {
            get { return Description; }
            set { Description = value; }
        }
    }
}
