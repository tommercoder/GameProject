using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    public static class MapController
    {
        public const int mapHeight = 20;
        public const int mapWidth = 20;
        public static int cellSize = 31;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image spriteSheet;

        public static void Init()
        {
            map = GetMap();
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Tileset1.png"));
        }
        public static int[,] GetMap()
        {
            return map = new int[,] {
                { 3,2,2,2,5,0,29,29,29,29,29,29,29,0,0,3,2,2,2,5},
                { 3,29,29,29,5,0,29,29,29,29,29,29,29,29,29,29,29,29,29,5},
                { 3,29,4,4,5,0,0,25,0,25,0,0,0,0,0,3,29,29,29,5},
                { 3,29,5,0,0,0,0,25,0,25,0,0,0,0,0,3,29,29,2,5},
                { 3,7,5,0,0,0,32,25,34,25,33,0,0,0,0,3,29,29,5,0},
                { 32,23,33,0,0,0,25,25,25,25,25,0,0,0,0,3,29,29,5,0},
                { 32,23,33,0,0,0,32,25,34,25,33,0,0,0,0,3,29,29,5,0},
                { 32,23,33,0,0,0,26,25,25,25,25,0,0,0,0,3,29,29,5,0},
                { 3,23,2,5,0,0,0,0,24,0,0,0,0,0,0,3,29,29,5,0},
                { 3,6,26,5,0,0,3,2,6,2,2,2,5,0,0,3,4,29,4,5},
                { 3,22,24,5,0,0,3,29,29,29,29,29,5,0,0,0,3,29,29,5},
                { 3,24,25,2,5,0,3,29,29,29,29,29,5,0,0,0,3,29,29,5},
                { 3,27,26,25,5,0,3,29,29,29,29,29,5,3,4,4,4,29,29,5},
                { 3,25,4,4,5,0,3,4,4,4,29,4,5,3,29,29,29,29,29,5},
                { 3,6,5,0,0,0,0,0,0,0,23,0,0,3,29,29,29,29,29,5},
                { 3,7,2,2,2,2,2,2,5,0,23,0,0,3,29,29,29,29,29,5},
                { 3,22,22,29,29,29,29,29,5,0,23,0,0,3,29,29,29,29,29,5},
                { 3,25,25,22,22,22,29,29,5,0,23,0,0,3,29,29,29,29,29,5},
                { 3,29,26,27,22,29,29,29,30,30,30,30,0,3,4,4,4,29,4,5},
                { 3,4,4,4,4,4,4,4,0,0,0,0,0,0,0,0,3,8,5,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

            };
        }

        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize * 30, cellSize * 30)), 157, 290, 10, 10, GraphicsUnit.Pixel);//black fon
                    }
                    else
                    if (map[i, j] == 2)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(32, 40)), 119, 19, 32, 40, GraphicsUnit.Pixel);//wall
                    }
                    else
                    if (map[i, j] == 3)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(32, 32)), 55, 27, 32, 32, GraphicsUnit.Pixel);//left wall
                    }
                    else
                    if (map[i, j] == 4)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(32, 32)), 119, 20, 32, 32, GraphicsUnit.Pixel);//фронт сітна
                    }
                    else
                    if (map[i, j] == 5)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(32, 32)), 9, 27, 32, 32, GraphicsUnit.Pixel);//right wall
                    }
                    else
                    if (map[i, j] == 6)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(32, 32)), 192, 160, 32, 32, GraphicsUnit.Pixel);//половина плитки
                    }
                    else
                    if (map[i, j] == 7)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(32, 32)), 160, 192, 32, 32, GraphicsUnit.Pixel);//плитка без куска
                    }
                    else
                    if (map[i, j] == 8)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(32, 32)), 10, 595, 48, 29, GraphicsUnit.Pixel);//ворота
                    }
                    else
                   if (map[i, j] == 32)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 199, 606, 25, 28, GraphicsUnit.Pixel);//Грязна верхня дорога
                    }
                    else
                   if (map[i, j] == 33)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 224, 606, 25, 28, GraphicsUnit.Pixel);//Грязна верхня дорога
                    }
                    else
                   if (map[i, j] == 34)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 248, 606, 32, 28, GraphicsUnit.Pixel);//Грязна верхня дорога
                    }
                }
            }
        }
        public static void DrawMap(Graphics g)
        {
            for(int i=0;i<mapWidth;i++)
            {
                for(int j=0;j<mapHeight;j++)
                {
                    if (map[i, j] == 22)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 160, 383, 32, 32, GraphicsUnit.Pixel);// дорога
                    }
                    else
                   if (map[i, j] == 23)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 385, 407, 32, 32, GraphicsUnit.Pixel);//грязьова дорога
                    }
                    else
                   if (map[i, j] == 24)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 256, 480, 32, 32, GraphicsUnit.Pixel);//тріснута плитка
                    }
                    else
                   if (map[i, j] == 25)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 288, 191, 32, 32, GraphicsUnit.Pixel);//4 плитки
                    }
                    else
                   if (map[i, j] == 26)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 384, 160, 32, 32, GraphicsUnit.Pixel);//4 тріснуті плитки
                    }
                    else
                   if (map[i, j] == 27)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 416, 160, 32, 32, GraphicsUnit.Pixel);//Г плитка
                    }
                    else
                   if (map[i, j] == 28)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 10, 595, 48, 29, GraphicsUnit.Pixel);//ворота
                    }
                    else
                   if (map[i, j] == 29)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 480, 160, 32, 32, GraphicsUnit.Pixel);//ціла плитка
                    }
                    else
                   if (map[i, j] == 30)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 376, 428, 32, 32, GraphicsUnit.Pixel);//Грязна дорога
                    }
                    else
                   if (map[i, j] == 31)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 377, 544, 32, 32, GraphicsUnit.Pixel);//Грязна верхня дорога
                    }
                    else
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 219, 319, 32, 32, GraphicsUnit.Pixel);
                    }
                }
            }
            SeedMap(g);
        }
        public static int GetWidth()
        {
            return cellSize * (mapWidth) + 15;
        }
        public static int GetHeight()
        {
            return cellSize * (mapHeight + 1) + 10;
        }
    }
}