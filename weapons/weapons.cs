using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Entities;

namespace Project.weapons
{
    public class Weapons
    {
        public int id;
        public float posX;
        public float posY;

        public Image weaponSheet;
        public bool onFloor ;
   

        
        public Weapons(float posX, float posY, int Id, Image weaponSh)
        {
            this.posX = posX;
            this.posY = posY;

            this.id = Id;
            this.onFloor = true;
            this.weaponSheet = weaponSh;
            
        }
        public void hit(Graphics g,Entity player)
        {
            foreach (Weapons weapon in Level1.weapons)
            {
                
                if (player.hitPressed && weapon.id == 1d)
                {
                    if (player.flip == 1)
                    {
                        g.TranslateTransform(player.posX - 6 + Level1.delta.X+14/*/ 2.0f*/, player.posY + 44 / 2.0f + Level1.delta.Y);
                        g.RotateTransform(90);
                        g.TranslateTransform(-(player.posX - 6 + Level1.delta.X+14), -(player.posY + 44 / 2.0F + Level1.delta.Y)) ;

                    }
                    else if (player.flip == -1)
                    {
                        g.TranslateTransform(player.posX + 6 + Level1.delta.X+14/*/ 2.0f*/, player.posY + 66 / 2.0f + Level1.delta.Y);
                        g.RotateTransform(-90);
                        g.TranslateTransform(-(player.posX - 6 + Level1.delta.X+14), -(player.posY + 44 / 2.0F + Level1.delta.Y));
                    }
                }
            }
        }
        public void drawHandWeapon(Graphics g,Entity player)
        {
            if (id == 1 && !onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 18 / 2 +14 ) + (int)player.posX - (int)posX + Level1.delta.X , (int)posY - 1 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y), new Size(player.flip * 6, 30)), 0, 0, 6, 30, GraphicsUnit.Pixel);//catana
            }

            if (id == 2 && !onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 22 / 2 + 14) + (int)player.posX - (int)posX + Level1.delta.X , (int)posY - 3 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y ), new Size(player.flip * 12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);//big weapon
            }

            if (id == 3 && !onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 22 / 2 + 14) + (int)player.posX - (int)posX + Level1.delta.X , (int)posY - 3 - player.currentFrame + (int)player.posY - (int)posY + Level1.delta.Y ), new Size(player.flip * 12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);//big weapon
            }
        }
        public void drawWeapon(Graphics g, Entity player)
        {
            if (id == 1 && onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX) + Level1.delta.X, (int)posY - player.currentFrame + Level1.delta.Y), new Size(6, 30)), 0, 0, 6, 30, GraphicsUnit.Pixel);//catana
            }
            if (id == 2 && onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + Level1.delta.X, (int)posY - player.currentFrame + Level1.delta.Y), new Size(12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);//big weapon
            }

            if (id == 3 && onFloor)
            {
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + Level1.delta.X, (int)posY - player.currentFrame + Level1.delta.Y), new Size(12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);//big weapon
            }

            
        }
      
            //g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip *  22 / 2)  + (int)player.posX , (int)posY - 5 - player.currentFrame   + (int)player.posY ), new Size(player.flip * 12, 30)), 0, 0, 12, 30 , GraphicsUnit.Pixel);//big weapon
       }
}


