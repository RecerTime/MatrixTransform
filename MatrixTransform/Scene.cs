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
    public partial class Scene : Form
    {
        Pen pointPen = new Pen(Color.Red);
        Pen edgePen = new Pen(Color.Blue);
        Size pointSize = new Size(1, 1);

        Bitmap bitmap;
        Graphics g;

        Obj obj = new Obj();

        bool Perspective = true;
        Matrix4 projectionMatrix;
        Viewport viewport = new Viewport();

        Matrix4 worldToCamera = new Matrix4(0.95424, 0.20371, -0.218924, 0, 0, 0.732087, 0.681211, 0, 0.299041, -0.650039, 0.698587, 0, -0.553677, -3.920548, -62.68137, 1);

        public Scene()
        {
            InitializeComponent();

            Setup();
            DrawObj(obj);

            panel1.Invalidate();
        }

        private void Setup()
        {
            bitmap = new Bitmap(panel1.Width, panel1.Height);
            g = Graphics.FromImage(bitmap);

            obj.GenerateCube(/*new Vector3(panel1.Width/2, panel1.Height/2, -10), panel1.Width/8*/);

            viewport.r = panel1.Width; viewport.l = -panel1.Width;
            viewport.t = panel1.Height; viewport.b = -panel1.Height;

            if (Perspective)
            {
                projectionMatrix = viewport.GetPerspectiveProjectionMatrix();
            }
            else
            {
                projectionMatrix = viewport.GetOrtOrthographicProjectionMatrix();
            }
        }

        public void DrawObj(Obj objDraw)
        {
            Vertex[] vertices = objDraw.vertices.ToArray();

            List<Vertex> vertexToEdge = new List<Vertex>();

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 vertCamera = new Vector3();
                Vector3 projectedVert = new Vector3();

                vertCamera = ProjectionCalculation(vertices[i].pos, worldToCamera);
                projectedVert = ProjectionCalculation(vertCamera, projectionMatrix);

                vertexToEdge.Add(new Vertex(projectedVert));

                Point point = new Point();

                point.X = (int)(projectedVert.x * panel1.Width) + panel1.Width/2;
                point.Y = (int)(projectedVert.y * panel1.Height) + panel1.Height/2;

                g.DrawEllipse(pointPen, new Rectangle(point, pointSize));
            }
            /*Edge[] edges = Obj.GenerateEdges(vertexToEdge.ToArray());

            for (int i = 0; i < edges.Length; i++)
            {
                g.DrawLine(edgePen, new Point((int)(edges[i].corners[0].pos.x * panel1.Width), (int)(edges[i].corners[0].pos.y * panel1.Height)), new Point((int)(edges[i].corners[1].pos.x * panel1.Width), (int)(edges[i].corners[1].pos.y * panel1.Height)));
            }*/
        }

        private Vector3 ProjectionCalculation(Vector3 input, Matrix4 matrix)
        {
            Vector4 vector4 = matrix.Multiplication(input);
            vector4.Normalize();

            return new Vector3(vector4.x, vector4.y, vector4.z);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackgroundImage = bitmap;
        }

        private void Scene_Load(object sender, EventArgs e)
        {

        }

        private void xTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void yTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void zTrackBar_Scroll(object sender, EventArgs e)
        {

        }


    }
}