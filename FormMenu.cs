using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
namespace Project
{
    
    public partial class FormMenu : Form
    {
        public bool isCheckedMusicButton = false;
        public game level = new game();
        public FormMenu()
        {
            
            

            InitializeComponent();
            

            button_start.MouseEnter += (s, e) => 
            {
                button_start.ForeColor = Color.White;
            };
            button_start.MouseLeave += (s, e) => {
                button_start.ForeColor = Color.Aqua;
            };

            button1.MouseEnter += (s, e) => {
                button1.ForeColor = Color.White;
            };
            button1.MouseLeave += (s, e) => {
                button1.ForeColor = Color.Aqua;
            };

            button_exit.MouseEnter += (s, e) => {
                button_exit.ForeColor = Color.White;
            };
            button_exit.MouseLeave += (s, e) => {
                button_exit.ForeColor = Color.Aqua;
            };
            button2.MouseEnter += (s, e) => {
                button2.ForeColor = Color.White;
            };
            button2.MouseLeave += (s, e) => {
                button2.ForeColor = Color.Aqua;
            };
           
            KeyDown += new KeyEventHandler(FormMenu_KeyDown);

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                sound.dont_play_menu();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            if (check_sound.Checked)
            {
                sound.play_menu();
            }
           
           
           
        }
        private void Wait(double seconds)
        {
            int ticks = System.Environment.TickCount + (int)Math.Round(seconds * 1000.0);
            while (System.Environment.TickCount < ticks)
            {
                Application.DoEvents();
            }
        }
        private void button_exit_Click(object sender, EventArgs e)
        {

            if(check_sound.Checked)
            {
                axWindowsMediaPlayer1.URL = "C:\\Users\\admin\\Desktop\\projectGITHUB\\Resources\\sound_button_exit.wav";
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            
            Wait(0.4);

            
            sound.dont_play_menu();
           
            this.Close();
            this.Dispose();
        }
        private void start_selectionForm()
        {
            
        }
        
        private void start_level1()
        {
            this.Hide();
            sound.dont_play_menu();
            level.ShowDialog();
           
            
            this.Close();
        }
        private void button_start_Click(object sender, EventArgs e)
        {
            start_level1();
       
            

        }
      
        private void button_start_MouseEnter(object sender,EventArgs e)
        {
          
        }

       
      
        public void check_sound_CheckedChanged(object sender, EventArgs e)
        {
            if(check_sound.Checked)//check_sound is a button name
            {
                level.checkBox1.Checked = true;
                
                sound.sound_on();
                check_sound.Text = "Sound ON";
                sound.play_button_exit();
                sound.play_menu(); 
            }
            else
            {
                level.checkBox1.Checked = false;
                
                sound.sound_off();
                check_sound.Text = "Sound Off";
                sound.dont_play_menu();           
            }
        }

        private void picture_background_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
            
            
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void FormMenu_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void axWindowsMediaPlayer1_Enter_1(object sender, EventArgs e)
        {
              
        }
        private void button2_Click(object sender, EventArgs e)
        {

            Contrl a = new Contrl();
            a.ShowDialog();
        }

        private void Control_Click(object sender, EventArgs e)
        {
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
