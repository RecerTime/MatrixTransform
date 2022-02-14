using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixTransform
{
    public partial class Scene2 : Form
    {
        int numVertices = 8;
        Obj obj = new Obj();
        Vector3[] vertices;
        Pen pen = new Pen(Color.Red);
        Bitmap bitmap;
        Graphics g;
        Size size = new Size(2, 2);
        public Scene2()
        {
            InitializeComponent();
            obj.GenerateCube(new Vector3(), 0);
            vertices = obj.vertices.ToArray();
            bitmap = new Bitmap(512, 512);
            g = Graphics.FromImage(bitmap);

            Main();
        }

        void glOrtho(
            double b, double t, double l, double r,
            double n, double f,
            double[,] M)
        {
            // set OpenGL perspective projection matrix
            M[0, 0] = 2 / (r - l);
            M[0, 1] = 0;
            M[0, 2] = 0;
            M[0, 3] = 0;

            M[1, 0] = 0;
            M[1, 1] = 2 / (t - b);
            M[1, 2] = 0;
            M[1, 3] = 0;

            M[2, 0] = 0;
            M[2, 1] = 0;
            M[2, 2] = -2 / (f - n);
            M[2, 3] = 0;

            M[3, 0] = -(r + l) / (r - l);
            M[3, 1] = -(t + b) / (t - b);
            M[3, 2] = -(f + n) / (f - n);
            M[3, 3] = 1;
        }

        void multPointMatrix(Vector3 input, Vector3 output, double[,] M)
        {
            //out = in * Mproj;
            output.x = input.x * M[0, 0] + input.y * M[1, 0] + input.z * M[2, 0] + /* input.z = 1 */ M[3, 0];
            output.y = input.x * M[0, 1] + input.y * M[1, 1] + input.z * M[2, 1] + /* input.z = 1 */ M[3, 1];
            output.z = input.x * M[0, 2] + input.y * M[1, 2] + input.z * M[2, 2] + /* input.z = 1 */ M[3, 2];
            double w = input.x * M[0, 3] + input.y * M[1, 3] + input.z * M[2, 3] + /* input.z = 1 */ M[3, 3];

            // normalize if w is different than 1 (convert from homogeneous to Cartesian coordinputates)
            if (w != 1)
            {
                output.x /= w;
                output.y /= w;
                output.z /= w;
            }
        }

        void Main()
        {
            int imageWidth = 512;
            int imageHeight = 512;

            double[,] Mproj = new double[4, 4];
            double[,] worldToCamera = { { 0.95424, 0.20371, -0.218924, 0 }, { 0, 0.732087, 0.681211, 0 }, { 0.299041, -0.650039, 0.698587, 0 }, { -0.553677, -3.920548, -62.68137, 1 } };

            double near = 0.1;
            double far = 100;
            double imageAspectRatio = (double)imageWidth / (double)imageHeight;

            Vector3 minWorld = new Vector3(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);
            Vector3 maxWorld = new Vector3(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);

            for (int i = 0; i < numVertices; ++i)
            {
                if (vertices[i].x < minWorld.x) minWorld.x = vertices[i].x;
                if (vertices[i].y < minWorld.y) minWorld.y = vertices[i].y;
                if (vertices[i].z < minWorld.z) minWorld.z = vertices[i].z;
                if (vertices[i].x > maxWorld.x) maxWorld.x = vertices[i].x;
                if (vertices[i].y > maxWorld.y) maxWorld.y = vertices[i].y;
                if (vertices[i].z > maxWorld.z) maxWorld.z = vertices[i].z;
            }

            Vector3 minCamera = new Vector3();
            Vector3 maxCamera = new Vector3();
            multPointMatrix(minWorld, minCamera, worldToCamera);
            multPointMatrix(maxWorld, maxCamera, worldToCamera);

            double maxx = Math.Max(Math.Abs(minCamera.x), Math.Abs(maxCamera.x));
            double maxy = Math.Max(Math.Abs(minCamera.y), Math.Abs(maxCamera.y));
            double max = Math.Max(maxx, maxy);
            double r = max * imageAspectRatio;
            double t = max;
            double l = -r;
            double b = -t;

            glOrtho(b, t, l, r, near, far, Mproj);

            for (int i = 0; i < numVertices; ++i)
            {
                Vector3 vertCamera = new Vector3();
                Vector3 projectedVert = new Vector3();
                multPointMatrix(vertices[i], vertCamera, worldToCamera);
                multPointMatrix(vertCamera, projectedVert, Mproj);
                //if (projectedVert.x < -imageAspectRatio || projectedVert.x > imageAspectRatio || projectedVert.y < -1 || projectedVert.y > 1) continue;
                // convert to raster space and mark the position of the vertex in the image with a simple dot
                int x = Math.Max(imageWidth - 1, (int)((projectedVert.x + 1) * 0.5 * imageWidth));
                int y = Math.Max(imageHeight - 1, (int)((1 - (projectedVert.y + 1) * 0.5) * imageHeight));

                Point point = new Point(x, y);

                MessageBox.Show(point.ToString());

                g.DrawEllipse(pen, new Rectangle(point, size));
            }
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackgroundImage = bitmap;
        }
    }
}