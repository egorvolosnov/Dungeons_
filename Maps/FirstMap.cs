using Dungeons_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_.Maps
{
    public static class FirstMap
    {
        public static List<MapEntity> mapObj;
        public static List<MapEntity> mapObjDel;
        public static List<MapEntity> mapEnemy;
        public static void Init()
        {
            mapObj = new List<MapEntity>();
            mapObjDel = new List<MapEntity>();
            mapEnemy = new List<MapEntity>();
        }
        public static void RemoveItem(MapEntity entity)
        {
            mapObjDel.RemoveAll(item => item == entity);
        }
        public static void RemoveEnemy(MapEntity entity)
        {
            mapEnemy.RemoveAll(item => item == entity);
        }
        public static void ClearLists()
        {
            mapObj.Clear();
            mapObjDel.Clear();
            mapEnemy.Clear();
        }
    }
}
