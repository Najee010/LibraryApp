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
        Games game;
        GameDao gDao = new GameDao();

        public Game()
        {
            InitializeComponent();
        }
        public Game(Games game)
        {
            InitializeComponent();

            this.game = game;

            //Putting Saved values back into Form for edit
            txtName.Text = game.Name;
            txtPrice.Text = game.Price.ToString();
            txtGenre.Text = game.Genre;
            txtAuthor.Text = Logins.username;
        }

        //Save a users inputs and attempt to push into SQL
        private void Save_Click(object sender, EventArgs e)
        {
            game = new Games();
            game.Name = txtName.Text;
            game.Price = int.Parse(txtPrice.Text);
            game.Genre = txtGenre.Text;
            Message.Text = gDao.AddGame(Logins.username, game);

        }
        
        //back button
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
            game = new Games();
            game.Name = txtName.Text;
            game.Price = int.Parse(txtPrice.Text);
            game.Genre = txtGenre.Text;
            Message.Text = gDao.EditGame(game);
            
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
