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
    public partial class FormLevelSelect : Form
    {
        public FormLevelSelect()
        {
            InitializeComponent();
        }

        private void FormLevelONE_Load(object sender, EventArgs e)
        {

        }
        private void start_level1()
        {
            Level1 level = new Level1();
            level.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound.play_button_exit();
            start_level1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sound.play_button_exit();
            start_level1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sound.play_menu();
            start_level1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sound.play_menu();
            start_level1();
        }
    }
}
