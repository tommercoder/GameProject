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
    public partial class Level1 : Form
    {
        public Level1()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;///зробити запрос при закритті вікно "ЗАКІНЧИТИ ЛВЛ ЧИ ПРОДОВЖИТИ";
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void exit_level1_Click(object sender, EventArgs e)
        {
            this.Close();
            sound.play_menu();
        }
    }
}
