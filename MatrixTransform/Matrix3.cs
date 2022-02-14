using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    public class Matrix3
    {
        public double[] m = new double[9];

        public Matrix3(double m0, double m1, double m2, double m3, double m4, double m5, double m6, double m7, double m8)
        {
            m[0] = m0;
            m[1] = m1;
            m[2] = m2;

            m[3] = m3;
            m[4] = m4;
            m[5] = m5;

            m[6] = m6;
            m[7] = m7;
            m[8] = m8;
        }

        public Matrix3(double[] input)
        {
            if (input.Length != m.Length)
            {
                throw new ArgumentException();
            }

            input.CopyTo(m, 0);
        }

        public void setRow(int index, Vector3 input)
        {
            if (index > 3)
            {
                throw new ArgumentException();
            }

            m[index * 3] = input.x;
            m[index * 3 + 1] = input.y;
            m[index * 3 + 2] = input.z;
        }

        public void setColumn(int index, Vector3 input)
        {
            if (index > 3)
            {
                throw new ArgumentException();
            }

            m[index] = input.x;
            m[index + 3] = input.y;
            m[index + 3] = input.z;
        }



        public double getDeterminant()
        {
            Matrix2 matrix2A = new Matrix2(m[4], m[5], m[7], m[8]);
            Matrix2 matrix2B = new Matrix2(m[3], m[5], m[6], m[8]);
            Matrix2 matrix2C = new Matrix2(m[3], m[4], m[6], m[7]);

            return m[0] * matrix2A.getDeterminant() - m[1] * matrix2B.getDeterminant() + m[2] * matrix2C.getDeterminant();
        }

        public static Matrix3 Identety()
        {
            return new Matrix3(
                1, 0, 0,
                0, 1, 0,
                0, 0, 1);
        }

        public Matrix3 Transpose()
        {
            return new Matrix3(
                m[0], m[3], m[6],
                m[1], m[4], m[7],
                m[2], m[5], m[8]);
        }

        public Matrix3 CofactorMatrix()
        {
            return new Matrix3(
                m[0], -1 * m[1], m[2],
                -1 * m[3], m[4], -1 * m[5],
                m[6], -1 * m[7], m[8]);
        }

        public Matrix3 DeterminantMatrix()
        {
            return new Matrix3(
                new Matrix2(m[4], m[5], m[7], m[8]).getDeterminant(), new Matrix2(m[3], m[5], m[6], m[8]).getDeterminant(), new Matrix2(m[3], m[4], m[6], m[7]).getDeterminant(),
                new Matrix2(m[1], m[2], m[7], m[8]).getDeterminant(), new Matrix2(m[0], m[2], m[6], m[8]).getDeterminant(), new Matrix2(m[0], m[1], m[6], m[7]).getDeterminant(),
                new Matrix2(m[1], m[2], m[4], m[5]).getDeterminant(), new Matrix2(m[0], m[2], m[3], m[5]).getDeterminant(), new Matrix2(m[0], m[1], m[3], m[4]).getDeterminant());
        }

        public Matrix3 Inverse()
        {
            double det = getDeterminant();

            det = (1 / det);

            Matrix3 matrix3 = Transpose();

            matrix3 = matrix3.DeterminantMatrix();

            matrix3 = matrix3.CofactorMatrix();

            return matrix3.Multiplication(det);
        }


        public Matrix3 addition(Matrix3 op)
        {
            Matrix3 matrix = new Matrix3(new double[9]);

            for (int i = 0; i < m.Length; i++)
            {
                matrix.m[i] = m[i] + op.m[i];
            }
            return matrix;
        }

        public Matrix3 subtraction(Matrix3 op)
        {
            Matrix3 matrix = new Matrix3(new double[9]);

            for (int i = 0; i < m.Length; i++)
            {
                matrix.m[i] = m[i] - op.m[i];
            }
            return matrix;
        }
        public Matrix3 Multiplication(Matrix3 op)
        {
            // does the dimensions dansen
            return new Matrix3(
                m[0] * op.m[0] + m[1] * op.m[3] + m[2] * op.m[6], m[0] * op.m[1] + m[1] * op.m[4] + m[2] * op.m[7], m[0] * op.m[2] + m[1] * op.m[5] + m[2] * op.m[8],
                m[3] * op.m[0] + m[4] * op.m[3] + m[5] * op.m[6], m[3] * op.m[1] + m[4] * op.m[4] + m[5] * op.m[7], m[3] * op.m[2] + m[4] * op.m[5] + m[5] * op.m[8],
                m[6] * op.m[0] + m[7] * op.m[3] + m[8] * op.m[6], m[6] * op.m[1] + m[6] * op.m[4] + m[7] * op.m[7], m[6] * op.m[2] + m[7] * op.m[5] + m[8] * op.m[8]);
        }

        public Vector3 Multiplication(Vector3 op)
        {
            // does the dimensions dansen
            return new Vector3(m[0] * op.x + m[1] * op.y + m[2] * op.z, m[3] * op.x + m[4] * op.y + m[5] * op.z, m[6] * op.x + m[7] * op.y + m[8] * op.z);
        }

        public Matrix3 Multiplication(double op)
        {
            return new Matrix3(m[0] * op, m[1] * op, m[2] * op, m[3] * op, m[4] * op, m[5] * op, m[6] * op, m[7] * op, m[8] * op);
        }

        public bool isEqualTo(Matrix3 op)
        {
            bool equal = true;

            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] != op.m[i])
                {
                    equal = false;
                }
            }
            return equal;
        }

        public override string ToString()
        {
            return $"{m[0]}, {m[1]}, {m[2]}\n" +
                    $"{m[3]}, {m[4]}, {m[5]}\n" +
                    $"{m[6]}, {m[7]}, {m[8]}";
        }
    }
}