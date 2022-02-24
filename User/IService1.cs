using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Data

{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        object GetData(object value);


        // TODO: Add your service operations here
    }

    [DataContract]
    public class Game
    {
        public Game() { }
        public Game(int ID, String Name, int Price, String Genre)
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
