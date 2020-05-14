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
using System.Numerics;
using Project.chests_and_staff;
using System.Windows;


namespace Project
{
    public partial class Level1 : Form
    {
        public static Point delta;
        
        public Image dwarfSheet;//for sprites 
       
        public Image weaponSheet;
        public Image weaponSheet1;
        public Image weaponSheet2;
        public Image chest;
        public Image mobSheet;
        public Image mobSheet2;
        public Image heartsImage;

        public hearts hearts;

        public Weapons weapon;
        public Weapons weapon1;
        public Weapons weapon2;
        
        public static List<Weapons> weapons = new List<Weapons>();
        public static List<Enemy> enemies;
        public Entity player;
        public staff Chest;
        public static bool Wpressed;
        public static bool Spressed;
        public static bool Apressed;
        public static bool Dpressed;
        public static bool Xpressed;
        public static bool collide= false;
        public static bool hitPlayer = false;


        public Level1()
        {
            this.BackColor = Color.FromArgb(47, 47, 46);
            
            InitializeComponent();

            timer1.Interval = 20;
            timer2.Interval = 20;
           timer3.Interval = 10;
            
            timer1.Tick += new EventHandler(Update);
            timer2.Tick += new EventHandler(EnemyUpdate);
            timer3.Tick += new EventHandler(checkTimeCollide);
            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
            delta = new Point(0, 0);//camera
            init();

            
        }
       
