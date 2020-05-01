using Project.Models;
using Project.Entities;
using Project.weapons;
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
using Project.Controller;
using Project.Enemies;

namespace Project
{
    public partial class Level1 : Form
    {
        
        public Image dwarfSheet;//for sprites 
        public Image weaponSheet;
        public Image mobSheet;
        public Image mobSheet2;

        public Weapons weapon;
        public Entity player;

        public Enemy2 enemy1;
        public Enemy2 enemy2;
        public Enemy2 enemy3;
        public Enemy2 enemy4;
        public static List<Enemy> enemies;
        public  List<Enemy2> enemies2  = new List<Enemy2>();
       

        public Level1()
        {
            
            InitializeComponent();

            timer1.Interval = 20;
            timer2.Interval = 20;

            timer2.Tick += new EventHandler(EnemyUpdate);
            timer1.Tick += new EventHandler(Update);
            
            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            init();

            
        }
       
        public void OnKeyUp(object sender,KeyEventArgs e)
        {


            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = 0;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    break;
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
                case Keys.E:
                    player.hitPressed = false;
                    break;
                //case Keys.R:
                //    player.ShiftPressed = false;
                //    break;


                    
            }
            
            if (player.dirX == 0 && player.dirY == 0)
            {
                player.isMoving = false;
                player.setAnimationConfiguration(0);
                player.ShiftPressed = false;
                //player.hitPressed = false;
            }
        }
       
        public void init()
        {
            MapController.Init();

            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\player.png"));
            weaponSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon3_1.png"));
            mobSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Enemy1.png"));
            mobSheet2 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\enemy2.png"));


            enemies = new List<Enemy>
            {
                new Enemy(400, 400, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(400, 440, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(420, 400, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(420, 440, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
            };

            //enemies2 = new List<Enemy2>
            //{
            //    new Enemy2(300, 300, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2),
            //    new Enemy2(300, 340, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2),
            //    new Enemy2(320, 300, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2),
            //    new Enemy2(320, 340, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2),
            //};
            enemy1 = new Enemy2(300, 300, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2);
            enemy2 = new Enemy2(300, 360, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2);
            enemy3 = new Enemy2(340, 300, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2);
            enemy4 = new Enemy2(360, 340, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2);

            enemies2.Add(enemy1);
            enemies2.Add(enemy2);
            enemies2.Add(enemy3);
            enemies2.Add(enemy4);


            weapon = new Weapons(0, 0, weaponSheet);
            player = new Entity(500, 500, Hero.IdleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames,Hero.jumpFrames, dwarfSheet);
           
            timer1.Start();

        }


        public void OnPress(object sender, KeyEventArgs e)
        {
          
           switch (e.KeyCode)
                {
                    case Keys.W:

                        player.dirY = -2;
                        player.isMoving = true;
                    
                        player.setAnimationConfiguration(0);
                        break;
                    case Keys.S:
                        player.dirY = 2;
                        player.isMoving = true;
                        player.setAnimationConfiguration(0);
                        break;

                    case Keys.A:
                        player.dirX = -2;
                        player.flip = -1;
                    //if (enemy1.isMoving)
                    //{ enemy1.flip = -1; }
                    player.isMoving = true;
                        player.setAnimationConfiguration(0);
                        break;

                    case Keys.D:
                        player.dirX = 2;

                        player.isMoving = true;
                        player.flip = 1;
                    //if (enemy1.isMoving)
                    //{ enemy1.flip = 1; }
                    player.setAnimationConfiguration(0);
                        break;
                    case Keys.E:
                        // player.dirX = 0;
                        // player.dirY = 0;
                        //player.isMoving = false;
                        player.hitPressed = true;
                        //player.setAnimationConfiguration();
                        break;
                    case Keys.Space:
                        player.setAnimationConfiguration(1);
                        break;
                    case Keys.Escape:
                        //sound.play_menu();
                        this.Close();
                        break;
                }
       }
            
            
          
            
        


        public void EnemyUpdate(object sedner,EventArgs e)
        {
            foreach(Enemy enemy in enemies)
            {
                //if(enemy.Collide(enemy1))
                //{
                //    enemy.posX -= 1;
                //}
            }
            foreach(Enemy enemy in enemies)
            {
                enemy.ownMove(player);
            }

            foreach (Enemy2 enemy2 in enemies2)
            {
                enemy2.ownMove(player);
            }
            //enemy1.ownMove(player);

            //label1.Text = Convert.ToString(enemy1.posX);
            //label4.Text = Convert.ToString(enemy1.posY);
            label2.Text = Convert.ToString("player.posX:" + player.posX);
            label3.Text = Convert.ToString("player.posY:" + player.posY);
        }
        public void Update(object sender, EventArgs e)
        {

            //PhysicsController.IsCollide(player);

            //enemy1.setEnemyAnimationConfiguration(0);

            
           
            if (player.isMoving)
                player.Move();

            Invalidate();
        }

         private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            MapController.DrawMap(g);

            foreach(Enemy enemy in enemies)
            {
                enemy.playEnemyAnimation(g);
            }

            foreach (Enemy2 enemy2 in enemies2)
            {
                enemy2.playEnemyAnimation(g);
            }
            //enemy1.playEnemyAnimation(g);
            player.PlayAnimation(g);
            weapon.drawWeapon(g, player);

        }

        public void collision()
        {
            
        }
 

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
