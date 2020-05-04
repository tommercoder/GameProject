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
using static Project.Enemies.Enemy;

namespace Project
{
    public partial class Level1 : Form
    {
        
        public Image dwarfSheet;//for sprites 
       
        public Image weaponSheet;
        public Image weaponSheet1;
        public Image weaponSheet2;
        
        public Image mobSheet;
        public Image mobSheet2;

        public Weapons weapon;
        public Weapons weapon1;
        public Weapons weapon2;
        
        public static List<Weapons> weapons = new List<Weapons>();
        
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
            timer2.Interval = 50;

            
            timer1.Tick += new EventHandler(Update);
            timer2.Tick += new EventHandler(EnemyUpdate);

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
            }
            
            if (player.dirX == 0 && player.dirY == 0)
            {
                player.isMoving = false;
                player.setAnimationConfiguration(0); 
            }
        }
       public void WeaponCollide(Entity player, List<Weapons> weapons)
       {
            foreach(Weapons weapon in weapons)
            {
                double distance = GetDistance(weapon.posX, weapon.posY, player.posX, player.posY);
                if (player.Freehands == true)
                    if (distance < 15)
                    {
                        weapon.onFloor = false;
                        player.id = weapon.id;
                        player.Freehands = false;     
                    }
            }
        }

        public void Qpressed(Entity player,List<Weapons> weapons)
        {
            for(int i = 0;i < weapons.Count;i++)
            {
                if(!weapons[i].onFloor)
                {
                    weapons[i].onFloor = true;
                    if(player.posX > player.OldposX + 5)
                        weapons[i].posX = player.posX - 5;
                    else
                        weapons[i].posX = player.posX + 5;
                   
                    if (player.posY > player.OldposY + 5)
                        weapons[i].posY = player.posY - 5;
                else
                        weapons[i].posY = player.posY + 5;
                }
            }
            player.id = 0;
            player.Freehands = true;
        }
        public void init()
        {
            MapController.Init();

            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\player.png"));
            weaponSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon3_1.png"));
            weaponSheet1 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon2.png"));
            weaponSheet2 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon_knight_sword.png"));
            
            mobSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Enemy1.png"));
            mobSheet2 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\enemy2.png"));

            //enemies
            enemies = new List<Enemy>
            {
                new Enemy(200, 520, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(134, 540, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(45, 500, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(45, 380, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),

                
            };

            enemy1 = new Enemy2(300, 300, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2);
            enemy2 = new Enemy2(300, 360, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2);
            enemy3 = new Enemy2(340, 300, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2);
            enemy4 = new Enemy2(360, 340, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2);

            enemies2.Add(enemy1);
            enemies2.Add(enemy2);
            enemies2.Add(enemy3);
            enemies2.Add(enemy4);

            
            //player
            player = new Entity(500, 500, Hero.IdleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, Hero.jumpFrames, dwarfSheet);
            //weapons
            weapon = new Weapons(510, 500, 1, weaponSheet);
            weapon1 = new Weapons(490, 500, 2, weaponSheet1);
            weapon2 = new Weapons(540, 500, 3, weaponSheet2);
            weapons.Add(weapon);
            weapons.Add(weapon1);
            weapons.Add(weapon2);


            timer1.Start();
            //timer2.Start();
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
                    
                    player.isMoving = true;
                        player.setAnimationConfiguration(0);
                        break;

                    case Keys.D:
                        player.dirX = 2;

                        player.isMoving = true;
                        player.flip = 1;
                    player.setAnimationConfiguration(0);
                        break;
                    case Keys.E:
                     player.hitPressed = true;             
                        break;
                case Keys.Q:
                    Qpressed(player, weapons);
                    break;
                case Keys.F:
                    WeaponCollide(player, weapons);
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
            
            
            //foreach (Enemy enemy in enemies)
            //{
            
            //    ////LET ENEMIES UNDERSTAND THAT THEY CANT STAY AT THE SAME POSITION!!
            //}
        
            //foreach(Enemy enemy in enemies)
            for(int i = 0;i < enemies.Count;i++)
            {
                enemies[i].ownMove(player);
            }

            //foreach (Enemy2 enemy2 in enemies2)
            for (int i = 0; i < enemies2.Count; i++)
            {
                enemies2[i].ownMove(player);
            }
           
            
            
               
    
            label2.Text = Convert.ToString("player.posX:" + player.posX);
            label3.Text = Convert.ToString("player.posY:" + player.posY);
            label6.Text = Convert.ToString("player.id:" + player.id);
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

            MapController.DrawMap(g);

            //foreach (Enemy enemy in enemies)
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].playEnemyAnimation(g);
            }

            //foreach (Enemy2 enemy2 in enemies2)
            for (int i = 0; i < enemies2.Count; i++)
            {
                enemies2[i].playEnemyAnimation(g);
            }
           

            player.PlayAnimation(g);

            

            for (int i = 0; i < weapons.Count; i++)
            {   
                    weapons[i].drawWeapon(g, player);
            }

            for (int i = 0;i < weapons.Count;i++)
            {
                
                if (weapons[i].onFloor == false)
                {
                    weapons[i].hit(g, player);

                }
            }        
            if(player.id == 1 )
            weapon.drawHandWeapon(g, player);
            
            else if (player.id == 2 )
                weapon1.drawHandWeapon(g, player);

            else if (player.id == 3 )
                weapon2.drawHandWeapon(g,player);
        }
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
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
