using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassInventory
{
    public partial class Form1 : Form
    {
        List<Player> playerInventory = new List<Player>();               // TODO - create a List to store all inventory objects

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name, age, team, position;                           // TODO - gather all information from screen 
            name = newNameInput.Text;
            age = ageInput.Text;
            team = teamInput.Text;
            position = positionInput.Text;

            Player tempPlayer = new Player(name, age, team, position);      // TODO - create object with gathered information

            playerInventory.Add(tempPlayer);                // TODO - add object to global list

            // TODO - display message to indicate addition made
            label1.Text = "";
            label1.Text += tempPlayer.name + ", "
                    + tempPlayer.age + ", "
                    + tempPlayer.team + ", "
                    + tempPlayer.position + " - Added\n";
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            // This is to be completed in Part II. You will use 
            // Lambda Expressions.
            //---------------------------
            Player removing = playerInventory.Find(x => x.name == $"{removeInput.Text}");

            int index = playerInventory.FindIndex(n => n.name == $"{removeInput.Text}");
            if (index >= 0)                        // TODO - if object is in list remove it
            {
                playerInventory.RemoveAt(index);

                label1.Text = "";
                label1.Text += removing.name + ", "
                        + removing.age + ", "
                        + removing.team + ", "
                        + removing.position + " - Removed\n";            // TODO - display message to indicate deletion made
            }
            else
            {
                label1.Text = "";
                label1.Text += "Player Not Found";
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // This is to be completed in Part II. You will use 
            // Lambda Expressions.
            //---------------------------

            // TODO - if object entered exists in list show it
            // TODO - else show not found message

            Player searched = playerInventory.Find(x => x.name == $"{searchInput.Text}");

            int index = playerInventory.FindIndex(n => n.name == $"{searchInput.Text}");
            if (index >= 0)
            {
                label1.Text = "";
                label1.Text += searched.name + ", "
                        + searched.age + ", "
                        + searched.team + ", "
                        + searched.position + "\n";
            }
            else
            {
                label1.Text = "";
                label1.Text += "Player Not Found";
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // TODO - show all objects in list. Use a foreach loop.
            playerInventory = playerInventory.OrderBy(x => x.team).ThenBy(x => x.name).ToList();
            label1.Text = "";
            foreach (Player tempPlayer in playerInventory)
            {
                label1.Text += tempPlayer.name + ", " + tempPlayer.age + ", " + tempPlayer.team + ", " + tempPlayer.position + "\n";
            }

        }
    }
}
