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
using User.Dao;
using User.Entities;

namespace Userform
{
   
    public partial class Profile : Form
    {
        String connectionString = null;
        SqlConnection cnn;
        //SqlCommand command;
        GameDao gDao = new GameDao();
        EntryDao EDao = new EntryDao();
        int indexHolder = 0;
        int indexHolder2 = 0;

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

            //Populate Listbox Journal Entries
            List<Entrys> Entries = EDao.ReadAll(Logins.username);
            foreach(Entrys ent in Entries)
            {
                EntryBox.Items.Add(ent.Title);
            }
            

            //Populate Gridview Games
            List<Games> Games = gDao.ReadAll(Logins.username);
            GridGames.DataSource = Games;
            GridGames.Font = new Font("Times", 14);
            
            

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
            indexHolder = EntryBox.SelectedIndex;
            List<Entrys> Entries = EDao.ReadAll(Logins.username);
            Entrys CurrEntry = Entries[indexHolder];
            Entry EditForm = new Entry(CurrEntry);
            EditForm.Show();
            this.Close();

        }
        
        // View/ Edit button for Gaming Entries
        private void View2_Click(object sender, EventArgs e)
        {
            String Sgame = GridGames.Rows[indexHolder2].Cells[0].Value.ToString();
            List<Games> games = gDao.ReadAll(Logins.username);
            Games selgame = games[indexHolder2];
            Game Gameform = new Game(selgame);
            Gameform.Show();
            this.Close();
            label2.Text = Sgame;


        }

        //Delete For Selected Game
        private void Delete2_Click(object sender, EventArgs e)
        {
            String Dgame = GridGames.Rows[indexHolder2].Cells[0].Value.ToString();
            List<Games> games = gDao.ReadAll(Logins.username);
            Games selgame = games[indexHolder2];
            label2.Text = gDao.DeleteEntry(selgame.Name);
            
        }

        //Delete For Selected Journal entry
        private void Delete_Click(object sender, EventArgs e)
        {
            indexHolder = EntryBox.SelectedIndex;
            List<Entrys> Entries = EDao.ReadAll(Logins.username);
            Entrys CurrEntry = Entries[indexHolder];
            label2.Text = EDao.DeleteEntry(CurrEntry.Title);
        }

           

        private void GridGames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           indexHolder2 = e.RowIndex;

        }
    }
    
}
