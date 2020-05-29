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
    public partial class msg : Form
    {
        public msg()
        {
            InitializeComponent();
            label1.Text = "CONGRATULATIONS!!\n" +
                   "YOU WON!!\n" +
                   "PRESS OKAY TO CLOSE THE GAME!";
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
            this.Close();
        }

        private void msg_Load(object sender, EventArgs e)
        {

        }
    }
}
