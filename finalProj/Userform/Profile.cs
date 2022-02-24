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
   
    public partial class Profile : Form
    {
        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;

        string date = DateTime.Now.ToString("M/d/yyyy");

        public Profile()
        {
            InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            //Welcomes users using name of logged in user
            Welcome.Text = "Welcome " + Logins.username;

            //display date
            labelDate.Text = date;

            //Fill Listbox with users Enties
            string queryString = "select *from dbo.Entry";

            try
            {
                cnn.Open();
                command = new SqlCommand(queryString, cnn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (Logins.username == (reader["Name"].ToString())) {
                        this.EntryBox.Items.Add(reader["Name"].ToString() + "-" + reader["Date"].ToString() + "-" + reader["Title"].ToString() + "-" + reader["Description"].ToString());
                    }
                    else
                    {
                        this.EntryBox.Items.Add("No entries");
                    }
                }
            }
            catch (SqlException ex)
            {
                 label2.Text = ("Error in SQL! " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            //Fill Listbox with users Games
            queryString = "select *from dbo.Game";

            try
            {
                cnn.Open();
                command = new SqlCommand(queryString, cnn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (Logins.username == (reader["Author"].ToString()))
                    {
                        this.GameBox.Items.Add(reader["Name"].ToString() + "-" + reader["Price"].ToString() + "-" + reader["Genre"].ToString());
                    }
                    else
                    {
                        this.GameBox.Items.Add("No entries");
                    }
                }
            }
            catch (SqlException ex)
            {
                label2.Text = ("Error in SQL! " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

        }

        //New Entry button for opening Journal entry form
        private void newEntry_Click(object sender, EventArgs e)
        {
            this.Close();
            Entry entryform = new Entry();
            entryform.Show();
            
        }

        // New Game button for opening up Game Wishlist form
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Game gameform = new Game();
            gameform.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Logins form = new Logins();
            form.Show();
            this.Close();
        }

        // View/ Edit button for journal Entries
        private void View_Click(object sender, EventArgs e)
        {
            String entry = EntryBox.SelectedItem.ToString();
            Char SeparatingCharacter = '-';
            String[] Variables = entry.Split(SeparatingCharacter);
            int counter = 0;
            foreach(var Variable in Variables)
            {
                Variables[counter] = Variable;
                counter++;
            }

            Entry EditForm = new Entry(Variables);
            EditForm.Show();
            this.Close();
            
        }

        // View/ Edit button for Gaming Entries
        private void View2_Click(object sender, EventArgs e)
        {
            String entry = GameBox.SelectedItem.ToString();
            Char SeparatingCharacter = '-';
            String[] Variables = entry.Split(SeparatingCharacter);
            int counter = 0;
            foreach (var Variable in Variables)
            {
                Variables[counter] = Variable;
                counter++;
            }
          
            Game EditForm = new Game(Variables);
            EditForm.Show();
            this.Close();
        }

        //Delete For Selected Game
        private void Delete2_Click(object sender, EventArgs e)
        {
            String entry = GameBox.SelectedItem.ToString();
            Char SeparatingCharacter = '-';
            String[] Variables = entry.Split(SeparatingCharacter);
            int counter = 0;
            foreach (var Variable in Variables)
            {
                Variables[counter] = Variable;
                counter++;
            }

            String queryString = "DELETE FROM dbo.Game WHERE Name = '"+Variables[0]+"';";
            try
            {
                cnn.Open();
                command = new SqlCommand(queryString, cnn);
                SqlDataReader reader = command.ExecuteReader();
                label2.Text = Variables[0] + " Was Successfully Deleted";

            }

            catch (SqlException ex)
            {
                label2.Text = ("Error in SQL! " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        //Delete For Selected Journal entry
        private void Delete_Click(object sender, EventArgs e)
        {
            String entry = EntryBox.SelectedItem.ToString();
            Char SeparatingCharacter = '-';
            String[] Variables = entry.Split(SeparatingCharacter);
            int counter = 0;
            foreach (var Variable in Variables)
            {
                Variables[counter] = Variable;
                counter++;
            }

            String queryString = "DELETE FROM dbo.Entry WHERE Title ='"+Variables[4]+"';";
            try
            {
                cnn.Open();
                command = new SqlCommand(queryString, cnn);
                SqlDataReader reader = command.ExecuteReader();
                label2.Text = Variables[4] + " Was Successfully Deleted";

            }

            catch (SqlException ex)
            {
                label2.Text = ("Error in SQL! " + ex.Message);
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
