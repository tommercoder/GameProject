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
        public float howmuchDamaged;
        public int HP;
        public float velocity = 3;
        public int playerSpeed;
        public float dirX;
        public float dirY;
        public bool isMoving;
        public bool falling;
        public bool hitPressed;
        public bool ShiftPressed;
        public bool dead;
        public bool collidedead;
        

        public int flip;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;

        public  int IdleFrames;
        public  int runFrames;
        public  int attackFrames;
        public  int deathFrames;
        public int RedFrames;

        public int size;
        public float height;

        public Image spriteSheet;
        public bool Freehands = true;
        public int id;
        public int Ih;
   
        public Entity(float posX,float posY,int IdleFrames,int runFrames,int attackFrames,int deathFrames,int RedFrames,Image spriteSheet)
        {
            
            HP = 1000;
            this.OldposX = posX;
            this.OldposY = posY;
            this.posX = posX;
            this.posY = posY;
            this.IdleFrames = IdleFrames;
            this.runFrames = runFrames;
            this.attackFrames = attackFrames;
            this.deathFrames = deathFrames;
            this.spriteSheet = spriteSheet;
            this.RedFrames = RedFrames;
            size = 31;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = IdleFrames;
            flip = 1;
            playerSpeed = 3;
            falling = false;
            dead = false;
            collidedead = false;
        }

        public void Move()
        {
            if (game.Apressed || game.Dpressed)
            {
                posX += dirX;
                //OldposX += dirX;
            }
            if (game.Wpressed || game.Spressed)
            {
                //OldposY += dirY;
                posY += dirY;
            }
        }

        public void PlayAnimation(Graphics g)
        {

            if(currentFrame < currentLimit - 3)//2 for space cadet
                currentFrame++;
            else
                currentFrame = 0;
            
           g.DrawImage(spriteSheet, new Rectangle(new Point((int)posX - flip * size / 2 + game.delta.X + 14, (int)posY + game.delta.Y), new Size(flip * size, size)), 26 * currentFrame, 32 * currentAnimation, size, size, GraphicsUnit.Pixel);//new size i can change:)
            
            


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
                    currentLimit = RedFrames;
                    break;
               


            }
        }
    }
}
