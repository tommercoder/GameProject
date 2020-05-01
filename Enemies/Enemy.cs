using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Project.Entities;
using Project.Models;

namespace Project.Enemies
{
    public class Enemy
    {
        public  int posX;
        public int posY;
        
        public int size;

        public float oldPosX ;
        public float oldPosY ;
        
        public int EnemySpeedX = 1;
        public int EnemySpeedY = 1;
        
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
        
        public Enemy() { }
        public Enemy(int posx, int posy, int EnemyIdleFrames, int EnemyRunFrames, Image mobSheet)
        {
            oldPosX = posx;
            oldPosY = posy;
            posX = posx;
            posY = posy;
            this.EnemyIdleFrames = EnemyIdleFrames;
            this.EnemyRunFrames = EnemyRunFrames;
            this.mobSheet = mobSheet;
            size = 16;
            currentFrame = 0;
            currentLimit = EnemyIdleFrames;
            flip = 1;

        }
        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public void ownMove(Entity player)
        {
            int posXvar = posX;
            int posYvar = posY;
            float playerposXvar = player.posX;
            float playerposYvar = player.posY;


            if (posX > oldPosX + 2 || posY > oldPosY + 2 || posX < oldPosX  || posY < oldPosY )
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
                else if(player.flip == -1 && player.posX < posX)
                    flip = -1;
            }

            if (distance >= 100)
                flip = 1;
            if (distance <= 100 )
            {
                if (player.posX > posX)
                {
                    posX += EnemySpeedX;
                }
                else
                {
                    posX -= EnemySpeedX;
                }

                if (player.posY > posY)
                {

                    posY += EnemySpeedY;
                }
                else
                    posY -= EnemySpeedY;
            }
            else if( distance <= 100 )
            {
                if (player.posX > posX)
                {
                    posX += EnemySpeedX;
                }
                else
                {
                    posX -= EnemySpeedX;

                }
                if (player.posY > posY)
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
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else
                currentFrame = 0;

            g.DrawImage(mobSheet, new Rectangle(new Point(posX - flip * size / 2, posY), new Size(flip * size, size)), 16 * currentFrame, 16 * currentAnimation, size, size, GraphicsUnit.Pixel);
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

        public static bool Collide(Enemy2 enemy2)
        {
            for (int i = 0; i < Level1.enemies.Count; i++)
            {
                int deltaX = (enemy2.posX + enemy2.size / 2) - (Level1.enemies[i].posX + Level1.enemies[i].size / 2);
                int deltaY = (enemy2.posY + enemy2.size / 2) - (Level1.enemies[i].posY + Level1.enemies[i].size / 2);

                if (Math.Abs(deltaX) <= enemy2.size / 2 + Level1.enemies[i].size / 2)
                {
                    if (Math.Abs(deltaY) <= enemy2.size / 2 + Level1.enemies[i].size / 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class Enemy2 
    {
        public int posX;
        public int posY;

        public int size;

        public float oldPosX;
        public float oldPosY;

        public int EnemySpeedX = 1;
        public int EnemySpeedY = 1;

        public double radius;
        public double radius2;

        public bool isMoving;
        public Image mobSheet;

        public int flip;
        public int currentFrame;
        public int currentLimit;
        public int Enemy2IdleFrames;
        public int Enemy2RunFrames;
        public int currentAnimation;

        public Enemy2() { }
        public Enemy2(int posx, int posy, int Enemy2IdleFrames, int Enemy2RunFrames, Image mobSheet)
        {
            oldPosX = posx;
            oldPosY = posy;
            posX = posx;
            posY = posy;
            this.Enemy2IdleFrames = Enemy2IdleFrames;
            this.Enemy2RunFrames = Enemy2RunFrames;
            this.mobSheet = mobSheet;
            size = 35;
            currentFrame = 0;
            currentLimit = Enemy2IdleFrames;
            flip = 1;

            currentAnimation = 0;

        }
        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public void ownMove(Entity player)
        {
            int posXvar = posX;
            int posYvar = posY;
            float playerposXvar = player.posX;
            float playerposYvar = player.posY;


            if (posX > oldPosX + 2 || posY > oldPosY + 2 || posX < oldPosX || posY < oldPosY)
            {
                isMoving = true;
                
            }
            else
                isMoving = false;

            //if(isMoving)
            //    setEnemyAnimationConfiguration(1);


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

            if (distance >= 100)
                flip = 1;

            if (distance <= 100)
            {
                
                if (player.posX > posX)
                {
                    posX += EnemySpeedX;
                }
                else
                {
                    posX -= EnemySpeedX;
                }

                if (player.posY > posY)
                {

                    posY += EnemySpeedY;
                }
                else
                    posY -= EnemySpeedY;
            }
            else if (distance <= 100)
            {
                
                if (player.posX > posX)
                {
                    posX += EnemySpeedX;
                }
                else
                {
                    posX -= EnemySpeedX;

                }
                if (player.posY > posY)
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
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else
                currentFrame = 0;
            
            g.DrawImage(mobSheet, new Rectangle(new Point(posX - flip * 34 / 2, posY), new Size(flip * 34, 34)), 32 * currentFrame, 34 * currentAnimation, 34, 34, GraphicsUnit.Pixel);
            
        }

        public void setEnemyAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                        currentLimit = Enemy2IdleFrames;
                    break;
                case 1:
                        currentLimit = Enemy2RunFrames;
                    break;
           }

        }
    }
}
