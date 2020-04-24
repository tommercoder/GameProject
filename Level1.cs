using Project.Models;
using Project.Entities;
using Project.MapCollision;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Project
{
    public partial class Level1 : Form
    {
        public Image dwarfSheet;//for sprites 
        public Entity player;
        public Image grassImg;
        public int timeOf;
        
        

        public int ButtonPressedW = 0;
        public int ButtonPressedS = 0;
        public int ButtonPressedA = 0;
        public int ButtonPressedD = 0;
        public int mapX = 1;
        public int mapY = 1;

        


        //newMap map = new newMap();
        //int[,] map;
        const int width = 10;
        const int height = 10;


        public Level1()
        {

            InitializeComponent();
            
            
            timer1.Interval = 20;
            
            KeyDown += new KeyEventHandler(OnPress);

            timer1.Tick += new EventHandler(Update);
            //timeOf += 20;
            
            KeyUp += new KeyEventHandler(OnKeyUp);

            init(); 
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            //if (Map.Collide(player))
            //{
            //    label2.Text = "collide";
            //}
            //else
            //    label2.Text = "no collide";

            player.isMoving = false;
            player.isJumping = false;

            player.dirX = 0;
            player.dirY = 0;
            
            player.setAnimationConfiguration(0);
          
            //label2.Text = Convert.ToString(mapX);
            //label3.Text = Convert.ToString("map:" + mapX + mapY);

            //player.posXnow = Math.Floor(player.posX / Map.cellSize);//player current x position
            //player.posYnow = Math.Floor(player.posY / Map.cellSize);//player current y position
            //player.player_position = player.posYnow * Map.mapWidth + player.posXnow;//player current position
            //label2.Text = Convert.ToString("pos:" + player.player_position);
            //label3.Text = Convert.ToString("posX:" + player.posXnow);
            //label4.Text = Convert.ToString("posY:" + player.posYnow);

        }
        
        public void init()
        {
            Map.Init();

            this.Width = Map.GetWidth();
            this.Height = Map.GetHeight();

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Dwarf2.png"));
            player = new Entity (100,100, Hero.IdleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, Hero.jumpFrames, dwarfSheet);

            timer1.Start();

        }
               
        public void OnPress(object sender, KeyEventArgs e)
        {
            
            switch(e.KeyCode)
            {
                case System.Windows.Forms.Keys.W:
                    player.dirY = -1;
                    player.isMoving = true;
         
                    player.setAnimationConfiguration(1);
                    break;
                //if (mapY - 1 != 10)
                //{
                //    player.dirY = -1;
                //    player.isMoving = true;
                //    player.flip = 1;
                //    player.setAnimationConfiguration(1);
                //    ButtonPressedW++;

                //    if (ButtonPressedW == 32)
                //    {
                //        mapY -= 1;
                //        ButtonPressedW = 0;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("asdasdsa");
                //}
                //break;

                case System.Windows.Forms.Keys.S:

                    player.dirY = 1;
                    player.isMoving = true;
                    player.setAnimationConfiguration(1);
                    break;
                    //if (mapY + 1 != 10)
                    //{
                    //    player.dirY = 1;
                    //    player.isMoving = true;
                    //    player.flip = 1;
                    //    player.setAnimationConfiguration(1);
                    //    ButtonPressedS++;

                    //    if (ButtonPressedS == 32)
                    //    {
                    //        mapY += 1;
                    //        ButtonPressedS = 0;
                    //    }
                    //    // else
                    //    // ButtonPressed = 0;

                    //}
                    //else
                    //{

                    //    MessageBox.Show("asdasdsa");
                    //}
                    //break;

                case System.Windows.Forms.Keys.A:
                    player.dirX = -1;
                    player.isMoving = true;
                    player.flip = -1;
                    player.setAnimationConfiguration(1);
                    break;

                    //for(int i = 0;i < 10;i++)
                    //{
                    //    if(map[i,0] == 5) MessageBox.Show("01");
                    //}
                    

                   //if (mapX - 1 != 10)
                   // {
                   //     player.dirX = -1;
                   //     player.isMoving = true;
                   //     player.flip = -1;
                   //     player.setAnimationConfiguration(1);
                   //     ButtonPressedA++;

                   //     if (ButtonPressedA == 32)
                   //     {
                   //         mapX-= 1;
                   //         ButtonPressedA = 0;
                   //     }
                       

                   // }
                   // else
                   // {

                   //     MessageBox.Show("asdasdsa");
                   // }
                   // break;  

                case System.Windows.Forms.Keys.D:

                    player.dirX = 1;
                    player.isMoving = true;
                    player.flip = 1;
                    player.setAnimationConfiguration(1);
                    break;

                    //if (mapX + 1 != 10)
                    //{
                    //    player.dirX = 1;
                    //    player.isMoving = true;
                    //    player.flip = 1;
                    //    player.setAnimationConfiguration(1);
                    //    ButtonPressedD++;

                    //    if (ButtonPressedD == 32)
                    //    {
                    //        mapX += 1;
                    //        ButtonPressedD = 0;
                    //    }
                    //   // else
                    //       // ButtonPressed = 0;

                    //}
                    //else
                    //{

                    //    MessageBox.Show("asdasdsa");
                    //}
                    
                    //break;
                case System.Windows.Forms.Keys.E:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoving = false;
                    player.setAnimationConfiguration(2);
              
                    break;
                
                case System.Windows.Forms.Keys.Space:
                    player.isJumping = true;
                    //to stop infinity jumping if you want it:)
                    player.dirX = 0;
                     player.dirY = 0;
                    player.isMoving = false;


                    //player.velocity.Y = -15.0f;
                    player.setAnimationConfiguration(5);
                    break;
                case System.Windows.Forms.Keys.Escape:
                    this.Close();
                    break;
            }

        }

  
        public void Update(object sender, EventArgs e)
        {
            // jumping
            
            //float time = (float)timeOf;
            //player.velocity += player.gravity * time;
            //player.position += player.velocity * time;
           
            //createMap();
            if (player.isMoving)
                player.Move();

            Invalidate();
        }


        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            Map.DrawMap(g);
            // Map
            //for (int i = 0; i < width; i++)
            //{
            //    for (int j = 0; j < height; j++)
            //    {
            //        if (map[i, j] == 1)
            //        {
            //            g.DrawImage(grassImg, j * 70, i * 75, new System.Drawing.Rectangle(new System.Drawing.Point(0, 0), new Size(70, 75)), GraphicsUnit.Pixel);
            //        }
            //    }

            //}
            //if (player.isJumping)
            //    player.PlayJumpAnimation(g);
            //else

            player.PlayAnimation(g);
        }

        
       

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Space)
        //    {

        //    }
        //    if (keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        sound.play_menu();
        //        return true;///зробити запрос при закритті вікно "ЗАКІНЧИТИ ЛВЛ ЧИ ПРОДОВЖИТИ";
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        private void exit_level1_Click(object sender, EventArgs e)
        {
            // this.Close();
            //sound.play_menu();
        }

        private void Level1_Load(object sender, EventArgs e)
        {

        }


        private void bottom_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}