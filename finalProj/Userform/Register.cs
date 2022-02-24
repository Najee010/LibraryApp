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
    public partial class Register : Form
    {
        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;

        public Register()
        {

            InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);
        }

        //register button
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtcPassword.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtDescription.Text))
            {
                label6.Text = "You must fill out all Fields";
            }
            else if (txtPassword.Text != txtcPassword.Text)
            {
                label6.Text = "Passwords do not match!";
            }
            else
            {
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Insert into dbo.Users values(@Name,@Password,@Description)", cnn);
                    command.Parameters.AddWithValue("@Name", this.txtName.Text);
                    command.Parameters.AddWithValue("@Password", this.txtPassword.Text);
                    command.Parameters.AddWithValue("@Description", this.txtDescription.Text);
                    int r = command.ExecuteNonQuery();
                    label6.Text = "Successfully added " + txtName.Text + " to system. Returning to Login Page";
                    cnn.Close();


                }
                catch (SqlException ex)
                {
                    label6.Text = "Error in SQL! " + ex.Message;
                }
                finally
                {
                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }


                //Short dleay before redirecting back to login Page
                
                MessageBox.Show ("Successfully added " + txtName.Text + " to system. Returning to Login Page");
                Logins form1 = new Logins();
                this.Close();
                form1.Show();

            }
        }

            //Back Button for redirecting to login page
            private void Back_Click(object sender, EventArgs e)
            {
                Logins form1 = new Logins();
                this.Close();

            }
        }
    
}
