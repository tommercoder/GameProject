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
           
            for (int j = (int)entity.posX  / MapController.cellSize; j < (entity.posX + MapController.cellSize) / MapController.cellSize; j++)
            {
                for (int i = (int)entity.posY / MapController.cellSize; i < (entity.posY   + MapController.cellSize) / MapController.cellSize; i++)
                {
                    if (MapController.map[i, j] == 0)
                    {
                        game.collide = true;
                        
                        entity.collidedead = true;
                        entity.howmuchDamaged = 0; 
                    }
                    else
                    {
                        entity.isMoving = true;
                        game.collide = false;
                        
                        entity.collidedead = false;
                    }
                }
            }
        }



    }


}