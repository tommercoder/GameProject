using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project.Controller;
using Project.Entities;
using Project.Models;

namespace Project.Enemies
{
    public class Enemy
    {
     
        //Image[] image = 
        public float posX;
        public float posY;

        public int sizeid1;
        public int sizeid2;

        public float oldPosX;
        public float oldPosY;

        public float EnemySpeedX = 1;
        public float EnemySpeedY = 1;

        public double radius;
        public double radius2;

        public bool isMoving;
       
        public Image mobSheet;

        public int flip;
        public int currentFrame;
        public int currentLimit;
        public int EnemyIdleFrames;
        public int EnemyRunFrames;
        public int currentAnimation;
        public int id;
        public int HP;
        public Enemy() { }
        public Enemy(int posx, int posy, int id, int EnemyIdleFrames, int EnemyRunFrames, Image mobSheet)
        {
            
            this.id = id;
            oldPosX = posx;
            oldPosY = posy;
            posX = posx;
            posY = posy;
            this.EnemyIdleFrames = EnemyIdleFrames;
            this.EnemyRunFrames = EnemyRunFrames;
            this.mobSheet = mobSheet;
            sizeid1 = 16;
            sizeid2 = 34;
            currentFrame = 0;
            currentLimit = EnemyIdleFrames;
            flip = 1;
            if (id == 1)
                HP = 20;
            if (id == 2)
                HP = 110;
            if (id == 3)//blue
                HP = 30;
            if (id == 4)//red demon
                HP = 40;
            if (id == 5)//white
                HP = 20;
            if (id == 10)
                HP = 1500;

        }
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
        public void hitEntity(Entity player)
        {
           double distance = GetDistance(player.posX, player.posY, posX, posY);
            if (distance <= 15 )
            //if(player.posX - 20 == posX || player.posY - 20 == posY || player.posX +20 == posX || player.posY+20 == posY)
            {

                Level1.hitPlayer = true;
                if (player.HP > 0)
                {
                   player.howmuchDamaged++;//for frames hearts
                   //if(Math.Abs(player.howmuchDamaged%5) < double.Epsilon)
                       player.HP -= 20;
                    player.setAnimationConfiguration(1);
                    if (player.howmuchDamaged % 5 == 0)
                        player.Ih++;

                    
                    if (player.HP == 0)
                    {

                        player.dead = true;
                        player.howmuchDamaged = 0;
                        player.Ih = 0;

                    }

                }
               
            }
            else
            {
                Level1.hitPlayer = false;
              
            }
            if(player.dead)
            {
                player.posX = player.OldposX;
                player.posY = player.OldposY;
                Level1.delta.X = 0;
                Level1.delta.Y = 0;
                player.HP = 1000;
                player.dead = false;
                player.Ih = 0;
            }
            
        }
        public void IfEnemiesCollide(List<Enemy> enemies)
        {
            for (int i = 0; i < enemies.Count - 1; i++)
            {
                double distance = GetDistance(enemies[i].posX, enemies[i].posY, enemies[i + 1].posX, enemies[i + 1].posY);
                if (distance <= 20)
                {
                    if (enemies[i].posX < enemies[i + 1].posX)
                    {
                        enemies[i + 1].posX += 2;
                    }
                    else if (enemies[i].posX > enemies[i + 1].posX)
                    {
                        enemies[i + 1].posX -= 2;
                    }

                    if (enemies[i].posY < enemies[i + 1].posY)
                    {
                        enemies[i + 1].posY -= 2;

                    }
                    else if (enemies[i].posY > enemies[i + 1].posY)
                    {
                        enemies[i + 1].posY += 2;
                    }

                }
                else
                {


                }
            }

        }
        public void ownMove(Entity player)
        {
            float posXvar = posX;
            float posYvar = posY;
            float playerposXvar = player.posX;
            float playerposYvar = player.posY;


            if (posX > oldPosX + 2 || posY > oldPosY + 2 || posX < oldPosX || posY < oldPosY)
            {
                isMoving = true;
            }
            else
                isMoving = false;

            if (posX < 0)
                posXvar = (-1) * posX;

            if (posY < 0)
                posYvar = (-1) * posY;

            if (player.posX < 0)
                playerposXvar = (-1) * player.posX;

            if (player.posY < 0)
                playerposYvar = player.posY * (-1);

            if (playerposXvar - posXvar < 0)
                radius = (-1) * (playerposXvar - posXvar);
            else
                radius = (playerposXvar - posXvar);

            if (playerposYvar - posYvar < 0)
                radius2 = (-1) * (playerposYvar - posYvar);
            else
                radius2 = (playerposYvar - posYvar);

            double distance = GetDistance((double)player.posX, (double)player.posY, (double)posX, (double)posY);

            if ((radius <= 20 || radius2 <= 20))
            {
                if (player.flip == 1 && player.posX > posX)
                    flip = 1;
                else if (player.flip == -1 && player.posX < posX)
                    flip = -1;
            }

            if (distance >= 30)
            {
                flip = 1;
            }


            //if (distance >= 30)
            //{
            //    if (id == 1)
            //    {
            //        posX += 2;
            //        if(posX > oldPosX)
            //        posX -= 2;
                    


            //    }
            //}
            if (distance <= 30)
            {
               
                if (player.posX  > posX)
                {
                    posX  += EnemySpeedX;
                }
                else
                {
                    posX  -= EnemySpeedX;
                }

                if (player.posY  > posY)
                {

                    posY += EnemySpeedY;
                }
                else
                    posY -= EnemySpeedY;

            }
            else
            {
                
                if (posX < oldPosX)
                {
                    posX += EnemySpeedX;
                }
                else
                {
                    posX -= EnemySpeedX;
                }

                if (posY < oldPosY)
                {
                    posY += EnemySpeedY;
                }
                else
                {

                    posY -= EnemySpeedY;
                }

            }
            
        }

        public void playEnemyAnimation(Graphics g)
        {
            if (id == 1) 
            {
                
                if (currentFrame < currentLimit - 1 )
                    currentFrame++;
                else
                    currentFrame = 0;
            }
            if (id == 2) 
            { 
                if (currentFrame < currentLimit -1)
                    currentFrame++;
                else
                    currentFrame = 0; 
            }
            if (id == 1)
            {
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid1 / 2 + Level1.delta.X+14, (int)posY + Level1.delta.Y + 5), new Size(flip * sizeid1, sizeid1)), 16 * currentFrame, 16 * currentAnimation, sizeid1, sizeid1, GraphicsUnit.Pixel);
                
            }
            if (id == 2)
            {
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid2 / 2 + Level1.delta.X+14, (int)posY + Level1.delta.Y + 5), new Size(flip * sizeid2, sizeid2)), 32 * currentFrame, 34 * currentAnimation, sizeid2, sizeid2, GraphicsUnit.Pixel);
            }
        }

        public void setEnemyAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:

                    currentLimit = EnemyIdleFrames;

                    break;
            }

        }

    }
}