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
    public partial class EnterNickName : Form
    {
        public string nickname;
         FormMenu fm = new FormMenu(); 
       
        public EnterNickName()
        {
            InitializeComponent();
            
            button1.MouseEnter += (s, e) => {
                button1.ForeColor = Color.White;//change color to coral
            };
            button1.MouseLeave += (s, e) => {
                button1.ForeColor = Color.Aqua;//change color back
            };
           
            //KeyDown += new KeyEventHandler(textBox1_KeyDown);
            //KeyUp += new KeyEventHandler(textBox1_KeyUp);
            
        }

      
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void EnterNickName_Load(object sender, EventArgs e)
        {
               
            label1.Text = "Enter NickName:";
  
            this.Controls.Add(label1);
            


            textBox1.AutoSize = false;
            // Add this textbox to form 
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            
            this.Controls.Add(textBox1);
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            
            fm.ShowDialog();
            this.Close();
            
        }
        //private void EnterNickName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;

        //            button1_Click(this, new EventArgs());

        //    }
        //}
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
            fm.label1.Text = textBox1.Text;
            //fm.label1.ForeColor = Color.Aqua;
            fm.level.nicknameRemember = textBox1.Text;
            //if (fm.check_sound.Checked)
            //{
            //    fm.level.checkBox1.Checked = true;
            //}
            //else
            //    fm.level.checkBox1.Checked = false ;
        }
        private void textBox1_KeyUp(object sender,KeyEventArgs e)
        {
            e.Handled = false;
            e.SuppressKeyPress = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
               // Parent.SelectNextControl(textBox1, true, true, true, true);
                e.Handled = e.SuppressKeyPress = true;
                
                button1_Click(this, new EventArgs());
            }
            
                

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
