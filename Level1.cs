﻿using Project.Models;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project
{
    

    public partial class Level1 : Form
    {
        public Image dwarfSheet;//for sprites 
        public Entity player;

        //bool isJumping = false;
        public Level1()
        {
            
            InitializeComponent();


            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);
            
            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            init();
            
        }
        
        public void OnKeyUp(object sender,KeyEventArgs e)
        {
            player.dirX = 0;
            player.dirY = 0;
            player.isMoving = false;
            player.setAnimationConfiguration(0);
        }

        public void init()
        {
            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Dwarf1.png"));

            player = new Entity(200, 200, Hero.IdleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, dwarfSheet);
           
            timer1.Start();

        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -1;
                    player.isMoving = true;
                    player.setAnimationConfiguration(1);
                    break;

                case Keys.S:
                    player.dirY = 1;
                    player.isMoving = true;
                    player.setAnimationConfiguration(1);
                    break;

                case Keys.A:
                    player.dirX = -1;
                    player.isMoving = true;
                    player.flip = -1;
                    player.setAnimationConfiguration(1);
                    break;

                case Keys.D:
                    player.dirX = 1;
                    player.isMoving = true;
                    player.flip = 1;
                    player.setAnimationConfiguration(1);
                    break;
                case Keys.E:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoving = false;
                    player.setAnimationConfiguration(2);

                    break;

            }
          

        }
        
        public void Update(object sender, EventArgs e)
        {
            if (player.isMoving)
                player.Move();

            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // g.DrawImage(player.spriteSheet, new Rectangle(new Point(player.posX, player.posY), new Size(player.size, player.size)), 0, 0, player.size, player.size , GraphicsUnit.Pixel);
            player.PlayAnimation(g);
        }

        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                sound.play_menu();
                return true;///зробити запрос при закритті вікно "ЗАКІНЧИТИ ЛВЛ ЧИ ПРОДОВЖИТИ";
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void exit_level1_Click(object sender, EventArgs e)
        {
            this.Close();

            sound.play_menu();
        }

        private void Level1_Load(object sender, EventArgs e)
        {
            
        }

   
        private void bottom_Click(object sender, EventArgs e)
        {

        }

        
    }
}
