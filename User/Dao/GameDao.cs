
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using User.Entities;
using User.Dao;

//This is the Game Data access object and it is used to to retrieve or delete Game information from MySQL
namespace User.Dao
{
    public class GameDao
    {
        SqlDataAdapter GameAdapter = null;
        DataTable GameTable = null;
        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;

        public GameDao()
        {
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);

            //fill the 
            GameAdapter = new SqlDataAdapter("select * from Game", Cfactory.CnnString);
            //SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(GameAdapter);
            //string insertStatement = "Insert into Game(Author, Name, Price, Genre) values(@Author, @Name, @Price, @Genre)";
            //GameAdapter.InsertCommand = new SqlCommand(insertStatement);
            GameTable = new DataTable();
            GameAdapter.Fill(GameTable);
        }

        //Method made to add a game to a specific users Library
        public string AddGame(String Author, Games game)
        {
            string Message = "";
            try
            {
                cnn.Open();
                command = new SqlCommand("Insert into dbo.Game values(@Author,@Name,@Price,@Genre)", cnn);
                command.Parameters.AddWithValue("@Author", Author);
                command.Parameters.AddWithValue("@Name", game.Name);
                command.Parameters.AddWithValue("@Price", game.Price);
                command.Parameters.AddWithValue("@Genre", game.Genre);


                int r = command.ExecuteNonQuery();
                Message = "Entry Stored Successfully";
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Message  = "Error in SQL! " + ex.Message;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return Message;
        }

        //Function used to edit a users existing entry
        public String EditGame(Games game)
        {
            String Message = "";
            try
            {
                cnn.Open();
                command = new SqlCommand("Update dbo.Game Set Name = @name,Price = @Price, Genre =@Genre Where Name = @currentGame", cnn);
                command.Parameters.AddWithValue("@currentGame", game.Name);
                command.Parameters.AddWithValue("@Name", game.Name);
                command.Parameters.AddWithValue("@Price", game.Price);
                command.Parameters.AddWithValue("@Genre", game.Genre);
                int r = command.ExecuteNonQuery();
                Message  = "Edit Stored Successfully";
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Message = "Error in SQL! " + ex.Message;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return Message;
        }

        //Function to retrieve all games entries made from the requesting
        public List<Games> ReadAll(string AuthorFilter = "")
        {
            List<Games> Games = new List<Games>();
            DataRow[] rows = GameTable.Select($"Author like '%{AuthorFilter}%'");

            foreach(DataRow row in rows)
            {
                Games game = new Games(
                   row["Name"].ToString(), int.Parse(row["Price"].ToString()), row["Genre"].ToString()
                    );
                Games.Add(game);
            }
            return Games;
        }

        //Function to delete a game entry
        public string DeleteEntry(string name)
        {

            string error = "Deleted Successfully " + name;
        String queryString = "DELETE FROM dbo.Game WHERE Name = '" + name + "';";
            try
            {
                cnn.Open();
                SqlCommand command = new SqlCommand(queryString, cnn);
        SqlDataReader reader = command.ExecuteReader();

            }

            catch (SqlException ex)
            {
              error =("Error in SQL! " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return error;
        }
    }
}