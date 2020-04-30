using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Entities;
namespace Project.weapons
{
    public class Weapons
    {

        public float posX;
        public float posY;

        public static Image weaponSheet;

        public Weapons(float posX, float posY, Image weaponSh)
        {
            this.posX = posX;
            this.posY = posY;
       
          weaponSheet = weaponSh;
        }

        public void drawWeapon(Graphics g,Entity player)
        {
           
            if (player.hitPressed)
            {
                if (player.flip == 1)
                {
                    g.TranslateTransform(player.posX - 6 /*/ 2.0f*/, player.posY + 43 / 2.0f);
                    g.RotateTransform(80);
                    g.TranslateTransform(-(player.posX - 6), -(player.posY + 43 / 2.0F));
                 
                }
                else if(player.flip == -1)
                {
                    g.TranslateTransform(player.posX + 6 /*/ 2.0f*/, player.posY + 43 / 2.0f);
                    g.RotateTransform(-80);
                    g.TranslateTransform(-(player.posX + 6), -(player.posY + 43 / 2.0F));
                }
            }
            g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip *  18 / 2)  + (int)player.posX  , (int)posY - 1 - player.currentFrame   + (int)player.posY ), new Size(player.flip * 10, 29)), 0, 0, 10, 29 , GraphicsUnit.Pixel);//catana
            //g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip *  22 / 2)  + (int)player.posX , (int)posY - 5 - player.currentFrame   + (int)player.posY ), new Size(player.flip * 12, 30)), 0, 0, 12, 30 , GraphicsUnit.Pixel);//big weapon
            
            

        }
    }
   

}
