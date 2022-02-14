using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    public class Vertex
    {
        public Vector3 pos { get; set; }

        public Vertex(Vector3 position)
        {
            pos = position;
        }

        public Vertex(double x, double y, double z)
        {
            pos = new Vector3(x, y, z);
        }
    }

    public class Edge
    {
        public Vertex[] corners { get; set; }

        public Edge(Vector3 position1, Vector3 position2)
        {
            corners = new Vertex[] { new Vertex(position1), new Vertex(position2) };
        }

        public Edge(Vertex vertex1, Vertex vertex2)
        {
            corners = new Vertex[] { vertex1, vertex2 };
        }

        public Edge(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            corners = new Vertex[] { new Vertex(x1, y1, z1), new Vertex(x2, y2, z2) };
        }
    }
}
