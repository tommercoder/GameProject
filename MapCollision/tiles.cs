//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
using Project.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MapCollision
{
    public class tiles
    {

        //        public System.Drawing.Rectangle rectangle;

        //        public class Ground : tiles
        //        {
        //            public Ground(int size, System.Drawing.Rectangle newRectangle)
        //            {

        //                this.rectangle = newRectangle;
        //            }
        //        }

        //        public void Draw(Graphics g)
        //        {
        //            for (int i = 0; i < 9; i++)
        //            {
        //                for (int j = 0; j < 9; j++)
        //                {
        //                    g.DrawImage(newMap.spriteSheet, new System.Drawing.Rectangle(new System.Drawing.Point(j * newMap.cellSize, i * newMap.cellSize), new Size(newMap.cellSize * 3, newMap.cellSize * 3)), 0, 0, 20, 20, GraphicsUnit.Pixel);
        //                }
        //            }
        //        }
        //    }
        public int posX;
        public int posY;

        public int sizeX;
        public int sizeY;

        public class rock : tiles
        {
           public rock(int x,int y)
            {
                posX = x;
                posY = y;
                sizeX = 32;
                sizeY = 32;

            }

        }


    }



    }
