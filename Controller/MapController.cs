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
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Forest.png"));
        }
        public static int[,] GetMap()
        {
            return map = new int[,] {
                { 1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,2},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,4},

            };
        }

        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 10)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize * 3, cellSize * 3)), 202, 298, 107, 114, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 11)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 581, 114, 19, 11, GraphicsUnit.Pixel);
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
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 2)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 3)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 4)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 5)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 20, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 6)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 7)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 30, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 8)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 0, 20, 20, GraphicsUnit.Pixel);
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