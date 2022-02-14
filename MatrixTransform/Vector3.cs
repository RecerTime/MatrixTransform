using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatrixTransform
{
    public struct Vector3
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Vector3(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public Vector3 arrayToVector2(double[] input)
        {
            if (input.Length != 3)
            {
                throw new ArgumentException();
            }
            return new Vector3(input[0], input[1], input[2]);
        }

        public override string ToString()
        {
            return $"x:{x}, y:{y}, z:{z}";
        }

        public Vector4 GetVector4()
        {
            return new Vector4(x, y, z, 1);
        }

        public double[] vectorToArray(Vector3 input)
        {
            double[] output = new double[3];

            output[0] = input.x;
            output[1] = input.y;
            output[2] = input.z;

            return output;
        }
    }
}