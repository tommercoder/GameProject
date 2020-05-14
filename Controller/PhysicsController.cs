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



                //for (int i = 0; i < MapController.collideList.Count; i++)
                //{
                //    //deltaX = ((int)player.posX + (int)player.size / 2) - (MapController.collideList[i].posX + (MapController.collideList[i].size - 10) / 2);
                //    //deltaY = ((int)player.posY + (int)player.size / 2) - (MapController.collideList[i].posY + (MapController.collideList[i].size - 16) / 2);

                //    if (Math.Abs(deltaX) <= player.size / 2 + (MapController.collideList[i].size - 10) / 2)
                //    {
                //        if (Math.Abs(deltaY) <= player.size / 2 + (MapController.collideList[i].size - 16) / 2)
                //        {

                //            return true;

                //        }
                //    }
                //}
                //return false;





            }

    }


}