using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Userform
{
    public partial class Entry : Form
    {
        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;
        string date = DateTime.Now.ToString("M/d/yyyy");
        String[] variables;
        String currentTitle;

        public Entry()
        {
            InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);
            Ldate.Text = date;
        
        }

        public Entry(String[] variables)
        {
            InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);
            this.variables = variables;

            //Putting Saved values back into form To Edit
            Ldate.Text = variables[1]+"-"+variables[2] + "-"+variables[3];
            Title.Text = variables[4];
            currentTitle = variables[4];
            UserEntry.Text = variables[5];
        }

        //Save Buutton
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                command = new SqlCommand("Insert into dbo.Entry values(@Name,@Date,@Description,@Title)", cnn);
                command.Parameters.AddWithValue("@Name", Logins.username);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Description", this.UserEntry.Text);
                command.Parameters.AddWithValue("@Title", this.Title.Text);
               

                int r = command.ExecuteNonQuery();
                Message.Text = "Entry Stored Successfully";
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Message.Text = "Error in SQL! " + ex.Message;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Profile form = new Profile();
            this.Hide();
            form.Show();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                command = new SqlCommand("Update dbo.Entry Set Name = @name,Date = @Date, Description =@Description, Title = @Title Where Title = @currentTitle", cnn);
                command.Parameters.AddWithValue("@currentTitle", currentTitle);
                command.Parameters.AddWithValue("@Name", Logins.username);
                command.Parameters.AddWithValue("@Date", this.Ldate.Text);
                command.Parameters.AddWithValue("@Description", this.UserEntry.Text);
                command.Parameters.AddWithValue("@Title", this.Title.Text);


                int r = command.ExecuteNonQuery();
                Message.Text = "Edited Successfully";
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Message.Text = "Error in SQL! " + ex.Message;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
    }
    
}
