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
    public partial class Register : Form
    {
        ///String connectionString = null;
        ///SqlConnection cnn;
        ///SqlCommand command;
        UserDao uDao = new UserDao();

        public Register()
        {
            InitializeComponent();

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
                //Attempt to create the user with the information given
                Users user = new Users(this.txtName.Text, this.txtcPassword.Text, this.txtDescription.Text);
                label6.Text = uDao.addUser(user);
            }
                //Short dleay before redirecting back to login Page
                MessageBox.Show ("Successfully added " + txtName.Text + " to system. Returning to Login Page");
                Logins form1 = new Logins();
                this.Close();
                form1.Show();
        }  

            //Back Button for redirecting to login page
            private void Back_Click(object sender, EventArgs e)
            {
                Logins form1 = new Logins();
                this.Close();
            }
    }
    
}
