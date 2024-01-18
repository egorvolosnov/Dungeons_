using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_.Entities
{
    public class MapEntity
    {
        public PointF position;
        public Size size;
        public int Layer;
        public MapEntity(PointF pos, Size size, int layer) 
        {
            this.position = pos;
            this.size = size;
            this.Layer = layer;
        }
    }
}
