using System.Drawing;

namespace Project.Entities
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public bool isMoving;
        public bool isJumping;

        public int flip;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;
        public int offset;

        public  int IdleFrames;
        public  int runFrames;
        public  int attackFrames;
        public  int deathFrames;
        public int jumpFrames;

        public int size;
        public int height;

        public Image spriteSheet;

        public Entity(int posX,int posY,int IdleFrames,int runFrames,int attackFrames,int deathFrames,int jumpFrames,Image spriteSheet)
        {
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

           g.DrawImage(spriteSheet, new Rectangle(new Point(posX - flip * size / 2, posY), new Size(flip * size, size)), 38 * currentFrame, 31 * currentAnimation, size, size, GraphicsUnit.Pixel);//new size i can change:)
            
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
