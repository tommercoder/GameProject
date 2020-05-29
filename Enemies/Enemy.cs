using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Project.Controller;
using Project.Entities;
using Project.Models;

namespace Project.Enemies
{
    public class Enemy
    {

        
        public float posX;
        public float posY;

        public int sizeid1;
        public int sizeid2;
        public int sizeid3;
        public int sizeid4;
        public int sizeid5;
        public int sizeid6;
        public int sizeid10W;
        public int sizeid10H;
       

        public float oldPosX;
        public float oldPosY;

        public float EnemySpeedX = 1;
        public float EnemySpeedY = 1;

        public double radius;
        public double radius2;

        public bool isMoving = false;
        public bool enemyDead = false;

        public Image mobSheet;

        public int flip;
        public int currentFrame;
        public int currentLimit;
        public int EnemyIdleFrames;
        public int EnemyRunFrames;
        public int BossAttack;
        public int BossDeath;
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
            sizeid3 = 24;
            sizeid4 = 16;
            sizeid5 = 16;
            sizeid6 = 16;

            isMoving = false;
            enemyDead = false;
            currentFrame = 0;
            currentLimit = EnemyIdleFrames;
            flip = 1;
            if (id == 1)
                HP = 20;
            if (id == 2)
                HP = 110;
            if (id == 3)//blue
                HP = 40;
            if (id == 4)//red demon
                HP = 30;
            if (id == 5)//white
                HP = 20;
            if (id == 6)
                HP = 60;


        }
        public Enemy(int posx, int posy, int id, int BossIdle, int BossRun, int BossAttack, int BossDeath, Image Sheet)
        {

            this.id = id;
            oldPosX = posx;
            oldPosY = posy;
            posX = posx;
            posY = posy;
            this.EnemyIdleFrames = BossIdle;
            this.EnemyRunFrames = BossRun;
            this.BossAttack = BossAttack;

            this.BossDeath = BossDeath;
            enemyDead = false;
            this.mobSheet = Sheet;
            sizeid10W = 97;
            sizeid10H = 97;
            currentFrame = 0;
            currentLimit = BossIdle;
            flip = 1;
            if (id == 10)
                HP = 1500;
            isMoving = false;

        }
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
        public void hitEntity(Entity player)
        {
            if (!game.enemies[game.newBossIndex].enemyDead)
            {
                double distance = GetDistance(player.posX, player.posY, posX, posY);
                
                if (id == 10)
                {
                    if (distance <= 50)
                    {
                            
                           
                        if (player.HP > 0)
                        {
                            game.hitPlayer = true;
                            player.howmuchDamaged++;//for frames hearts
                                                    
                            player.HP -= 20;
                            player.setAnimationConfiguration(1);
                            if (player.howmuchDamaged % 5 == 0)
                                player.Ih++;


                            

                        }
                        if (player.HP == 0)
                        {

                            player.howmuchDamaged = 0;
                            player.Ih = 0;
                            player.dead = true;
                           

                        }
                       
                    }
                    else
                    {
                        game.hitPlayer = false;
                        

                    }
                    if (player.dead)
                    {

                        player.posX = player.OldposX;
                        player.posY = player.OldposY;
                        if (game.newCheckPoint == 0)
                        {
                            game.delta.X = 0;
                            game.delta.Y = 0;

                           
                        }
                        else if (game.newCheckPoint == 1)
                        {
                            game.delta.X = 0;
                            game.delta.Y = -3;
                        }
                        else if (game.newCheckPoint == 2)
                        {
                            game.delta.X = -165;
                            game.delta.Y = -459;

                        }
                        else if (game.newCheckPoint == 3)
                        {
                            game.delta.X = -3;
                            game.delta.Y = -1074;

                        }
                        else if (game.newCheckPoint == 4)
                        {
                            game.delta.X = -636;
                            game.delta.Y = -960;
                        }
                        game.hearts.currentAnimation = 0;
                        player.setAnimationConfiguration(0);
                        player.HP = 1000;
                        player.Ih = 0;
                        player.dead = false;
                       
                    }
                }
                else if (id != 10)
                    if (distance <= 15)
                    {

                        game.hitPlayer = true;
                        if (player.HP > 0)
                        {
                           
                            player.howmuchDamaged++;//for frames hearts
                                                  
                            player.HP -= 20;
                            player.setAnimationConfiguration(1);
                            if (player.howmuchDamaged % 5 == 0)
                                player.Ih++;


                            

                        }
                        if (player.HP == 0)
                        {
                            player.howmuchDamaged = 0;
                            player.Ih = 0;
                            player.dead = true;
                            //Level1.hitPlayer = false;

                        }
                        
                    }
                    else
                    {
                        game.hitPlayer = false;
                      //  player.setAnimationConfiguration(0);
                    }
                if (player.dead)
                {
                    player.posX = player.OldposX;
                    player.posY = player.OldposY;
                    if (game.newCheckPoint == 0)
                    {
                        game.delta.X = 0;
                        game.delta.Y = 0;

                        //delta = new Point()
                        //Level1.delta.X = -(int)player.posX / 2 - 32;
                        //Level1.delta.Y = -(int)player.posY / 2 - 32;
                    }
                    else if (game.newCheckPoint == 1)
                    {
                        game.delta.X = 0;
                        game.delta.Y = -3;
                    }
                    else if (game.newCheckPoint == 2)
                    {
                        game.delta.X = -165;
                        game.delta.Y = -459;

                    }
                    else if (game.newCheckPoint == 3)
                    {
                        game.delta.X = -3;
                        game.delta.Y = -1074;

                    }
                    else if (game.newCheckPoint == 4)
                    {
                        game.delta.X = -636;
                        game.delta.Y = -960;
                    }
                    game.hearts.currentAnimation = 0;
                    player.setAnimationConfiguration(0);      
                    player.HP = 1000;
                    player.Ih = 0;
                    player.dead = false;
                   
                }
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

        public void FlipEnemy(Entity player,List<Enemy>enemies)
        {
            //if (!Level1.enemies[Level1.newBossIndex].enemyDead)
            //{
                for (int i = 0; i < enemies.Count; i++)
                {
                    double distance = GetDistance((double)player.posX, (double)player.posY, (double)enemies[i].posX, (double)enemies[i].posY);
                    if (enemies[i].isMoving)
                    {
                    if (enemies[i].id != 10)
                    {
                        if (distance <= 30)
                        {
                            
                            if (player.posX < enemies[i].posX)
                            {
                                enemies[i].flip = -1;

                            }
                            if (player.posX > enemies[i].posX)
                            {
                                enemies[i].flip = 1;
                            }
                            if (distance <= 15)
                                game.hitPlayer = true;
                        }
                        else
                        {
                            if (player.posX < enemies[i].posX)
                            {
                                enemies[i].flip = 1;
                            }
                            if (player.posX > enemies[i].posX)
                            {
                                enemies[i].flip = -1;
                            }
                        }
                    }
                    else if(enemies[i].id == 10)
                    {
                        if (distance <= 100)
                        {
                            player.velocity = 4;
                            if (player.posX < enemies[i].posX)
                            {
                                enemies[i].flip = -1;

                            }
                            if (player.posX > enemies[i].posX)
                            {
                                enemies[i].flip = 1;
                            }
                            if (distance <= 50)
                                game.hitPlayer = true;
                        }
                        else
                        {
                            player.velocity = 3;
                            if (player.posX < enemies[i].posX)
                            {
                                enemies[i].flip = 1;
                            }
                            if (player.posX > enemies[i].posX)
                            {
                                enemies[i].flip = -1;
                            }
                        }
                    }
                    }
                //}
            }
        }

        public void ownMove(Entity player)
        {
            if (!game.enemies[game.newBossIndex].enemyDead)
            {
                float posXvar = posX;
                float posYvar = posY;
                float playerposXvar = player.posX;
                float playerposYvar = player.posY;




                //if (posX < 0)
                //    posXvar = (-1) * posX;

                //if (posY < 0)
                //    posYvar = (-1) * posY;

                //if (player.posX < 0)
                //    playerposXvar = (-1) * player.posX;

                //if (player.posY < 0)
                //    playerposYvar = player.posY * (-1);

                //if (playerposXvar - posXvar < 0)
                //    radius = (-1) * (playerposXvar - posXvar);
                //else
                //    radius = (playerposXvar - posXvar);

                //if (playerposYvar - posYvar < 0)
                //    radius2 = (-1) * (playerposYvar - posYvar);
                //else
                //    radius2 = (playerposYvar - posYvar);

                double distance = GetDistance((double)player.posX, (double)player.posY, (double)posX, (double)posY);

                //if (id != 10)
                //    if ((radius <= 30 || radius2 <= 30))
                //    {
                //        if (player.flip == 1 && player.posX > posX)
                //            flip = 1;
                //        else if (player.flip == -1 && player.posX < posX)
                //            flip = -1;
                //    }
                //if (id == 10)
                //    if ((radius <= 100 || radius2 <= 100))
                //    {
                //        if (player.flip == 1 && player.posX > posX)
                //            flip = 1;
                //        else if (player.flip == -1 && player.posX < posX)
                //            flip = -1;
                //        else if (player.flip == 1 && player.posX < posX)
                //            flip = -1;
                //        else if (player.flip == -1 && player.posX > posX)
                //            flip = 1;

                //    }
                //if (id != 10)
                //    if (distance >= 30)
                //    {
                //        flip = 1;

                //    }
                //if (id == 10)
                //    if (distance >= 100)
                //    {
                //        if (player.posX < posX)
                //            flip = 1;
                //        if (player.posX > posX)
                //            flip = -1;
                //    }

                


                if (id != 10)
                {
                    if (distance <= 30)
                    {
                        if (isMoving)
                        {
                            setEnemyAnimationConfiguration(1);
                            


                        }
                        else
                        {
                            setEnemyAnimationConfiguration(0);
                           
                        }
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
                        if (isMoving)
                        {

                            setEnemyAnimationConfiguration(1);

                        }
                        else
                            setEnemyAnimationConfiguration(0);
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
                else if (id == 10)
                {
                    if (distance <= 100)
                    {
                        if (isMoving)
                        {
                            setEnemyAnimationConfiguration(1);
                            if (game.hitPlayer)
                                setEnemyAnimationConfiguration(6);


                        }
                        else
                        {
                            setEnemyAnimationConfiguration(0);
                            if (game.hitPlayer)
                                setEnemyAnimationConfiguration(6);
                        }
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

                        if (isMoving)
                        {

                            setEnemyAnimationConfiguration(1);

                        }
                        else
                            setEnemyAnimationConfiguration(0);
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
            }
            
            if (game.enemies[game.newBossIndex].enemyDead)
            {
                game.enemies[game.newBossIndex].setEnemyAnimationConfiguration(9);
                //Wait(10);
                game.enemies[game.newBossIndex].isMoving = false;
                
                game.hitPlayer = false;

                
            }
        
    }

        
       
        public void playEnemyAnimation(Graphics g)
        {

            if (id != 10 )
            {
                if (currentFrame < currentLimit - 1)
                    currentFrame++;
                else
                    currentFrame = 0;
            }
            
            if (id == 10)
            {

                if (currentAnimation == 9)
                {
                    if (currentFrame < currentLimit - 1)
                        currentFrame++;
                    else
                        currentFrame = 5;
                }
                else
                {
                    if (currentFrame < currentLimit - 2)
                        currentFrame++;
                    else
                        currentFrame = 0;
                }

            }
            if (id == 1)
            {
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid1 / 2 + game.delta.X+14, (int)posY + game.delta.Y + 5), new Size(flip * sizeid1, sizeid1)), 16 * currentFrame,  currentAnimation, sizeid1, sizeid1, GraphicsUnit.Pixel);
                
            }
            if (id == 2)
            {
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid2 / 2 + game.delta.X+14, (int)posY + game.delta.Y + 5), new Size(flip * sizeid2, sizeid2)), 32 * currentFrame, 40 * currentAnimation, sizeid2, sizeid2, GraphicsUnit.Pixel);
            }
            if(id == 3)
            {
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * 24 / 2 + game.delta.X + 14, (int)posY + game.delta.Y + 5), new Size(flip * 24, 29)),20 * currentFrame,29* currentAnimation, 24, 29, GraphicsUnit.Pixel);
            }
            if(id == 4)
            {
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid4 / 2 + game.delta.X + 14, (int)posY + game.delta.Y + 5), new Size(flip * 21, 33)), 16 * currentFrame,  currentAnimation, 21, 33, GraphicsUnit.Pixel);
            }
            if(id == 5)
            {
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * 21 / 2 + game.delta.X + 14, (int)posY + game.delta.Y + 5), new Size(flip * 23, 30)), 20 * currentFrame, 30 * currentAnimation, 23, 30, GraphicsUnit.Pixel);
            }
            if(id == 6)
            {
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * 32 / 2 + game.delta.X + 14, (int)posY + game.delta.Y + 5), new Size(flip * 32, 33)), 31 * currentFrame, 50 * currentAnimation, 32, 33, GraphicsUnit.Pixel);
            }
            if(id == 10)
            {

                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid10W / 2 + game.delta.X +14, (int)posY -30 + game.delta.Y + 5), new Size(flip * sizeid10W, sizeid10H)), 95 * currentFrame, 95 * currentAnimation, sizeid10W, sizeid10H, GraphicsUnit.Pixel);
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
                case 1:
                    currentLimit = EnemyRunFrames;
                    break;
                case 6:
                    currentLimit = BossAttack;
                    break;
                case 9:
                    currentLimit = BossDeath;

                    break;
            }

        }

    }
}