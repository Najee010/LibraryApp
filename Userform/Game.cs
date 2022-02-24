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
    public partial class Game : Form
    {
        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;
        Games game;
        
        

        public Game()
        {
           
            InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);
        
            
        }
        public Game(Games game)
        {
            InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= GamesDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);
            this.game = game;


            //Putting Saved values back into Form for edit
            txtName.Text = game.Name;
            txtPrice.Text = game.Price.ToString();
            txtGenre.Text = game.Genre;
            txtAuthor.Text = Logins.username;
        }

        private void Save_Click(object sender, EventArgs e)
        {

            try
            {
                cnn.Open();
                command = new SqlCommand("Insert into dbo.Game values(@Author,@Name,@Price,@Genre)", cnn);
                command.Parameters.AddWithValue("@Author", this.txtAuthor.Text);
                command.Parameters.AddWithValue("@Name", this.txtName.Text);
                command.Parameters.AddWithValue("@Price", int.Parse(this.txtPrice.Text));
                command.Parameters.AddWithValue("@Genre", this.txtGenre.Text);


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

        // Used for convenience, keeping The user known
        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
            txtAuthor.Text = Logins.username;
        }

        //Edit Button
        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                command = new SqlCommand("Update dbo.Game Set Name = @name,Price = @Price, Genre =@Genre Where Name = @currentGame", cnn);
                command.Parameters.AddWithValue("@currentGame", this.txtName.Text);
                command.Parameters.AddWithValue("@Name", this.txtName.Text);
                command.Parameters.AddWithValue("@Price", int.Parse(this.txtPrice.Text));
                command.Parameters.AddWithValue("@Genre", this.txtGenre.Text);


                int r = command.ExecuteNonQuery();
                Message.Text = "Edit Stored Successfully";
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
