﻿using System;
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
        

        public FormMenu()
        {
            
            InitializeComponent();
            
                //sound.play_menu();
            
            button_start.MouseEnter += (s, e) => {
                button_start.ForeColor = Color.Coral;//change color to coral
            };
            button_start.MouseLeave += (s, e) => {
                button_start.ForeColor = Color.Blue;//change color back
            };

            
            

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

        private void FormMenu_Load(object sender, EventArgs e)
        {
            if (check_sound.Checked)
            {
                sound.play_menu();
            }

            // button_start.FlatAppearance.BorderSize = 0;
            //    button_start.FlatStyle = FlatStyle.Flat;
        }
       
        private void button_exit_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound_button_exit);
            player.PlaySync();
            //sound.play_button_exit();

            this.Close();
        }
        private void start_selectionForm()
        {
            FormLevelSelect levelSelect = new FormLevelSelect();
            levelSelect.ShowDialog();
        }
        private void button_start_Click(object sender, EventArgs e)
        {
            // sound.play_button_exit();
            //start_level1();
            start_selectionForm(); 
        }
      
        private void button_start_MouseEnter(object sender,EventArgs e)
        {
          
        }
        
        private void check_sound_CheckedChanged(object sender, EventArgs e)
        {
            if(check_sound.Checked)
            {
                sound.sound_on();
                check_sound.Text = "Sound ON";
                sound.play_button_exit();
                sound.play_menu(); 
            }
            else
            {
                sound.sound_off();
                check_sound.Text = "Sound Off";
                sound.dont_play_menu();           
            }
        }

        private void picture_background_Click(object sender, EventArgs e)
        {

        }
    }
}
