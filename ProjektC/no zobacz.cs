using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektC
{
    public partial class Form1 : Form
    {
        //Prawda = ruch X Fałsz = ruch Y
        bool turn = true;
        int turnCount = 0;



        public Form1()
        {
            InitializeComponent();
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
            // Wyświetlenie X/Y Po kliknięciu na przyciski
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;

            b.Enabled = false;
            turnCount++;

            checkForWinner();
        }


        private void checkForWinner()
        {

            bool thereIsAwinner = false;
            // Horyzontalne sprawdzanie wygranego 

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                thereIsAwinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                thereIsAwinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                thereIsAwinner = true;

            // Wertykalne sprawdzanie wygranego 

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                thereIsAwinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                thereIsAwinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                thereIsAwinner = true;

            // Sprawdzanie wygranego po skosie 
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereIsAwinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                thereIsAwinner = true;


            if (thereIsAwinner)
            {
                int pointX = 0;
                int pointY = 0;
                
                disableButtons();

                string winner = "";
                if (turn)
                {
                    winner = "O";
                    pointX++;
                    o_win_count.Text = pointX.ToString();
                }
                else
                {
                    winner = "X";
                    pointY++;
                    x_win_count.Text = pointY.ToString();
                }

                MessageBox.Show(winner + " WINS!!!");
            } //end if 
            else
            {
                if (turnCount == 9)
                {
                    int draw = 0;
                    draw++;
                    draw_count.Text = draw.ToString();
                    MessageBox.Show("Draw!!");
                }
            }
        } // end checkforwinner

        private void disableButtons()
        // Wyłączanie właściwości przycisków po wygranej 
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }
        private void newGaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            
                foreach (Control c in Controls)
                {
                    try
                    {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                    }
                catch { }
                }   
           
        }


        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
        private void buttonEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void buttonLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        // seing whose turn it is when moving on buttons 
        



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void resetujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = "0";
            o_win_count.Text = "O";
            draw_count.Text = "O";
          

        }
    }
}
