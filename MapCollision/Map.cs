using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Entities;
using static Project.MapCollision.tiles;

namespace Project.MapCollision
{
    public class Map
    {
        public static int mapX = 1;
        public static int mapY = 1;
        public const int mapHeight = 20;
        public const int mapWidth = 20;
        public static int cellSize = 31;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image spriteSheet;
        public static List<rock> rocks = new List<rock>();

        public static void Init()
        {
            map = GetMap();
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Forest.png"));
        }

        public static int[,] GetMap()
        {
            return new int[,]{
                { 1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,2},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,11,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,11,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,11,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,11,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,11,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,11,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,11,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,11,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,7},
                { 3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,4},
            };
            //return new int[,]{
            //    { 1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,2},
            //    { 5,10,-1,0,0,0,0,0,0,0,0,0,0,11,0,0,10,-1,-1,7},
            //    { 5,-1,-1,-1,0,11,11,11,11,11,11,11,11,11,11,11,-1,-1,-1,7},
            //    { 5,10,-1,-1,11,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
            //    { 5,-1,-1,-1,11,0,0,0,0,0,0,0,0,0,11,0,-1,-1,-1,7},
            //    { 5,10,-1,-1,11,11,11,11,11,11,11,0,0,0,0,0,10,-1,-1,7},
            //    { 5,-1,-1,-1,0,0,0,0,11,0,0,0,0,0,0,0,-1,-1,-1,7},
            //    { 5,10,-1,-1,11,11,11,11,11,11,11,11,11,11,0,0,10,-1,-1,7},
            //    { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
            //    { 5,10,-1,-1,0,0,0,0,0,0,11,0,0,0,0,0,10,-1,-1,7},
            //    { 5,-1,-1,-1,0,0,11,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
            //    { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
            //    { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
            //    { 5,10,-1,-1,0,0,0,11,0,0,0,0,0,0,0,0,10,-1,-1,7},
            //    { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
            //    { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,11,0,0,10,-1,-1,7},
            //    { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
            //    { 5,0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,7},
            //    { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,7},
            //    { 3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,4},
            //};
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
                        rock Rock = new rock(j * cellSize, i * cellSize);
                        rocks.Add(Rock);
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(20, 11)), 581, 114, 19, 11, GraphicsUnit.Pixel);
                    }

                }
            }
        }
        public static bool Collide(Entity player)
        {
            for (int i = 0; i < rocks.Count; i++)
            {
                int deltaX = (player.posX + player.size / 2) - (rocks[i].posX + rocks[i].sizeX / 2);
                int deltaY = (player.posY + player.size / 2) - (rocks[i].posY + rocks[i].sizeY / 2);

                if (Math.Abs(deltaX) <= player.size / 2 + rocks[i].sizeX / 2)
                {
                    if (Math.Abs(deltaY) <= player.size / 2 + rocks[i].sizeY / 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void DrawMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    //if(map[i,j] == 11)
                    //{
                    //   g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 575, 434, 73, 37, GraphicsUnit.Pixel);

                    //}
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