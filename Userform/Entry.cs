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
using User.Entities;

namespace Userform
{
    //Works but work on using dao to push data to sql instead of form
    public partial class Entry : Form
    {
        String connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
        SqlConnection cnn;
        SqlCommand command;
        string date = DateTime.Now.ToString("M/d/yyyy");
        String currentTitle;

        public Entry()
        {
            InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);
            Ldate.Text = date;
        
        }

        public Entry(Entrys Entry)
        {
            InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);

            //Putting Saved values back into form To Edit
            Ldate.Text = Entry.Date;
            Title.Text = Entry.Title;
            currentTitle = Entry.Title;
            UserEntry.Text = Entry.JEntry;
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
                cnn = new SqlConnection(connectionString);
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

        private void Entry_Load(object sender, EventArgs e)
        {

        }
    }
    
}
