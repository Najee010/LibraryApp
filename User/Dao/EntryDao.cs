using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using User.Entities;

namespace User.Dao
{

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

            EntryAdapter = new SqlDataAdapter("select * from Entry", Cfactory.CnnString);
            SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(EntryAdapter);
            string insertStatement = "Insert into Entry( Name, Date, Description, Title) values(@Name, @Date, @Description, @Title)";
            EntryAdapter.InsertCommand = new SqlCommand(insertStatement);
            EntryTable = new DataTable();
            EntryAdapter.Fill(EntryTable);
        }

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
        }
