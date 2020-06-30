using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektC
{
    public partial class Form1 : Form
    {
        //true = X turn, False = Y turn
        bool turn = true;
        int turnCount = 0; 

        public Form1()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newGaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stworzona przez Radosława");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button_click(object sender, EventArgs e)
        {
            // Button clicking properties 
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
        }

        private void checkForWinner()
        {
            // Checking the winner of the game 
            bool thereIsAwinner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text))
                thereIsAwinner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text))
                thereIsAwinner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text))
                thereIsAwinner = true;
            if(thereIsAwinner)
            {
                String winner = "";
                    if (turn)
                    winner = "0";
                else
                    winner = "X";
                MessageBox.Show(winner + "Wygrywa!");
            }
        }

    }
}
