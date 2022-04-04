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
    SqlCommand command;
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

    //Function to add a user to the the User Table
    public String addUser(Users user)
    {
        String result;
        try
        {
            cnn.Open();
            command = new SqlCommand("Insert into dbo.Users values(@Name,@Password,@Description)", cnn);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Description", user.Description);
            int r = command.ExecuteNonQuery();
            result = "Successfully added " + user.Name + " to system. Returning to Login Page";
            cnn.Close();


        }
        catch (SqlException ex)
        {
            result = "Error in SQL! " + ex.Message;
        }
        finally
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
        return result;
    }
    

    //function to retrieve a user by the string given
    public Users getUser(string UserFilter="")
    {
        DataRow[] row = userTable.Select($"Name like '%{UserFilter}%'");
        user.Name = row[0]["Name"].ToString();
        user.Password = row[0]["Password"].ToString();
        user.Description = row[0]["Description"].ToString();

        return user;
    }
}