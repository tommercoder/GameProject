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
        public Level1 level = new Level1();
        public FormMenu()
        {
            
            Program.fm = this;

            InitializeComponent();
            //start_level1();///for level1 
            //sound.play_menu();

            
            button_start.MouseEnter += (s, e) => {
                button_start.ForeColor = Color.White;//change color to coral
            };
            button_start.MouseLeave += (s, e) => {
                button_start.ForeColor = Color.Aqua;//change color back
            };

            button1.MouseEnter += (s, e) => {
                button1.ForeColor = Color.White;//change color to coral
            };
            button1.MouseLeave += (s, e) => {
                button1.ForeColor = Color.Aqua;//change color back
            };

            button_exit.MouseEnter += (s, e) => {
                button_exit.ForeColor = Color.White;//change color to coral
            };
            button_exit.MouseLeave += (s, e) => {
                button_exit.ForeColor = Color.Aqua;//change color back
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

           
            // button_start.FlatAppearance.BorderSize = 0;
            //    button_start.FlatStyle = FlatStyle.Flat;
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

            if (check_sound.Checked)
            {
                axWindowsMediaPlayer1.URL = "C:\\Users\\admin\\Desktop\\projectGITHUB\\Resources\\sound_button_exit.wav";
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            //sound.play_button_exit();
            
            Wait(0.4);

            //SoundPlayer player = new SoundPlayer(Properties.Resources.sound_button_exit);

            //player.PlaySync();
            sound.dont_play_menu();
            //this.Hide();
            this.Close();
        }
        private void start_selectionForm()
        {
            FormLevelSelect levelSelect = new FormLevelSelect();
            levelSelect.ShowDialog();
        }
        
        private void start_level1()
        {
            this.Hide();
            sound.dont_play_menu();
            level.ShowDialog();
            //sound.sound_off();
            
            this.Close();
        }
        private void button_start_Click(object sender, EventArgs e)
        {
            start_level1();
       
            // sound.play_button_exit();
            //start_selectionForm();

        }
      
        private void button_start_MouseEnter(object sender,EventArgs e)
        {
          
        }

        //public bool optionselected
        //{
        //    get
        //    {
        //        return check_sound.checked; }
        //        set {
        //            check_sound.checked = value; } // the set is optional
        //        }

       
        private void check_sound_CheckedChanged(object sender, EventArgs e)
        {
            if(check_sound.Checked)//check_sound is a button name
            {
                //chk = check_sound.Checked;
                //isCheckedMusicButton = true;
                sound.sound_on();
                check_sound.Text = "Sound ON";
                sound.play_button_exit();
                sound.play_menu(); 
            }
            else
            {
                //isCheckedMusicButton = fals
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
            this.Hide();
            EnterNickName en = new EnterNickName();
            en.ShowDialog();
            this.Close();
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
    }
}
