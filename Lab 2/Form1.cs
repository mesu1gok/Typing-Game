using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        const int N = 3; 
        Label[] labels = new Label[N];

        Random rand = new Random();

        int points = 0;

        int speedcheck = 0;

        bool GameOver = false;  
        public Form1()
        {
            InitializeComponent();
            timer1.Start();

            label4.Text = " Points : " + points;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labels[0] = label1;
            labels[1] = label2;
            labels[2] = label3;
            
                        for (int i = 0; i < N; i++)
                        {
                            labels[i].Top = 0;
                            labels[i].Left = rand.Next(0, panel1.Width - labels[i].Width);
                            labels[i].Text = Convert.ToString(Convert.ToChar(rand.Next(65, 91)));


                        }

            label4.Text = " Points : " + points;
        }

        // This event triggers every tick to move labels down and check for boundaries
        private void timer1_Tick(object sender, EventArgs e)
        {
            

            for (int i = 0; i < N; i++)
            {
                labels[i].Top += 5;

                if (labels[i].Top > panel1.Height - labels[i].Height)
                {
                    labels[i].Top = 0;
                    labels[i].Left = rand.Next(0, panel1.Width - labels[i].Width);
                    labels[i].Text = Convert.ToString(Convert.ToChar(rand.Next(65, 91)));

                    points = points - 5;
                    label4.Text = " Points : " + points;
                    
                }

                
            }

            
        }
        // Handles user input and compares pressed key with active labels
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool correctKey = false;


            for (int i = 0; i < N; i++)
            {
                if (e.KeyChar == Convert.ToChar(labels[i].Text))
                {
                    correctKey = true;

                    labels[i].Top = 0;
                    labels[i].Left = rand.Next(0, panel1.Width - labels[i].Width);
                    labels[i].Text = Convert.ToString(Convert.ToChar(rand.Next(65, 91)));

                }

            }
            if (correctKey)
            {
                points = points + 1;

            }
            else
            {
                points = points - 1;
            }
            // Increases game speed every time the player gains 5 points
            if (points >= 5 && (points / 5 > speedcheck))
            {
                ++speedcheck;
                timer1.Interval = timer1.Interval - 100;
            }

            label4.Text = " Points : " + points;

            if (points < 0)
            {
                timer1.Stop();
                MessageBox.Show("Game Over!");
                GameOver = true;
                label4.Text = "Game Over!";
                this.Close();
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
         
        }
    }
}