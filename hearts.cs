using Project.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class hearts
    {
        public Image heartsImage;
        public int posX;
        public int posY;
        public int currentLimit;
        public int currentFrame;
        public int currentAnimation;
        public int currentState;
        public int fullHearts;
        public hearts(int posX,int posY,int fullHearts,int currentState,Image heartsImage)
        {
            this.posX = posX;
            this.posY = posY;
            this.heartsImage = heartsImage;
            this.fullHearts = fullHearts;
            currentLimit = fullHearts;
            currentAnimation = 0;
            currentFrame = 0;
        
        }

        public void drawHearts(Graphics g,Entity entity)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else
            {
                if (entity.howmuchDamaged > 0 && !entity.deadFromEnemy)
                {
                    currentAnimation = entity.howmuchDamaged;
                }
                else
                    currentAnimation = 0;

                currentFrame = 5;
            }
            g.DrawImage(heartsImage,new Rectangle(new Point(posX ,posY ), new Size(350, 30)), 0, 16*currentAnimation, 200, 17, GraphicsUnit.Pixel);
            
        }
        public void setAnimation(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = fullHearts;
                    break;
                case 1:
                    currentLimit = currentState;
                    
                    break;


            }
        }
    }
}
