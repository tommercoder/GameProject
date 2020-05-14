﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Project.Controller;
using Project.weapons;
namespace Project.Entities
{
    public class Entity
    {
        public float posX;
        public float posY;
        public float OldposX;
        public float OldposY;
        public int howmuchDamaged;
        public int HP;
        public float velocityX = 0.5f;//speed
        public float velocityY = 0.5f;//speed
        public float gravity = 0.5f;
        public int offset = 1;

        public int playerSpeed;

        public float dirX;
        public float dirY;
        public bool isMoving;
        public bool falling;
        public bool hitPressed;
        public bool ShiftPressed;
        public bool dead;
        public bool deadFromEnemy;
        

        public int flip;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;

        public  int IdleFrames;
        public  int runFrames;
        public  int attackFrames;
        public  int deathFrames;
        public int jumpFrames;

        public int size;
        public float height;

        public Image spriteSheet;
        public bool Freehands = true;
        public int id; 
   
        public Entity(float posX,float posY,int IdleFrames,int runFrames,int attackFrames,int deathFrames,int jumpFrames,Image spriteSheet)
        {
            HP = 100;
            this.OldposX = posX;
            this.OldposY = posY;
            this.posX = posX;
            this.posY = posY;
            this.IdleFrames = IdleFrames;
            this.runFrames = runFrames;
            this.attackFrames = attackFrames;
            this.deathFrames = deathFrames;
            this.spriteSheet = spriteSheet;
            this.jumpFrames = jumpFrames;
            size = 31;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = IdleFrames;
            flip = 1;
            playerSpeed = 3;
            falling = false;
            dead = false;
            deadFromEnemy = false;
        }

        public void Move()
        {
            if (Level1.Apressed || Level1.Dpressed)
            {
                posX += dirX;
                OldposX += dirX;
            }
            if (Level1.Wpressed || Level1.Spressed)
            {
                OldposY += dirY;
                posY += dirY;
            }
        }

        public void PlayAnimation(Graphics g)
        {

            if(currentFrame < currentLimit - 3)//2 for space cadet
                currentFrame++;
            else
                currentFrame = 0;
            
                g.DrawImage(spriteSheet, new Rectangle(new Point((int)posX - flip * size / 2 + Level1.delta.X + 14, (int)posY + Level1.delta.Y), new Size(flip * size, size)), 26 * currentFrame, 32 * currentAnimation, size, size, GraphicsUnit.Pixel);//new size i can change:)
            
            //g.DrawImage(spriteSheet, new Rectangle(new Point((int)posX - flip * size / 2, (int)posY), new Size(flip * size, size)), 26 * currentFrame, 32* currentAnimation, size, size, GraphicsUnit.Pixel);//new size i can change:)


        }

        public void death()
        {
            if(HP == 0)
            {
                restartinc r = new restartinc();
                r.ShowDialog();
            }
        }
        

        public void setAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch(currentAnimation)
            {
                case 0:
                    if (isMoving)
                        currentLimit = runFrames;
                    else
                        currentLimit = IdleFrames;
                    break;
                case 1:
                    currentLimit = jumpFrames;
                    break;
               


            }
        }
    }
}
