using Project.Models;
using Project.Entities;
using Project.weapons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Project.Controller;
using Project.Enemies;
using Project.chests_and_staff;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;

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
        public static bool reDrawHearts = false;
        public static bool escapePressed = false;
        public string nicknameRemember = " ";
        public int newDeltaX;
        public int newDeltaY;

        public Level1()
        {
            this.BackColor = Color.FromArgb(47, 47, 46);
            
            InitializeComponent();

            timer1.Interval = 30;
            timer2.Interval = 30;

           timer3.Interval = 10;//collide
            timer4.Interval = 20;///
         
            
            timer1.Tick += new EventHandler(Update);
            timer2.Tick += new EventHandler(EnemyUpdate);
            timer3.Tick += new EventHandler(checkTimeCollide);
            timer4.Tick += new EventHandler(fighing);


            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
            this.FormClosing += new FormClosingEventHandler(Level1_FormClosing);
            delta = new Point(0, 0);//camera

            init();

           
        }
       
        public void OnKeyUp(object sender,KeyEventArgs e)
        {
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
               
            }
            
        }
       public void WeaponCollide(Entity player, List<Weapons> weapons)
       {
            foreach(Weapons weapon in weapons)
            {
                double distance = GetDistance(weapon.posX + Level1.delta.X - Level1.delta.X, weapon.posY + Level1.delta.Y - Level1.delta.Y, player.posX + Level1.delta.X - Level1.delta.X, player.posY + Level1.delta.Y - Level1.delta.Y);
                if (player.Freehands == true)
                {
                    if (distance < 15)
                    {
                        weapon.onFloor = false;
                        player.id = weapon.id;
                        player.Freehands = false;
                    }
                }
                    
            }
        }
        public void chestOpen(staff staff)
        {
            
            double distance = GetDistance(player.posX,player.posY,staff.posX,staff.posY);

            if (distance < 20)
            {
                staff.isOpened = true;
                
                //label1.Text = "chest opened";


            }
           // else
              //  label1.Text = " >20";
            
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

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\playerred.png"));
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
               // new Enemy(-20,-20,1,Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                
                new Enemy(200, 520, 1,Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(134, 540,1, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
               // new Enemy(45, 500,1, Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
               // new Enemy(32, 380, 1,Hero.EnemyIdleFrames, Hero.EnemyRunFrames, mobSheet),
                new Enemy(350, 350, 2,Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2),
               // new Enemy(300, 350,2, Hero.Enemy2IdleFrames, Hero.Enemy2RunFrames, mobSheet2),

            };

            
            
            //player
            player = new Entity(32, 32, Hero.IdleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, Hero.RedFrames, dwarfSheet);
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
            timer4.Start();
            
            

        }

        public void Death(object sender,EventArgs e)
        {
           
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            
                switch (e.KeyCode)
                {
                 case Keys.W:

                     player.dirY = -3;
                  
                     Wpressed = true;
                     player.isMoving = true;
                     player.setAnimationConfiguration(0);
 
 
                    break;
                 case Keys.S:
               
                   player.dirY = 3;
                  
                   Spressed = true;
                   player.isMoving = true;
                   player.setAnimationConfiguration(0);


                    break;
                case Keys.A:

                    Apressed = true;
                    player.dirX = -3;
                    
                    player.flip = -1;
                    player.isMoving = true;
                    player.setAnimationConfiguration(0);

                    break;
                case Keys.D:


                    Dpressed = true;
                    player.dirX = 3;
                  
                    player.flip = 1;
                    player.isMoving = true;
                    player.setAnimationConfiguration(0);
  

                    break;
                          
                
                //hit
                case Keys.E:
                    sound.play_sound_sword();
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
         
                   
                     break;
                 case Keys.Escape:
                    string message = "Do you want to close the game?\n" +
                        "All progress will not save!";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        FormMenu fm = new FormMenu();
                        EnterNickName en = new EnterNickName();
                        fm.label1.Text = nicknameRemember;
                        fm.ShowDialog();
                        escapePressed = true;
                        this.Close();

                    }
                    else
                    {

                       
                    }

                    //this.Close();
                    //this.Hide();
                    //FormMenu fm = new FormMenu();
                    //EnterNickName en = new EnterNickName();
                    //fm.label1.Text = nicknameRemember;
                    //fm.ShowDialog();
                    //escapePressed = true;
                    break;
             }

        }
        
        public void fighing(object sender,EventArgs e)
        {

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].hitEntity(player);
                // label2.Text = Convert.ToString(player.HP); ////UDAR PO PLAYERU

            }

            foreach (Weapons wp in weapons)
            {
                wp.hitEnemy(enemies, weapons, player);
            }
            foreach (Weapons wp in weapons)
            {
                wp.weaponMove(weapons, player);
            }
        }
        public void checkTimeCollide(object sender, EventArgs e)
        {
            
           //PhysicsController.Collide(player);////COLLIDE
           

            if(player.collidedead) 
            {
                player.posX = player.OldposX;
                player.posY = player.OldposY;
                Level1.delta.X = 0;
                Level1.delta.Y = 0;
                player.HP = 1000;
                player.dead = false;

                hearts.currentAnimation = 0;
                reDrawHearts = true;
            }
               

            


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


            //for (int i = 0; i < enemies.Count; i++)
            //{
            //     //if (!enemies[i].isMoving)
            //    // if (enemies[i].posX < enemies[i].posX + 10)
            //    enemies[i].posX++;


            //}

            //foreach (Enemy enemy in enemies)
            //{

            //    ////LET ENEMIES UNDERSTAND THAT THEY CANT STAY AT THE SAME POSITION!!
            //}


            if (enemies.Count == 0)
                hitPlayer = false;
            
            for (int i = 0;i < enemies.Count;i++)
            {
                enemies[i].ownMove(player);
   
            }
           
            label1.Text = Convert.ToString(player.howmuchDamaged);
            //label2.Text = Convert.ToString("enemy 3 HP:" + enemies[4].HP);
            label3.Text = Convert.ToString(hitPlayer); 
            label4.Text = Convert.ToString("id 2:" + weapons[1].id);
            label5.Text = Convert.ToString("floor:" + weapons[1].onFloor);
            //label6.Text = Convert.ToString("posY:" + enemies[3].posY);
            //label7.Text = Convert.ToString(GetDistance(player.posX, player.posY, enemies[3].posX, enemies[3].posY));

            
        }

        public void SetTextForLabel(string myText)
        {
            this.label1.Text = myText;
        }
        public void Update(object sender, EventArgs e)
        {
           
           
            if (player.isMoving)
            {
                
                    player.Move();
                if (Wpressed)
                    if (player.posY > ((this.Height / 2) - 260) && player.posY < MapController.cellSize * 60 - ((this.Height) / 2))
                    {
                        if (!collide && !hitPlayer)
                        {
                            delta.Y += player.playerSpeed;
                            newDeltaY -= 2;
                        }
                    }
                if (Spressed)
                    if (player.posY > ((this.Height / 2) - 260) && player.posY < MapController.cellSize * 60 - (this.Height + 50) / 2)
                    {
                        if (!collide && !hitPlayer)
                        {
                            delta.Y -= player.playerSpeed;
                            newDeltaY += 2;
                        }
                    }
                if (Apressed)
                    if (player.posX > ((this.Width / 2)) && player.posX < MapController.cellSize * 60 - this.Width / 2)
                    {
                        if (!collide && !hitPlayer)
                        {
                            delta.X += player.playerSpeed;
                            newDeltaX -= 2;
                        }
                    }
                if (Dpressed)
                    if (player.posX > ((this.Width / 2)) && player.posX < MapController.cellSize * 60 - this.Width / 2)
                    {
                        if (!collide && !hitPlayer)
                        {
                            delta.X -= player.playerSpeed;
                            newDeltaX += 2;
                        }
                    }

            }
         

            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            MapController.DrawMap(g);

         
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].playEnemyAnimation(g);
            }

            double distance = GetDistance(player.posX, player.posY, Chest.posX, Chest.posY);
            
            Chest.PlayAnimation(g);


            player.PlayAnimation(g);
           
            hearts.drawHearts(g, player);
            
            //if (reDrawHearts)
            //{
            //    hearts.drawHearts(g, player);
            //}

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

            if(player.id == 1)
            weapon.drawHandWeapon(g, player);
            else if (player.id == 2)
                weapon1.drawHandWeapon(g, player);
            else if (player.id == 3)
                weapon2.drawHandWeapon(g,player);

           
        }
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        private void Level1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (escapePressed || !escapePressed)
            //{
            //    this.Hide();
            //    FormMenu fm = new FormMenu();
            //    fm.ShowDialog();
            //    this.Close();
            //}
            
        }
        private void exit_level1_Click(object sender, EventArgs e)
        {
            
        }

        private void Level1_Load(object sender, EventArgs e)
        {
            //sound.play_sound_battle();
        }

        private void bottom_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Level1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        
        }
            
       

        private void timer4_Tick(object sender, EventArgs e)
        {

        }

       
    }
}
