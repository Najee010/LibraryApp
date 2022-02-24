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
using User.Entities;

namespace Userform
{
    public partial class Logins : Form
    {
        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;

        public static string username;
        Profile ProfilePage = new Profile();

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
                Users user = new Users(txtName.Text, txtPassword.Text, "");
                String queryString = "select * from dbo.Users where name ='" + user.Name + "';";
                cnn.Open();
                command = new SqlCommand(queryString, cnn);
                SqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    if (user.Name != reader["Name"].ToString() || user.Password != reader["Password"].ToString() ||user.Name == "" || user.Password =="" )
                    {
                        Message.Text = "Incorrect Username Or Password, Try again";
                    }
                   else if (user.Name == reader["Name"].ToString() && user.Password == reader["Password"].ToString())
                    {
                        //If Login successful, save Usrname to assis with form 2 processes
                        username = user.Name;
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