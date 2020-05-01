using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
  
        public static class PhysicsController
        {
            public static void IsCollide(Entity entity)
            {
                for (int j = (int)entity.posX / MapController.cellSize; j < (entity.posX + MapController.cellSize) / MapController.cellSize; j++)
                {
                    for (int i = (int)entity.posY / MapController.cellSize; i < (entity.posY + MapController.cellSize) / MapController.cellSize; i++)
                    {
                        if (MapController.map[i, j] == 20)
                        {
                            if (entity.dirY > 0)
                            {
                            //entity.posY = 0;
                            entity.posY -= 4;
                        }
                            if (entity.dirY < 0)
                            {
                            //entity.posY = 0;
                            entity.posY += 4;
                        }
                            if (entity.dirX > 0)
                            {
                            //entity.posY = 0;
                            entity.posX -= 4;
                        }
                            if (entity.dirX < 0)
                            {
                            //entity.posY = 0;
                            entity.posX += 4;
                        }
                        }
                    }
                }
            }
        }
    }

