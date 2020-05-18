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

        public static void Collide(Entity entity)
        {
           
            for (int j = (int)entity.posX + 16 / MapController.cellSize; j < (entity.posX + 16 + MapController.cellSize) / MapController.cellSize; j++)
            {
                for (int i = (int)entity.posY + 16 / MapController.cellSize; i < (entity.posY + 16 + MapController.cellSize) / MapController.cellSize; i++)
                {
                    if (MapController.map[i, j] == 0)
                    {
                        
                        entity.posX = entity.OldposX;  
                        entity.posY = entity.OldposY;
                        Level1.delta.X = 0;
                        Level1.delta.Y = 0;
                        Level1.collide = true;
                        entity.dead = true;
                        entity.collidedead = true;
                        entity.howmuchDamaged = 0;

                      
                    }
                    else
                    {
                        entity.isMoving = true;
                        Level1.collide = false;
                        entity.dead = false;
                        entity.collidedead = false;
                    }
                }
            }
        }

    }


}