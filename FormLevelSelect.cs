﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
namespace Project
{
    public partial class FormLevelSelect : Form
    {
        //public 
        public FormLevelSelect()
        {
            InitializeComponent();
            
            
        }
        
        private void FormLevelSelect_Load(object sender, EventArgs e)
        {

        }
        
        private void start_level1()
        {
            Level1 level = new Level1();
            level.ShowDialog();     
        }

        private void LEVEL1_button_enter_Click(object sender, EventArgs e)
        {
            sound.play_button_exit();
            start_level1();
        }
        //private void KeyHop(object sender,KeyEventArgs e)
        //{
        //    switch(e.KeyCode)
        //    {
        //        case Keys.Escape: this.Close();
        //            break;
        //           escape_Pressed = true;
        //    }
        //}
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                //sound.play_menu();
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
            
        }
        private void Wait(double seconds)
        {
            int ticks = System.Environment.TickCount + (int)Math.Round(seconds * 1000.0);
            while (System.Environment.TickCount < ticks)
            {
                Application.DoEvents();
            }
        }

        private void exit_from_selecting_Click(object sender, EventArgs e)
        {

            if (sound.if_music())
            //if (Program.fm.check_sound.Checked)
            {
                axWindowsMediaPlayer1.URL = "C:\\Users\\admin\\Desktop\\projectGITHUB\\Resources\\sound_button_exit.wav";
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            //SoundPlayer player = new SoundPlayer(Properties.Resources.sound_button_exit);//@"C:\Users\admin\Desktop\projectGITHUB\Resources\sound_button_exit.wav");
            //player.PlaySync();
            Wait(0.4);

            this.Close();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer2_Enter(object sender, EventArgs e)
        {

        }
    }
}
