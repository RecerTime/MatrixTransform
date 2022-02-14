using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    public struct Vector4
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double w { get; set; }

        public Vector4(double X, double Y, double Z, double W)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }

        public Vector4 arrayToVector2(double[] input)
        {
            if (input.Length != 4)
            {
                throw new ArgumentException();
            }
            return new Vector4(input[0], input[1], input[2], input[3]);
        }

        public double[] vectorToArray(Vector4 input)
        {
            double[] output = new double[4];

            output[0] = input.x;
            output[1] = input.y;
            output[2] = input.z;
            output[3] = input.w;

            return output;
        }

        public Vector4 Normalize()
        {
            if (w != 1)
            {
                return new Vector4(x/w, y/w, z/w, w);
            }

            return new Vector4(x, y, z, w);
        }

        public override string ToString()
        {
            return $"x:{x}, y:{y}\nz:{z}, w{w}";
        }
    }
}