        public void OnKeyUp(object sender,KeyEventArgs e)
        {
            if (player.HP == 0)
            {
                restartinc r = new restartinc();
                r.ShowDialog();
                
            }
            
            switch (e.KeyCode)
            {

                case Keys.W:
                    player.dirY = 0;
                    Wpressed = false;
 
                    break;
                case Keys.S:
                    player.dirY = 0;
                    Spressed = false;
          
                    break;
                case Keys.A:
                    player.dirX = 0;
                    Apressed = false;
             
                    break;
                case Keys.D:
                    player.dirX = 0;
                    Dpressed = false;
                
                    break;
                case Keys.E:
                    player.hitPressed = false;
                    break;
                case Keys.X:
                    Xpressed = false;
                    break;
            }
            
            if (player.dirX == 0 && player.dirY == 0)
            {
                player.isMoving = false;
                player.setAnimationConfiguration(0);
               // collide = false;
            }
            
        }
       public void WeaponCollide(Entity player, List<Weapons> weapons)
       {
            foreach(Weapons weapon in weapons)
            {
                double distance = GetDistance(weapon.posX + Level1.delta.X - Level1.delta.X, weapon.posY + Level1.delta.Y - Level1.delta.Y, player.posX + Level1.delta.X - Level1.delta.X, player.posY + Level1.delta.Y - Level1.delta.Y);
                if (player.Freehands == true)
                    if (distance < 15)
                    {
                        weapon.onFloor = false;
                        player.id = weapon.id;
                        player.Freehands = false;     
                    }
            }
        }
        public void chestOpen(staff staff)
        {
            //foreach (Weapons weapon in weapons)
            //{
            double distance = GetDistance(player.posX,player.posY,staff.posX,staff.posY);

            if (distance < 20)
            {
                staff.isOpened = true;
                
                label1.Text = "chest opened";


            }
            else
                label1.Text = " >20";
            //}
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
        public  void init()
        {
            MapController.Init();

            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\player.png"));
            weaponSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon3_1.png"));
            weaponSheet1 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon2.png"));
            weaponSheet2 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon_knight_sword.png"));
            chest = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\chest.png"));
            mobSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Enemy1.png"));
            mobSheet2 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\enemy2.png"));
            heartsImage = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\hearts2.png"));

            //enemies
            enemies = new List<Enemy>
            {
                new Enemy(200, 520, 1,Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(134, 540,1, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(45, 500,1, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(45, 380, 1,Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(350, 350, 2,Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2),
                new Enemy(300, 350,2, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2),

            };

            
            
            //player
            player = new Entity(32, 32, Hero.IdleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, Hero.jumpFrames, dwarfSheet);
            //chest
            Chest = new staff(100, 40, 1,Hero.IdleChestFrames, Hero.OpenChestFrames, chest);


            //hearts image
            hearts = new hearts(580, 10, Hero.fullHearts, Hero.heartsFrames, heartsImage);
            //weapons
            weapon = new Weapons(90, 30, 1, weaponSheet);
            weapon1 = new Weapons(80, 30, 2, weaponSheet1);
            weapon2 = new Weapons(70, 30, 3, weaponSheet2);
            weapons.Add(weapon);
            weapons.Add(weapon1);
            weapons.Add(weapon2);


            timer1.Start();
            timer2.Start();
            timer3.Start();
        }


        public void OnPress(object sender, KeyEventArgs e)
        {
            
                switch (e.KeyCode)
                {
                 case Keys.W:
                    //for (int pj = ((int)player.posX + 16) / MapController.cellSize; pj < (player.posX + MapController.cellSize) / (MapController.cellSize + 1); pj++)
                    //{
                    //    for (int pi = ((int)player.posY + 16) / MapController.cellSize; pi < (player.posY + MapController.cellSize) / (MapController.cellSize + 1); pi++)
                    //    {
                    //        label1.Text = Convert.ToString(pj + " " + pi);
                    //        if (pj < MapController.mapHeight - 1 && pj >= 1 && pi < MapController.mapWidth - 1 && pi > 0)
                    //        {

                    //            for (int i = 0; i < 3; i++)
                    //            {
                    //                if (MapController.map[pj, pi - 1] != 0)
                    //                {

                    //                    posx = pj;
                    //                    posy = pi;
                                        player.dirY = -3;
                                        Wpressed = true;
                                        player.isMoving = true;
                                        player.setAnimationConfiguration(0);
                    
                    //                    collide = false;
                    //                }
                    //                else
                    //                {
                    //                    player.posY += 3;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    break;
                 case Keys.S:
                    //for (int pj = ((int)player.posX + 16) / MapController.cellSize; pj < (player.posX + MapController.cellSize) / (MapController.cellSize + 1); pj++)
                    //{
                    //    for (int pi = ((int)player.posY + 16) / MapController.cellSize; pi < (player.posY + MapController.cellSize) / (MapController.cellSize + 1); pi++)
                    //    {
                    //        label1.Text = Convert.ToString(pj + " " + pi);
                    //        if (pj < MapController.mapHeight - 1 && pj >= 1 && pi < MapController.mapWidth - 1 && pi > 0)
                    //        {
                    //            for (int i = 0; i < 3; i++)
                    //            {
                    //                if (MapController.map[pj, pi + 1] != 0)
                    //                {
                    //                    posx = pj;
                    //                    posy = pi;
                                        player.dirY = 3;
                                        Spressed = true;
                                        player.isMoving = true;
                                        player.setAnimationConfiguration(0);
                                       // collide = false;
                    //                }
                    //                else
                    //                {
                    //                    player.posY -= 3;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    break;
                case Keys.A:
                    //for (int pj = ((int)player.posX + 16) / MapController.cellSize; pj < (player.posX + MapController.cellSize) / (MapController.cellSize + 1); pj++)
                    //{
                    //    for (int pi = ((int)player.posY + 16) / MapController.cellSize; pi < (player.posY + MapController.cellSize) / (MapController.cellSize + 1); pi++)
                    //    {
                    //        label1.Text = Convert.ToString(pj + " " + pi);
                    //        label2.Text = Convert.ToString(MapController.map[pj, pi]);
                    //        if (pj < MapController.mapHeight - 1 && pj >= 1 && pi < MapController.mapWidth - 1 && pi > 0)
                    //        {
                    //            for (int i = 0; i < 3; i++)
                    //            {
                    //                if (MapController.map[pj - 1, pi] != 0)
                    //                {
                    //                    posx = pj;
                    //                    posy = pi;
                                        Apressed = true;
                                        player.dirX = -3;
                                        player.flip = -1;
                                        player.isMoving = true;
                                        player.setAnimationConfiguration(0);
                    //                    collide = false;

                    //                }
                    //                else
                    //                {
                    //                    player.posX += 3;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    break;
                case Keys.D:

                    //for (int pj = ((int)player.posX + 16) / MapController.cellSize; pj < (player.posX + MapController.cellSize) / (MapController.cellSize + 1); pj++)
                    //{
                    //    for (int pi = ((int)player.posY + 16) / MapController.cellSize; pi < (player.posY + MapController.cellSize) / (MapController.cellSize + 1); pi++)
                    //    {
                    //        label1.Text = Convert.ToString(pj + " " + pi);
                    //        label1.Text = Convert.ToString(MapController.map[pj, pi]);
                    //        if (pj < MapController.mapHeight - 1 && pj >= 1 && pi < MapController.mapWidth - 1 && pi > 0)
                    //        {
                    //            for (int i = 0; i < 3; i++)
                    //            {
                    //                if (MapController.map[pj + 1, pi] != 0)
                    //                {

                    //                    posx = pj;
                    //                    posy = pi;
                                        Dpressed = true;
                                        player.dirX = 3;
                                        player.flip = 1;
                                        player.isMoving = true;
                                        player.setAnimationConfiguration(0);
                                        //collide = false;
                    //                }
                    //                else
                    //                {
                    //                    player.posX -= 3;

                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    break;
                          
                
                //hit
                case Keys.E:
                                player.hitPressed = true;
                                break;

                            case Keys.Q:
                    //throw out
                                Qpressed(player, weapons);
                                break;
                            case Keys.F:
                                WeaponCollide(player, weapons);
                                break;
                            case Keys.X:
                                Xpressed = true;
                                if (!Chest.isOpened)
                                {
                                    chestOpen(Chest);
                                    double distance = GetDistance(player.posX, player.posY, Chest.posX, Chest.posY);

                                    if (distance < 20)
                                        Chest.setAnimation(1);
                                }

                                break;
                            case Keys.Space:
                    
                               // player.setAnimationConfiguration(1);
                                break;
                            case Keys.Escape:
                                //sound.play_menu();
                                this.Close();
                                break;
                        }


      

        }





        public void checkTimeCollide(object sender, EventArgs e)
        {
            PhysicsController.Collide(player);
           // if (!player.isMoving && PhysicsController.timer == 3)
           //     player.isMoving = true;
            
            //////////////////////////////////////////////////////////////////////
            //foreach (collideobjects col in MapController.collideList)
            //{

            //    if (player.posX < col.posX + col.size &&

            //        player.posX + player.size - 16 > col.posX &&

            //        player.posY < col.posY + col.size &&

            //        player.posY + player.size - 16 > col.posY)                       ///square to square collision
            //    {
            //        label2.Text = Convert.ToString("playerposX:" + player.posX);
            //        label3.Text = Convert.ToString("playerposY" + player.posY);
            //        label1.Text = "collide";
            //        player.isMoving = false;
            //        collide = true;
            //    }
            //}
        }


        public void EnemyUpdate(object sedner,EventArgs e)
        {
            foreach(Enemy enemy in enemies)
            {
                enemy.hitEntity(player);
            }

            //foreach (Enemy enemy in enemies)
            //{

            //    ////LET ENEMIES UNDERSTAND THAT THEY CANT STAY AT THE SAME POSITION!!
            //}

            //foreach(Enemy enemy in enemies)


            //for (int i = 0; i < enemies.Count; i++)
            //{
            //    enemies[i].IfEnemiesCollide(enemies);

            //}
            for (int i = 0;i < enemies.Count;i++)
            {
                enemies[i].ownMove(player);
   
            }


            //for (int i = 0; i < enemies.Count; i++)
            //{
            //    if(!enemies[i].isMoving)
            //    enemies[i].posX += enemies[i].EnemySpeedX;

            //}

            label1.Text = Convert.ToString(collide);
            label3.Text = Convert.ToString("player.posX:" + player.posX);
            label4.Text = Convert.ToString("player.posY:" + player.posY);
            label5.Text = Convert.ToString("oldposX:" + player.OldposX);
            label6.Text = Convert.ToString("oldposY:" + player.OldposY);

            label1.Text = Convert.ToString(hitPlayer);
        }

        public  void SetTextForLabel(string myText)
        {
            this.label1.Text = myText;
        }
        
        public void Update(object sender, EventArgs e)
        {
            

            //if (player.posX > player.OldposX + 100)
            //    player.OldposX = player.OldposX + 100;
           

            //if (player.posY > player.OldposY + 100)
            //    player.OldposY = player.OldposY + 100;
           

            //if (PhysicsController.Collide(player))
            //{

            //    if (player.dirY < 0)
            //        player.posY += 3;

            //    if (player.dirY > 0)
            //        player.posY -= 3;

            //    if (player.dirX < 0)
            //        player.posX += 3;
            //    else
            //        label1.Text = "soka";

            //    if (player.dirX > 0)
            //        player.posX -= 3;
            //    collide = true;
            //}
            //else
            //{
            //    collide = false;
            //    //player.dirX = 0;
            //   // player.dirY = 0;
            //}


            if (player.isMoving)
            {
                
                    player.Move();
                if (Wpressed)
                    if (player.posY > ((this.Height / 2) - 200) && player.posY < MapController.cellSize * 60 - ((this.Height) / 2))
                    {
                        if(!collide && !hitPlayer)
                        delta.Y += player.playerSpeed;


                    }
                if (Spressed)
                    if (player.posY > ((this.Height / 2) - 200) && player.posY < MapController.cellSize * 60 - (this.Height + 50) / 2)
                    {
                        if (!collide && !hitPlayer)
                            delta.Y -= player.playerSpeed;

                    }
                if (Apressed)
                    if (player.posX > ((this.Width / 2)) && player.posX < MapController.cellSize * 60 - this.Width / 2)
                    {
                        if (!collide && !hitPlayer)
                            delta.X += player.playerSpeed;

                    }
                if (Dpressed)
                    if (player.posX > ((this.Width / 2)) && player.posX < MapController.cellSize * 60 - this.Width / 2)
                    {
                        if (!collide && !hitPlayer)
                            delta.X -= player.playerSpeed;

                    }

            }

           
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

            
           


            //Chest.drawIdleChest(g);
            double distance = GetDistance(player.posX, player.posY, Chest.posX, Chest.posY);
            //if(Chest.isOpened == false)
            //{
            //    Chest.PlayAnimation(g);
            //}

           //s if (distance < 20 && Xpressed && !Chest.isOpened)
                Chest.PlayAnimation(g);
            

            player.PlayAnimation(g);
            hearts.drawHearts(g, player);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
