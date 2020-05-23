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
    public partial class Contrl : Form
    {
        public Contrl()
        {
            InitializeComponent();
            button_exit.MouseEnter += (s, e) => {
                button_exit.ForeColor = Color.White;//change color to coral
            };
            button_exit.MouseLeave += (s, e) => {
                button_exit.ForeColor = Color.Aqua;//change color back
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Contrl_Load(object sender, EventArgs e)
        {

        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
