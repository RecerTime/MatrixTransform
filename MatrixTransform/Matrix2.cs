using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    public class Matrix2
    {
        public double[] m = new double[4];

        public Matrix2(double m0, double m1, double m2, double m3)
        {
            m[0] = m0;
            m[1] = m1;

            m[2] = m2;
            m[3] = m3;
        }

        public Matrix2(double[] input)
        {
            if (input.Length != m.Length)
            {
                throw new ArgumentException();
            }

            input.CopyTo(m, 0);
        }

        public void setRow(int index, Vector2 input)
        {
            if (index > 2)
            {
                throw new ArgumentException();
            }

            m[index * 2] = input.x;
            m[index * 2 + 1] = input.y;
        }

        public void setColumn(int index, Vector2 input)
        {
            if (index > 2)
            {
                throw new ArgumentException();
            }

            m[index] = input.x;
            m[index + 2] = input.y;
        }



        public double getDeterminant()
        {
            return (m[0] * m[3]) - (m[1] * m[2]);
        }

        public Matrix2 Identety()
        {
            return new Matrix2(
                1, 0,
                0, 1);
        }

        public Matrix2 Transpose()
        {
            return new Matrix2(m[0], m[2], m[1], m[3]);
        }

        public Matrix2 Inverse()
        {
            return new Matrix2(m[3], -m[1], -m[2], m[0]).Multiplication(1 / getDeterminant());
        }



        public Matrix2 addition(Matrix2 op)
        {
            return new Matrix2(
                m[0] + op.m[0], m[1] + op.m[1],
                m[2] + op.m[2], m[3] + op.m[3]);
        }

        public Matrix2 subtraction(Matrix2 op)
        {
            return new Matrix2(m[0] - op.m[0], m[1] - op.m[1], m[2] - op.m[2], m[3] - op.m[3]);
        }

        public Matrix2 Multiplication(Matrix2 op)
        {
            // does the dimensions dansen
            return new Matrix2(
                m[0] * op.m[0] + m[2] * op.m[1], m[1] * op.m[0] + m[3] * op.m[1],
                m[0] * op.m[2] + m[2] * op.m[3], m[1] * op.m[2] + m[3] * op.m[2]);
        }

        public Vector2 Multiplication(Vector2 op)
        {
            // does the dimensions dansen
            return new Vector2(m[0] * op.x + m[2] * op.y, m[1] * op.x + m[3] * op.y);
        }

        public Matrix2 Multiplication(double op)
        {
            return new Matrix2(m[0] * op, m[1] * op, m[2] * op, m[3] * op);
        }

        public bool isEqualTo(Matrix2 op)
        {
            return (m[0] == op.m[0] && m[1] == op.m[1] && m[2] == op.m[2] && m[3] == op.m[3]);
        }

        public override string ToString()
        {
            return $"{m[0]}, {m[1]}\n" +
                    $"{m[2]}, {m[3]}";
        }
    }
}