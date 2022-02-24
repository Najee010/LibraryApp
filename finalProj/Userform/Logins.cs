using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Userform
{
    public partial class Logins : Form
    {
        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;

        public static string username;

        public Logins()
        {
            InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);
            
        }

        public object Response { get; private set; }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Login Button
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                String queryString = "select * from dbo.Users where name ='" + this.txtName.Text + "';";
                cnn.Open();
                command = new SqlCommand(queryString, cnn);
                SqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    if (txtName.Text != reader["Name"].ToString() || txtPassword.Text != reader["Password"].ToString() ||txtName.Text == "" || txtPassword.Text =="" )
                    {
                        Message.Text = "Incorrect Username Or Password, Try again";
                    }
                   else if (txtName.Text == reader["Name"].ToString() && txtPassword.Text == reader["Password"].ToString())
                    {
                        //If Login successful, save Usrname to assis with form 2 processes
                        Profile ProfilePage = new Profile();
                        username = txtName.Text;
                        ProfilePage.Show();
                        this.Hide();
                    }
  
                }
            }
            catch (SqlException ex)
            {
                Message.Text = ("Error in SQL!" + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Register form4 = new Register();
            form4.Show();
            this.Hide();
        }
    }
}