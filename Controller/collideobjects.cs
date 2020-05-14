using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
   public class collideobjects
    {
        public int posX;
        public int posY;

        public int size;


        public class collide : collideobjects
        {
            public collide(int x, int y)
            {
                posX = x;
                posY = y;
                size = 32;

            }

        }
    }
}
