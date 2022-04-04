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
        UserDao uDao = new UserDao();
        Users user = new Users();


        public static string username;
        Profile ProfilePage = new Profile();

        public Logins()
        {
            InitializeComponent();           
        }

        public object Response { get; private set; }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Login Button
        private void button1_Click(object sender, EventArgs e)
        {
            //Users user = new Users(txtName.Text, txtPassword.Text, "");
            try
            {
                user = uDao.getUser(txtName.Text);
                //Logins.username saved to load profile information
                username = user.Name;

                if (user.Name == txtName.Text && user.Password == txtPassword.Text)
                {
                    ProfilePage.Show();
                    this.Hide();
                }
                else
                {
                    Message.Text = "Incorrect Username or Password, Try again pls";
                }
            }
            catch (Exception)
            {
                Message.Text = "User does not exist, Try again";
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