using Project.Models;
using Project.Entities;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Input;

namespace Project
{


    public partial class Level1 : Form
    {
        public Image dwarfSheet;//for sprites 
        public Entity player;
        public Image grassImg;

        int[,] map;

        const int width = 10;
        const int height = 10;

        public Level1()
        {

            InitializeComponent();


            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            init();

            grassImg = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\ground.png"));

            map = new int[10, 10]
            {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            };
        }
        /* public void createMapw()
             {
             //Graphics g = e.Graphics;
             for (int i=0;i<width;i++)
                 {
             for(int j=0;j<height;j++)
                     {
                     if(map[i,j]==1)
                     {
                         g.DrawImage(grassImg, j * 80, i * 80, new Rectangle(new Point(0, 0), new Size(80, 80)), GraphicsUnit.Pixel);
                     }
                 }
             }
         }*/

        public void OnKeyUp(object sender, KeyEventArgs e)
        {

            player.isMoving = false;
            player.isJumping = false;

            player.dirX = 0;
            player.dirY = 0;
            //if (player.velocityY < 6.0f)
            //    player.velocityY = -6.0f;//double/tripple jump
            if (!player.isJumping)
                player.setAnimationConfiguration(0);
            //  else
            // player.setAnimationConfiguration(5);
        }

        public void init()
        {
            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Dwarf2.png"));

            player = new Entity(500, 500, Hero.IdleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, Hero.jumpFrames, dwarfSheet);

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
                case Keys.Space:
                    player.isJumping = true;
                    //player.dirX = 0;
                    //player.dirY = 0;
                    //player.isMoving = false;

                    if (player.posY == 500)
                        player.velocityY = -9.0f;//jump

                    break;

                case Keys.Escape:
                    this.Close();
                    break;
            }


        }

        public void Update(object sender, EventArgs e)
        {
            ///jumping
            player.velocityY += player.gravity;
            player.posY += player.velocityY;
            player.posX += player.velocityX;

            if (player.posY > 500)
            {
                player.posY = 500;
                player.velocityY = 0;//gravity to posY
            }
            if (player.posX < 10f || player.posX > 190f)
            {
                player.velocityX *= -1;//go back to bottom
            }


            //createMap();
            if (player.isMoving)
                player.Move();


            //if (player.isJumping)
            //    player.jump();


            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(grassImg, j * 70, i * 75, new Rectangle(new Point(0, 0), new Size(70, 75)), GraphicsUnit.Pixel);
                    }
                }
            }
            //}

            // g.DrawImage(player.spriteSheet, new Rectangle(new Point(player.posX, player.posY), new Size(player.size, player.size)), 0, 0, player.size, player.size , GraphicsUnit.Pixel);
            player.PlayAnimation(g);
        }

        public void collision()
        {

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


    }
}