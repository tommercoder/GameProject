//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Content;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static Project.MapCollision.tiles;

//namespace Project.MapCollision
//{
//    class newMap
//    {
//        public static int cellSize = 50;

//        public int width;
//        public int height;
//        public int Width
//        {
//            get { return width; }
//        }
//        public int Height
//        {
//            get { return height; }
//        }
//        public static Image spriteSheet;
//        public void Init()
//        {
//            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Forest.png"));
//        }

//        public List<Ground> ground = new List<Ground>();
//        public void generate(int[,] map, int cellsize)
//        {
//            for (int i = 0; i < map.GetLength(1); i++)
//            {
//                for (int j = 0; j < map.GetLength(0); j++)
//                {

//                    //int number = map[j, i];

//                    if (map[i, j] > 0)
//                        ground.Add(new Ground(map[i, j], new Rectangle(i * cellsize, j * cellsize, cellsize, cellsize)));

//                    width = (i + 1) * cellsize;
//                    height = (j + 1) * cellsize;
//                    //rectangles.ToArray();
//                }
//            }

//        }
        
//        public void Draw(Graphics g)
//        {
//            foreach (Ground gr in ground)
//            {
//                //for (int i = 0; i < 9; i++)
//                //    for (int j = 0; j < 9; j++)
//                //    {

//                gr.Draw(g);

//            }
//        }

//    }
//}
