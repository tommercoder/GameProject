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
    public partial class restartinc : Form
    {
        Level1 lvl1 = new Level1();
        public restartinc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            lvl1.init();
            this.Close();
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
            lvl1.Close();
            
        }
        */
        private void restartinc_Load(object sender, EventArgs e)
        {

        }
    }
}
