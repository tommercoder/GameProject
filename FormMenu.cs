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
    public partial class FormMenu : Form
    {
        
        public FormMenu()
        {
            InitializeComponent();
            button_start.MouseEnter += (s, e) => {
                button_start.ForeColor = Color.Coral;
            };
            button_start.MouseLeave += (s, e) => {
                button_start.ForeColor = Color.Blue;
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // button_start.FlatAppearance.BorderSize = 0;
        //    button_start.FlatStyle = FlatStyle.Flat;
         
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void button_start_Click(object sender, EventArgs e)
        {

            //button_start.Font = new Font(" ", 14, FontStyle.Bold);
            //button_start.ForeColor = Color.Red;
        }

      
        private void button_start_MouseEnter(object sender,EventArgs e)
        {
          

        }
        
        private void check_sound_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
