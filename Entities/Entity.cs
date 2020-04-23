using System.Data;
using System;
using Microsoft.Xna.Framework;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Entities
{
    public class Entity
    {
       
        public int posX;
        public int posY;

        public double player_position;
        public double posXnow;
        public double posYnow;

        //public Vector2 position;
        //public Vector2 velocity;
        //public readonly Vector2 gravity = new Vector2(0, -9.8f);
        
        public int dirX;
        public int dirY;
        public bool isMoving;
        public bool isJumping;

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

        public Entity(int posX,int posY,int IdleFrames,int runFrames,int attackFrames,int deathFrames,int jumpFrames,Image spriteSheet)
        {
           // position = new Vector2(posX, posY);
           // velocity = Vector2.Zero;
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
        }

        public void Move()
        {
                posX += dirX;
                posY += dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (isJumping) 
           g.DrawImage(spriteSheet, new System.Drawing.Rectangle(new System.Drawing.Point((int)posX - flip * size / 2, (int)posY), new Size(flip * size, size)), 38 * currentFrame, 32 * currentAnimation, size, size, GraphicsUnit.Pixel);//new size i can change:)
               else
                g.DrawImage(spriteSheet, new System.Drawing.Rectangle(new System.Drawing.Point((int)posX - flip * size / 2, (int)posY), new Size(flip * size, size)), 38 * currentFrame, 32 * currentAnimation, size, size, GraphicsUnit.Pixel);//new size i can change:)
            if (currentFrame < currentLimit - 1)//2 for space cadet
                currentFrame++;
            else
                currentFrame = 0;
        }

        public void PlayJumpAnimation(Graphics g)
        {


            g.DrawImage(spriteSheet, new System.Drawing.Rectangle(new System.Drawing.Point((int)posX - flip * size / 2, (int)posY), new Size(flip * size, size)), 38 * currentFrame, 32 * currentAnimation, size, size, GraphicsUnit.Pixel);//new size i can change:)

            if (currentFrame < currentLimit - 1)//2 for space cadet
                currentFrame++;
            else
                currentFrame = 0;
        }
        public void setAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch(currentAnimation)
            {
                case 0:
                    currentLimit = IdleFrames;
                    break;
                case 1:
                    currentLimit = runFrames;
                    break;
                case 2:
                    currentLimit = attackFrames;
                    break;
                case 7:
                    currentLimit = deathFrames;
                    break;
                case 5:
                    currentLimit = jumpFrames;
                    break;


            }
        }

        
    }
}
