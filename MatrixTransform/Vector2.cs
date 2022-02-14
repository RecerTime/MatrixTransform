using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    public struct Vector2
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vector2(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public Vector2 arrayToVector2(double[] input)
        {
            if (input.Length != 2)
            {
                throw new ArgumentException();
            }
            return new Vector2(input[0], input[1]);
        }

        public double[] vectorToArray(Vector2 input)
        {
            double[] output = new double[2];

            output[0] = input.x;
            output[1] = input.y;

            return output;
        }
    }
}