using Dungeons_.Cameras;
using Dungeons_.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_.Maps
{
    public class Graph
    {
        public List<Node> nodes;

        public Graph()
        {
            nodes = new List<Node>();
        }

        public void DrawGraph(Graphics g, Camera camera)
        {
            foreach (var node in nodes)
            {
                int screenX = node.Position.X + camera.X;
                int screenY = node.Position.Y + camera.Y;
                if (node.enter)
                    node.DrawMap(g, camera, screenX, screenY);
            }
        }
    }
}
