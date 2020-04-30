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
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Tileset.png"));
        }
        public static int[,] GetMap()
        {
            return map = new int[,] {
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,13,12,13,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,11,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,11,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,11,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,18,16,16,16,16,16,14,20,20},
                { 20,20,20,20,20,26,98,98,98,98,98,21,17,17,17,17,17,17,20,20},
                { 20,20,20,20,20,25,99,99,99,99,11,21,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,25,99,27,99,88,11,21,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,25,99,99,99,99,11,21,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,25,99,28,99,99,11,21,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,24,22,22,22,22,22,23,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,17,17,17,17,17,17,17,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
                { 20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
            };
        }

        public static void SeedMap(Graphics g)
        {
             //Bitmap grass = new Bitmap("Resources\\Tileset.png");
             //   Bitmap croppedImage = grass.Clone(new Rectangle(0, 0, 16, 16),grass.PixelFormat);
         
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 99)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize * 2, cellSize * 2)), 47, 268, 16, 16, GraphicsUnit.Pixel);//сірий
                    }
                    else
                    if (map[i, j] == 0)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 328, 155, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 88)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(9, 12)), 166, 320, 9,12, GraphicsUnit.Pixel);//кувшин
                    }
                    else
                    if (map[i, j] == 17)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 88, 317, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 98)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 41, 32, 16, 16, GraphicsUnit.Pixel);//верхня частина дороги
                    }
                    else
                    if (map[i, j] == 22)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 39, 100, 16, 16, GraphicsUnit.Pixel);//верхня частина дороги
                    }
                    else
                    if (map[i, j] == 23)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 99, 16, 16, GraphicsUnit.Pixel);//правий нижній край
                    }
                    else
                    if (map[i, j] == 24)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 32, 100, 16, 16, GraphicsUnit.Pixel);//лівий нижній край
                    }
                    else
                    if (map[i, j] == 25)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 32, 48, 16, 16, GraphicsUnit.Pixel);//лівий край
                    }
                    else
                    if (map[i, j] == 26)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 33, 32, 16, 16, GraphicsUnit.Pixel);//лівий верхній край
                    }
                    else
                    if (map[i, j] == 27)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(16, 11)), 214, 354, 16, 11, GraphicsUnit.Pixel);//сундук
                    }
                    else
                    if (map[i, j] == 28)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(48, 16)), 166, 367, 48, 16, GraphicsUnit.Pixel);//труна
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
                    if (map[i, j] == 11)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 140, 172, 16, 16, GraphicsUnit.Pixel);//вертикальна дорога
                    }
                    else
                   if (map[i, j] == 12)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 156, 212, 16, 16, GraphicsUnit.Pixel);//двері
                    }
                    else
                   if (map[i, j] == 13)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 103, 308, 16, 16, GraphicsUnit.Pixel);//горизонтальна стіна
                    }
                    else
                   if (map[i, j] == 14)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 292, 16, 16, GraphicsUnit.Pixel);//дорога поворот ліво
                    }
                    else
                   if (map[i, j] == 15)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 88, 289, 16, 16, GraphicsUnit.Pixel);//дорога поворот право
                    }
                    else
                   if (map[i, j] == 16)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 104, 292, 16, 16, GraphicsUnit.Pixel);//горизонтальна дорога
                    }
                    else
                   if (map[i, j] == 88)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 88, 317, 16, 16, GraphicsUnit.Pixel);//фронтальна частина дороги
                    }
                    else
                   if (map[i, j] == 18)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 89, 160, 16, 16, GraphicsUnit.Pixel);//верхній поворот вправо
                    }
                    else
                   if (map[i, j] == 19)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 119, 160, 16, 16, GraphicsUnit.Pixel);//верхній поворот вліво
                    }
                    else
                   if (map[i, j] == 11)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 249, 47, 16, 16, GraphicsUnit.Pixel);//лава
                    }
                    else
                   if (map[i, j] == 21)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 37, 16, 16, GraphicsUnit.Pixel);//розширення для дороги права частина
                    }
                    else
                   if (map[i, j] == 2)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 39, 100, 16, 16, GraphicsUnit.Pixel);//нижня частина дороги
                    }
                    else
                   if (map[i, j] == 23)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 89, 160, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 24)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 89, 160, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 25)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 89, 160, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 26)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 89, 160, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 27)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 89, 160, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 28)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 89, 160, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 29)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 89, 160, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                   if (map[i, j] == 30)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 89, 160, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 249, 47, 16, 16, GraphicsUnit.Pixel);
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