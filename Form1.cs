using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Platformer : Form
    {
        private Point p = new Point(100, 100);
        Graphics g;
        /*
        public Bitmap playerTexture = Resource1.xuy;

       
        int i = 5, j = 5;
        int[,] map =
    {
            { 0,0,0,0,0,0,0,0,0,1},
            { 0,0,0,0,0,0,0,0,0,1},
            { 0,0,0,0,0,0,0,0,0,1},
            { 0,0,0,0,0,0,0,0,0,1},
            { 0,0,0,0,0,0,0,0,0,1},
            { 0,0,0,0,0,0,0,0,0,1},
            { 1,1,1,1,1,1,1,1,1,1}
        };*/

        /*private void DrawMap()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(playerTexture, new Rectangle(p.X, p.Y, 100, 100));

            pictureBox1.Refresh();
        }*/

        
        
        public Platformer()
        {

            InitializeComponent();

            this.KeyDown += new KeyEventHandler(Platformer_KeyDown);

            //DrawMap();
                     
        }
       
        private void Platformer_KeyDown(object sender, KeyEventArgs e)
        {


            switch(e.KeyCode)
            {
                case Keys.Enter:
                    
                    player.BackColor = Color.Red;
                    //p.X += 10; 
                    break;
                
            }
           // DrawMap();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }
    }
}
