using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    public class Viewport
    {
        public double l = -10;
        public double r = 10;

        public double t = 10;
        public double b = -10;

        public double n = 10;
        public double f = 10;

        public Matrix4 GetOrtOrthographicProjectionMatrix()
        {
            return new Matrix4(
                2/(r-l), 0, 0, 0,
                0, -2/(t-b), 0, 0,
                0, 0, (-2)/(f-n), 0,
                -1 * ((r + l) / (r - l)), -1 * ((t + b) / (t - b)), -1*((f+n)/(f-n)), 1);
        }

        public Matrix4 GetPerspectiveProjectionMatrix()
        {
            return new Matrix4(
                (2 * n)/(r-l), 0, 0, 0,
                0, (2*n)/(b-t), 0, 0,
                0, 0, (-1 * (f+n)) / (f - n), -1,
                0, 0, (-2 * f*n) / (f - n), 0);
        }
    }
}
