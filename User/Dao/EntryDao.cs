using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using User.Entities;

    //This is the Entry Data access object and it is used to to retrieve or delete Journal Entries from MySQL

    public class EntryDao
    {
        SqlDataAdapter EntryAdapter = null;
        DataTable EntryTable = null;
        String connectionString = null;
        SqlConnection cnn;



        public EntryDao()
        {
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);

            //Set entry adapter to retrieve all Entries
            EntryAdapter = new SqlDataAdapter("select * from Entry", Cfactory.CnnString);
            SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(EntryAdapter);

            //Filling the Entrytable with the retrieved values
            //string insertStatement = "Insert into Entry( Name, Date, Description, Title) values(@Name, @Date, @Description, @Title)";
            //EntryAdapter.InsertCommand = new SqlCommand(insertStatement);
            EntryTable = new DataTable();
            EntryAdapter.Fill(EntryTable);
        }

        //function to convert sql data into Entry objects and store them in an organized list.
        public List<Entrys> ReadAll(string NameFilter = "")
        {
            List<Entrys> Entrys = new List<Entrys>();
            DataRow[] rows = EntryTable.Select($"Name like '%{NameFilter}%'");

            foreach (DataRow row in rows)
            {
                Entrys Entry = new Entrys(
                   row["Name"].ToString(), row["Date"].ToString(), row["Description"].ToString(), row["Title"].ToString()
                    );
                Entrys.Add(Entry);
            }
            return Entrys;

        }

        //function to delete a journal entry
        public string DeleteEntry(string title)
        {
           
            string error=  "Deleted Successfully "+title;
            String queryString = "DELETE FROM dbo.Entry WHERE Title = '" + title + "';";
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
        
