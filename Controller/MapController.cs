﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project.Controller.collideobjects;

namespace Project.Controller
{
    public static class MapController
    {
        public const int mapHeight = 60;
        public const int mapWidth = 60;
        public static int cellSize = 32;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image spriteSheet;
        public static int[] collisionNumbers = new int[4] {2,3,4,5};
       // internal static IEnumerable<MapController> collideList;

        //public static List<collide> collideList = new List<collide>();
        /// <summary>
        /// old collision
        /// List <Rectangle> tile = new List<Rectangle>();
        /// in every g.draw image
        /// Rectangle r = new Rectangle(j*cellsize,i*cellsize);
        /// tile.add(r);
        /// 
        /// 
        /// </summary>

        public static void Init()
        {
            map = GetMap();
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Tileset1.png"));
        }
        public static int[,] GetMap()
        {
            return map = new int[,] {
                { 0 ,0,0 ,0 ,0 ,0 ,29,29,29,29,29,29,29,0 ,0 ,3 ,2 ,2 ,2 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,29,29,29,0 ,0 ,29,29,29,29,29,29,29,29,29,29,29,22,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,29,29 ,29 ,0 ,0 ,0 ,25,0 ,25,0 ,0 ,0 ,0 ,0 ,3 ,22,29,22,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,29,29 ,29 ,0 ,0 ,0 ,25,0 ,25,0 ,0 ,0 ,0 ,0 ,3 ,29,22,2 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                {0 ,29 ,29 ,0 ,0 ,0 ,32,25,34,25,33,0 ,0 ,0 ,0 ,3 ,22,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 32,29,29,0 ,0 ,0 ,25,25,25,25,25,0 ,0 ,0 ,0 ,3 ,29,22,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 32,29,29,0 ,0 ,0 ,32,25,34,25,33,0 ,0 ,0 ,0 ,3 ,22,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 32,29,29,0 ,0 ,0 ,26,25,25,25,25,0 ,0 ,0 ,0 ,3 ,29,22,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,29 ,0 ,0 ,0 ,0 ,0 ,24,0 ,0 ,0 ,0 ,0 ,0 ,3 ,22,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,26 ,26,0 ,0 ,0 ,3 ,2 ,6 ,2 ,2 ,2 ,5 ,0 ,0 ,3 ,4 ,22,4 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,22,24,0 ,0 ,0 ,3 ,29,29,29,29,29,5 ,0 ,0 ,0 ,3 ,29,22,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,24,25,0 ,5 ,0 ,3 ,29,29,29,29,29,5 ,0 ,0 ,0 ,3 ,22,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,27,26,25,5 ,0 ,3 ,29,29,29,29,29,5 ,3 ,4 ,4 ,4 ,29,22,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,25,4 ,4 ,5 ,0 ,3 ,4 ,4 ,4 ,29,22 ,5 ,3 ,29,22,29,22,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,6 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,29,22 ,0 ,3 ,22,29,22,29,22,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,7 ,2 ,2 ,2 ,2 ,2 ,2 ,5 ,0 ,29,29 ,0 ,3 ,29,22,22,22,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,22,22,29,29,29,29,29,5 ,0 ,29,22 ,0 ,3 ,22,29,22,29,22,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,25,25,22,22,22,29,29,26 ,26 ,29,29 ,0 ,3 ,29,22,29,22,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,26,27,22,29,29,29,26,26,26,26,0 ,3 ,4 ,4 ,4 ,29,4 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,26 ,26 ,26 ,26 ,0 ,0 ,0 ,0 ,3 ,22,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,2 ,29,2 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,30,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,27,0 ,0 ,0 ,27,29,27,27,0 ,0 ,0 ,29,0 ,0 ,0 ,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,27,32,34,33,29,29,29,29,0 ,34,33,29,32,34,33,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,22,22,22,7 ,6 ,25,22,22,26,26,26,26,29,22,29,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,22,25,7 ,0 ,0 ,0 ,0 ,0 ,22,7 ,0 ,0 ,29,29,29,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,22,26,0 ,0 ,0 ,0 ,0 ,0 ,7 ,0 ,0 ,0 ,29,29,29,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,22,22,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,22,22,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,22,22,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,22,22,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,30,30,30,30,30,30,30,29,22,22,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,29,22,22,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,29,22,22,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,29,22,22,0 ,0 ,0 ,0 ,0 ,0 ,3 ,2 ,2 ,2 ,2 ,2 ,2 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,29,22,22,0 ,0 ,0 ,0 ,0 ,0 ,3 ,29,29,29,22,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,23,23,23,23,23,23,23,23,7 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,29,29,22,22,22,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,29,29,29,22,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,4 ,4 ,4 ,4 ,4 ,4 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,2 ,2 ,2 ,2 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,29,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,30,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,29,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,29,29,29,29,2 ,2 ,2 ,2 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,29,29,22,29,29,29,29,29,5 ,0 ,0 ,30,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,29,22,22,22,29,29,29,29,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,29,29,22,29,29,29,29,29,5 ,0 ,0 ,0 ,0 ,3 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,29,29,29,29,29,29,29,29,5 ,0 ,0 ,0 ,0 ,3 ,0 ,29,29,29,29,29,29,29,29,29,0 ,29,0 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,22,29,29,29,29,29,29,22,5 ,0 ,0 ,0 ,0 ,3 ,0 ,29,29,22,29,29,29,22,29,29,0 ,29,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,22,22,22,29,29,29,29,22,22,22,23,23,23,23,23,29,29,22,22,22,29,22,22,22,29,29,29,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,29,22,29,29,29,29,29,29,22,7 ,30,30,30,30,30,29,29,29,22,29,29,29,22,29,29,29,29,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 3 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,5,0 ,0 ,0 ,0 ,3 ,0 ,29,29,29,29,29,29,29,29,29,29,29,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,4 ,4 ,4 ,4 ,4 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,4 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0},
                { 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,30,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,30,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,30,0},


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
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize+Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize * 30, cellSize * 30)), 157, 290, 10, 10, GraphicsUnit.Pixel);//black fon
                    }
                    else
                    if (map[i, j] == 2)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(32, 40)), 119, 19, 32, 40, GraphicsUnit.Pixel);//wall
                        //collide c = new collide(j * cellSize, i * cellSize);
                        //collideList.Add(c);
                        
                    }
                    else
                    if (map[i, j] == 3)
                    {
                        //collide c = new collide(j * cellSize, i * cellSize);
                        //collideList.Add(c);
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(32, 32)), 55, 27, 32, 32, GraphicsUnit.Pixel);//left wall
                    }
                    else
                    if (map[i, j] == 4)
                    {
                        //collide c = new collide(j * cellSize, i * cellSize);
                        //collideList.Add(c);
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(32, 32)), 119, 20, 32, 32, GraphicsUnit.Pixel);//фронт сітна
                    }
                    else
                    if (map[i, j] == 5)
                    {
                        //collide c = new collide(j * cellSize, i * cellSize);
                        //collideList.Add(c);
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(32, 32)), 9, 27, 32, 32, GraphicsUnit.Pixel);//right wall
                    }
                    else
                    if (map[i, j] == 6)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(32, 32)), 192, 160, 32, 32, GraphicsUnit.Pixel);//половина плитки
                    }
                    else
                    if (map[i, j] == 7)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(32, 32)), 160, 192, 32, 32, GraphicsUnit.Pixel);//плитка без куска
                    }
                    else
                    if (map[i, j] == 8)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(32, 32)), 10, 595, 48, 29, GraphicsUnit.Pixel);//ворота
                    }
                    else
                   if (map[i, j] == 32)
                    {
                        //collide c = new collide(j * cellSize, i * cellSize);
                        //collideList.Add(c);
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 199, 606, 25, 28, GraphicsUnit.Pixel);//Грязна верхня дорога
                    }
                    else
                   if (map[i, j] == 33)
                    {
                        //collide c = new collide(j * cellSize, i * cellSize);
                        //collideList.Add(c);
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 224, 606, 25, 28, GraphicsUnit.Pixel);//Грязна верхня дорога
                    }
                    else
                   if (map[i, j] == 34)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 248, 606, 32, 28, GraphicsUnit.Pixel);//Грязна верхня дорога
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
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 160, 383, 32, 32, GraphicsUnit.Pixel);// дорога
                    }
                    else
                   if (map[i, j] == 23)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 385, 407, 32, 32, GraphicsUnit.Pixel);//грязьова дорога
                    }
                    else
                   if (map[i, j] == 24)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 256, 480, 32, 32, GraphicsUnit.Pixel);//тріснута плитка
                    }
                    else
                   if (map[i, j] == 25)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 288, 191, 32, 32, GraphicsUnit.Pixel);//4 плитки
                    }
                    else
                   if (map[i, j] == 26)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 384, 160, 32, 32, GraphicsUnit.Pixel);//4 тріснуті плитки
                    }
                    else
                   if (map[i, j] == 27)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 416, 160, 32, 32, GraphicsUnit.Pixel);//Г плитка
                    }
                    else
                   if (map[i, j] == 28)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 10, 595, 48, 29, GraphicsUnit.Pixel);//ворота
                    }
                    else
                   if (map[i, j] == 29)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 480, 160, 32, 32, GraphicsUnit.Pixel);//ціла плитка
                    }
                    else
                   if (map[i, j] == 30)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 376, 428, 32, 32, GraphicsUnit.Pixel);//Грязна дорога
                    }
                    else
                   if (map[i, j] == 31)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 377, 544, 32, 32, GraphicsUnit.Pixel);//Грязна верхня дорога
                    }
                    else
                    {
                        //collide c = new collide(j * cellSize, i * cellSize);
                        //collideList.Add(c);
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize + Level1.delta.X, i * cellSize + Level1.delta.Y), new Size(cellSize, cellSize)), 219, 319, 32, 32, GraphicsUnit.Pixel);
                    }
                }
            }
            SeedMap(g);
            //collideList.Clear();
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