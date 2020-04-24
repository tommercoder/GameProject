using System.Drawing;

namespace Project.Entities
{
    public class Entity
    {
        public float posX;
        public float posY;

        public float velocityX;//speed
        public float velocityY;//speed
        public float gravity = 0.5f;

        public float dirX;
        public float dirY;
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

        public Entity(float posX,float posY,int IdleFrames,int runFrames,int attackFrames,int deathFrames,int jumpFrames,Image spriteSheet)
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
               
            if (currentFrame < currentLimit - 1)//2 for space cadet
                currentFrame++;
            else
                currentFrame = 0;
            g.DrawImage(spriteSheet, new Rectangle(new Point((int)posX - flip * size / 2, (int)posY), new Size(flip * size, size)), 38 * currentFrame, 31 * currentAnimation, size, size, GraphicsUnit.Pixel);//new size i can change:)
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
