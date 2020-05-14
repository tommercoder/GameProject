using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project.Controller
{

    public class PhysicsController
    {
        public static int timer;
        public static void Collide(Entity entity)
        {
           
            for (int j = (int)entity.posX / MapController.cellSize; j < (entity.posX + MapController.cellSize) / MapController.cellSize; j++)
            {
                for (int i = (int)entity.posY / MapController.cellSize; i < (entity.posY + MapController.cellSize) / MapController.cellSize; i++)
                {
                    if (MapController.map[i, j] == 0)
                    {
                        
                        //entity.posX = entity.OldposX- 40;  
                        //entity.posY = entity.OldposY;  
                        Level1.collide = true;
                        entity.dead = true;
                        
                    }
                    else
                    {
                        entity.isMoving = true;
                        Level1.collide = false;
                        entity.dead = false;
                    }
                }
            }
        }

    }


}