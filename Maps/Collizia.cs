using Dungeons_.Entities;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace Dungeons_.Maps
{
    public static class Collizia
    {
        public static void IsColide(IEntity entity, Point dir, int distance, List<MapEntity> mapObj)
        {
            for (int i = 0; i < mapObj.Count; i++)
            {
                var currObj = mapObj[i];
                PointF delta = new PointF();
                delta.X = (entity.PosX + entity.SizeX / 2) - (currObj.position.X + currObj.size.Width / 2 + distance);
                delta.Y = (entity.PosY + entity.SizeY / 2) - (currObj.position.Y + currObj.size.Height / 2 - distance);
                bool Condition = Math.Abs(delta.X) <= entity.SizeX / 2 + currObj.size.Width / 2 - 2 * distance && Math.Abs(delta.Y) <= entity.SizeY / 2 + currObj.size.Height / 2;
                if (currObj.Layer == 0)
                {  
                    if (Condition)
                    {
                        if (delta.X <= 0 && dir.X > 0 && currObj.position.Y > entity.PosY && currObj.position.Y + currObj.size.Height < entity.PosY + entity.SizeY)
                            entity.DirX = 0;
                        else if (delta.X > 0 && dir.X < 0 && currObj.position.Y > entity.PosY && currObj.position.Y + currObj.size.Height < entity.PosY + entity.SizeY)
                            entity.DirX = 0;
                        else if (delta.Y < 0 && dir.Y > 0 && currObj.position.X > entity.PosX && currObj.position.X + currObj.size.Width < entity.PosX + entity.SizeX)
                            entity.DirY = 0;
                        else if (delta.Y > 0 && dir.Y < 0 && currObj.position.X > entity.PosX && currObj.position.X + currObj.size.Width < entity.PosX + entity.SizeX)
                            entity.DirY = 0;
                    }
                }
                else 
                {
                    if (currObj.size.Width == 57 || currObj.size.Width == 64)
                    {
                        delta.X += distance;
                        delta.Y -= 2 * distance;
                        Condition = Math.Abs(delta.X) <= entity.SizeX / 2 + currObj.size.Width / 2 - 2 * distance && Math.Abs(delta.Y) <= entity.SizeY / 2 + currObj.size.Height / 2 - 2 * distance;
                    }
                    else
                    {
                        delta.X = (entity.PosX + entity.SizeX / 2) - (currObj.position.X + currObj.size.Width / 2 + distance);
                        delta.Y = (entity.PosY + entity.SizeY / 2) - (currObj.position.Y + currObj.size.Height / 2 - distance);
                        Condition = Math.Abs(delta.X) <= entity.SizeX / 2 + currObj.size.Width / 2 - 2 * distance && Math.Abs(delta.Y) <= entity.SizeY / 2 + currObj.size.Height / 2;
                    }
                    if (Condition)
                    {
                        float overlapX = entity.SizeX / 2 + currObj.size.Width / 2 - Math.Abs(delta.X);
                        float overlapY = entity.SizeY / 2 + currObj.size.Height / 2 - Math.Abs(delta.Y);

                        if (overlapX < overlapY)
                        {
                            if (delta.X <= 0 && dir.X > 0)
                                entity.DirX = 0;
                            else if (delta.X > 0 && dir.X < 0)
                                entity.DirX = 0;
                        }
                        else
                        {
                            if (delta.Y < 0 && dir.Y > 0)
                                entity.DirY = 0;
                            else if (delta.Y > 0 && dir.Y < 0)
                                entity.DirY = 0;
                        }
                    }
                }
              
            }
        }

    }
}
