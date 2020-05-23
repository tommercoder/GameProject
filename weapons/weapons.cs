using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Enemies;
using Project.Entities;

namespace Project.weapons
{
    public class Weapons
    {
        public int id;
        public float posX;
        public float posY;
        public int posXforHit;
        public int posYforHit;
        public Image weaponSheet;
        public bool onFloor;
        public int damage;


        public Weapons(float posX, float posY, int Id, Image weaponSh)
        {
            this.posX = posX;
            this.posY = posY;

            this.id = Id;
            this.onFloor = true;
            this.weaponSheet = weaponSh;
            if (id == 1)
                damage = 20;
            if (id == 2)
                damage = 150;
            if (id == 3)//white sword
                damage = 40;
            if (id == 4)//yellow
                damage = 60;
            if (id == 5)//axe
                damage = 20;
            if (id == 6)//big HAMMER FOR boss
                damage = 80;
            
        }
        public void hit(Graphics g, Entity player)
        {
            foreach (Weapons weapon in Level1.weapons)
            {

                if (player.hitPressed && weapon.id == 1)
                {
                    if (player.flip == 1)
                    {
                        if (id != 6 && id != 5)
                        {
                            g.TranslateTransform(player.posX - 6 + Level1.delta.X + 14/*/ 2.0f*/, player.posY + 44 / 2.0f + Level1.delta.Y);
                            g.RotateTransform(90);
                            g.TranslateTransform(-(player.posX - 6 + Level1.delta.X + 14), -(player.posY + 44 / 2.0F + Level1.delta.Y));
                        }
                        if(id == 6)
                        {
                            g.TranslateTransform(player.posX + 3 + Level1.delta.X + 14/*/ 2.0f*/, player.posY + 48 / 2.0f + Level1.delta.Y);
                            g.RotateTransform(90);
                            g.TranslateTransform(-(player.posX - 6 + Level1.delta.X + 14), -(player.posY + 44 / 2.0F + Level1.delta.Y));
                        }
                        if(id == 5)
                        {
                            g.TranslateTransform(player.posX + 1 + Level1.delta.X + 14/*/ 2.0f*/, player.posY + 52 / 2.0f + Level1.delta.Y);
                            g.RotateTransform(90);
                            g.TranslateTransform(-(player.posX - 6 + Level1.delta.X + 14), -(player.posY + 44 / 2.0F + Level1.delta.Y));
                        }
                    }
                    else if (player.flip == -1)
                    {
                        if (id != 6 && id != 5)
                        {
                            g.TranslateTransform(player.posX + 6 + Level1.delta.X + 14/*/ 2.0f*/, player.posY + 66 / 2.0f + Level1.delta.Y);
                            g.RotateTransform(-90);
                            g.TranslateTransform(-(player.posX - 6 + Level1.delta.X + 14), -(player.posY + 50 / 2.0F + Level1.delta.Y));
                        }
                        if(id==6)
                        {
                            g.TranslateTransform(player.posX - 3 + Level1.delta.X + 14/*/ 2.0f*/, player.posY + 70 / 2.0f + Level1.delta.Y);
                            g.RotateTransform(-90);
                            g.TranslateTransform(-(player.posX - 6 + Level1.delta.X + 14), -(player.posY + 44 / 2.0F + Level1.delta.Y));
                        }
                        if(id == 5)
                        {
                            g.TranslateTransform(player.posX - 2 + Level1.delta.X + 14/*/ 2.0f*/, player.posY + 72 / 2.0f + Level1.delta.Y);
                            g.RotateTransform(-90);
                            g.TranslateTransform(-(player.posX - 6 + Level1.delta.X + 14), -(player.posY + 44 / 2.0F + Level1.delta.Y));
                        }
                    }
                }
            }
        }
        public void weaponMove(List<Weapons> weapons, Entity player)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (!weapons[i].onFloor)
                {
                    if (id == 1)
                    {
                        posXforHit = (int)player.posX;//((int)posX - player.flip * 18 / 2 + 14) + ((int)player.posX - (int)posX + Level1.delta.X);
                        posYforHit = (int)player.posY;//((int)posY - 1 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y);
                    }
                    if (id == 2)
                    {
                        posXforHit = ((int)posX - player.flip * 22 / 2 + 14 + (int)player.posX - (int)posX + Level1.delta.X);
                        posYforHit = ((int)posY - 3 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y);
                    }
                    if (id == 3)
                    {
                        posXforHit = ((int)posX - player.flip * 22 / 2 + 14 + (int)player.posX - (int)posX + Level1.delta.X);
                        posYforHit = ((int)posY - 3 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y);
                    }
                    if(id == 5)
                    {
                        posXforHit = ((int)posX - player.flip * 22 / 2 + 14 + (int)player.posX - (int)posX + Level1.delta.X);
                        posYforHit = ((int)posY - 3 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y);
                    }
                }
            }
        }
        public void drawHandWeapon(Graphics g, Entity player)
        {
            if (id == 1 && !onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 18 / 2 + 14) + (int)player.posX - (int)posX + Level1.delta.X, (int)posY - 1 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y), new Size(player.flip * 6, 30)), 0, 0, 6, 30, GraphicsUnit.Pixel);//catana
            }

            if (id == 2 && !onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 22 / 2 + 14) + (int)player.posX - (int)posX + Level1.delta.X, (int)posY - 3 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y), new Size(player.flip * 12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);//big weapon
            }

            if (id == 3 && !onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 22 / 2 + 14) + (int)player.posX - (int)posX + Level1.delta.X, (int)posY - 3 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y), new Size(player.flip * 12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);//big weapon
            }

            if (id == 5 && !onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 18 / 2 + 14) + (int)player.posX - (int)posX + Level1.delta.X  , (int)posY + 8 -  player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y), new Size(player.flip * 9, 21)), 0, 0, 9, 21, GraphicsUnit.Pixel);//big weapon
            }
            if (id == 4 && !onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 22 / 2 + 14) + (int)player.posX - (int)posX + Level1.delta.X, (int)posY - 2 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y), new Size(player.flip * 10, 30)), 0, 0, 10, 30, GraphicsUnit.Pixel);//big weapon
            }
            if (id == 6 && !onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 18 / 2 + 14) + (int)player.posX - (int)posX + Level1.delta.X, (int)posY - 4  /*-player.currentFrame*/ + (int)player.posY - (int)posY + Level1.delta.Y), new Size(player.flip * 11, 37)), 0, 0, 11, 37, GraphicsUnit.Pixel);//big weapon
            }


        }
        public void drawWeapon(Graphics g, Entity player)
        {
            if (id == 1 && onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX) + Level1.delta.X, (int)posY - player.currentFrame + Level1.delta.Y), new Size(6, 30)), 0, 0, 6, 30, GraphicsUnit.Pixel);//catana
            }
            if (id == 2 && onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + Level1.delta.X, (int)posY - player.currentFrame + Level1.delta.Y), new Size(12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);//big weapon
            }

            if (id == 3 && onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + Level1.delta.X, (int)posY - player.currentFrame + Level1.delta.Y), new Size(12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);//big weapon
            }
            if (id == 4 && onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + Level1.delta.X, (int)posY - player.currentFrame + Level1.delta.Y), new Size(10,30)), 0, 0, 10, 30, GraphicsUnit.Pixel);//big weapon
            }

            if (id == 5 && onFloor )
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + Level1.delta.X, (int)posY - player.currentFrame + Level1.delta.Y), new Size(9, 21)), 0, 0, 9, 21, GraphicsUnit.Pixel);//big weapon
            }
            if (id == 6 && onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + Level1.delta.X, (int)posY - player.currentFrame + Level1.delta.Y), new Size(10,37)), 0, 0, 10, 37, GraphicsUnit.Pixel);//big weapon
            }
        }

        public void hitEnemy(List<Enemy> enemies, List<Weapons> weapons, Entity player)
        {
            for (int wp = 0; wp < weapons.Count; wp++)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    double distance1 = Level1.GetDistance(weapons[wp].posXforHit, weapons[wp].posYforHit, enemies[i].posX, enemies[i].posY);
                  
                    
                    //if (weapons[wp].id == 1 && !weapons[wp].onFloor)
                   // {
                        ///if(!weapons[wp].onFloor)
                        if (distance1 < 15 && player.hitPressed)
                        {
                          
                            if (player.posX >= enemies[i].posX)
                            {
                                enemies[i].posX -= 10;

                            if (enemies[i].HP >= 0)
                            {
                                if (player.id == 1)
                                    enemies[i].HP -= 20;
                                if (player.id == 2)
                                    enemies[i].HP -= 150;
                                if (player.id == 3)
                                    enemies[i].HP -= 40;
                                if (player.id == 4)
                                    enemies[i].HP -= 50;
                                if (player.id == 5)
                                    enemies[i].HP -= 20;
                                if (player.id == 6)
                                    enemies[i].HP -= 70;

                            }
                            else if (enemies[i].HP <= 0)
                            {
                               
                               if (enemies[i].id != 10)
                                {
                                    player.setAnimationConfiguration(0);
                                   if(Level1.newBossIndex!=0)
                                    Level1.newBossIndex--;
                                    enemies.RemoveAt(i);
                                    
                                   

                                }
                                
                            }

                        }
                            else if (player.posX <= enemies[i].posX)
                            {
                                enemies[i].posX += 10;
                            if (enemies[i].HP >= 0)
                            {

                                if (player.id == 1)
                                    enemies[i].HP -= 20;
                                if (player.id == 2)
                                    enemies[i].HP -= 150;
                                if (player.id == 3)
                                    enemies[i].HP -= 40;
                                if (player.id == 4)
                                    enemies[i].HP -= 50;
                                if (player.id == 5)
                                    enemies[i].HP -= 20;
                                if (player.id == 6)
                                    enemies[i].HP -= 70;
                            }
                            else if (enemies[i].HP <= 0)
                            {

                                if (enemies[i].id != 10)
                                {
                                    player.setAnimationConfiguration(0);
                                    if (Level1.newBossIndex != 0)
                                        Level1.newBossIndex--;
                                    enemies.RemoveAt(i);
                                   
                                    

                                }

                            }
                        }
                            else if (player.posY >= enemies[i].posY)
                            {
                                enemies[i].posY -= 10;
                            if (enemies[i].HP >= 0)
                            {

                                if (player.id == 1)
                                    enemies[i].HP -= 20;
                                if (player.id == 2)
                                    enemies[i].HP -= 150;
                                if (player.id == 3)
                                    enemies[i].HP -= 40;
                                if (player.id == 4)
                                    enemies[i].HP -= 50;
                                if (player.id == 5)
                                    enemies[i].HP -= 20;
                                if (player.id == 6)
                                    enemies[i].HP -= 70;
                            }
                            else if (enemies[i].HP <= 0)
                            {

                                if (enemies[i].id != 10)
                                {
                                    player.setAnimationConfiguration(0);
                                    if (Level1.newBossIndex != 0)
                                        Level1.newBossIndex--;
                                    enemies.RemoveAt(i);
                                   
                                   

                                }

                            }
                        }
                            else if (player.posY <= enemies[i].posY)
                            {
                                enemies[i].posY += 10;
                            if (enemies[i].HP >= 0)
                            {

                                if (player.id == 1)
                                    enemies[i].HP -= 20;
                                if (player.id == 2)
                                    enemies[i].HP -= 150;
                                if (player.id == 3)
                                    enemies[i].HP -= 40;
                                if (player.id == 4)
                                    enemies[i].HP -= 50;
                                if (player.id == 5)
                                    enemies[i].HP -= 20;
                                if (player.id == 6)
                                    enemies[i].HP -= 70;
                            }
                            else if(enemies[i].HP <= 0)
                            {

                                if (enemies[i].id != 10)
                                {
                                    player.setAnimationConfiguration(0);
                                    if (Level1.newBossIndex != 0)
                                        Level1.newBossIndex--;
                                    enemies.RemoveAt(i);
                                    
                                }
                                
                            }

                        }
                            
                                
                        }
                        //if(enemies.Count==0)
                           // enemies.Clear();
                    }

                }
            }

            //g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip *  22 / 2)  + (int)player.posX , (int)posY - 5 - player.currentFrame   + (int)player.posY ), new Size(player.flip * 12, 30)), 0, 0, 12, 30 , GraphicsUnit.Pixel);//big weapon
        }
    }



