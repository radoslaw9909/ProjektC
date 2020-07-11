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
        #region 
        // Szata graficzna 
        //Prawda = ruch X Fałsz = ruch Y
        bool turn = true;
        int turnCount = 0;



        public Form1()
        {
            InitializeComponent();
        }

        // Wiadomośc help
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stworzona przez Radosława");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // resetowanie punktów w menu
        private void resetujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = "0";
            o_win_count.Text = "0";
            draw_count.Text = "0";
        }
        #endregion
        #region
        //Logika aplikacji 
        // Wyświetlenie X/Y Po kliknięciu na przyciski
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            turnCount++;
            b.Enabled = false;

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

            // Wyświetlanie wyniku gracza
            if (thereIsAwinner)
            {
                disableButtons();

                String winner = "";
              
                if (turn)
                {
                    winner = "O";
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }

                MessageBox.Show(winner + " Zwyciężył!!!");
            } //end if 
            else
            {
                if (turnCount == 9)
                { 
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Remis !");
                }
            }
        } // end checkforwinner

        private void disableButtons()
        // Wyłączanie właściwości przycisków po wygranej 
        {
            foreach (Control c in Controls) 
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch { }
            }
                
        }
        //menu nowej gry
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
        #endregion 
        
        #region
        // reakcja na najechanie na przycisk
        // logika działania przycisków
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
        #endregion
        
    }
}
