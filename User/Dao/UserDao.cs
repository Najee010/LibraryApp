using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using User.Entities;


//This is the User Data Access Object, allows the application to store and retrieve all user information
public class UserDao
{
    String connectionString = null;
    SqlConnection cnn;
    //SqlCommand command;
    SqlDataAdapter userAdapter = null;
    DataTable userTable;
    Users user = new Users();

    public UserDao()
    {
        connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
        cnn = new SqlConnection(connectionString);
        userAdapter = new SqlDataAdapter("select * from Users", Cfactory.CnnString);
        userTable = new DataTable();
        userAdapter.Fill(userTable);
    }

    public Users getUser(string UserFilter="")
    {
        DataRow[] row = userTable.Select($"Name like '%{UserFilter}%'");
        user.Name = row[0]["Name"].ToString();
        user.Password = row[0]["Password"].ToString();
        user.Description = row[0]["Description"].ToString();

        return user;
    }
}