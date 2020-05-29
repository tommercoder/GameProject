using Project.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.chests_and_staff
{
    public class staff
    {
        public Image ChestSprite;
        public int posX;
        public int posY;
        public int openFrames;
        public int chestIdle;
        public int currentLimit;
        public int currentFrame;
        public int currentAnimation;
        public bool isOpened;
        public int id;

       public staff(int posx,int posy,int ID,int chestIdle,int openFrames,Image chestSprite)
       {
            isOpened = false;
            posX = posx;
            posY = posy;
            id = ID;
            this.openFrames = openFrames;
            ChestSprite = chestSprite;
            currentFrame = 0;
            this.chestIdle = chestIdle;
            currentLimit = chestIdle;
            ChestSprite = chestSprite;
        }
        public staff(int posx,int posy,int ID,Image chestSprite)
        {
            posX = posx;
            posY = posy;
            id = ID;
            ChestSprite = chestSprite;
        }
        public void drawIdleChest(Graphics g)
        {
            
            g.DrawImage(ChestSprite, new Rectangle(new Point(posX + game.delta.X, posY + game.delta.Y), new Size(32, 32)), 32 * currentFrame, 32 * currentAnimation, 32, 32, GraphicsUnit.Pixel);
            
        }
        public void PlayAnimation(Graphics g)
        {
            if (id == 1)
            {
                if (currentFrame < currentLimit - 1)
                    currentFrame++;
                else
                {
                    if (currentAnimation == 0)
                        currentFrame = 0;
                    if (currentAnimation == 1)
                        currentFrame = 1;
                }
            }
           
                if (id == 1)
                {
                if(currentAnimation==0)
                    g.DrawImage(ChestSprite, new Rectangle(new Point(posX + game.delta.X, posY + game.delta.Y), new Size(32, 32)), 30 * currentFrame, 30 * currentAnimation, 32, 32, GraphicsUnit.Pixel);
                if(currentAnimation==1)
                    g.DrawImage(ChestSprite, new Rectangle(new Point(posX + game.delta.X+7, posY + game.delta.Y+3), new Size(32, 32)), 30 * currentFrame, 30 * currentAnimation, 32, 32, GraphicsUnit.Pixel);
                // isOpened = true;
                
                }
          
            }
           
        public void playFlask(Graphics g,Entity player)
        {
            g.DrawImage(ChestSprite, new Rectangle(new Point(((int)posX) + game.delta.X, (int)posY - player.currentFrame +game.delta.Y), new Size(32, 32)), 0, 0, 32, 32, GraphicsUnit.Pixel);
        }

        public void setAnimation(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch(currentAnimation)
            {
                case 0:
                    currentLimit = chestIdle;
                    break;
                case 1:
                    currentLimit = openFrames;
                    break;


            }
        }
    }
}
