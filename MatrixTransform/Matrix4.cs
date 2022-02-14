using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    public class Matrix4
    {
        public double[] m = new double[16];

        public Matrix4(double m0, double m1, double m2, double m3, double m4, double m5, double m6, double m7, double m8, double m9, double m10, double m11, double m12, double m13, double m14, double m15)
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
            m[9] = m9;
            m[10] = m10;
            m[11] = m11;

            m[12] = m12;
            m[13] = m13;
            m[14] = m14;
            m[15] = m15;
        }

        public Matrix4(double[] input)
        {
            if (input.Length != m.Length)
            {
                throw new ArgumentException();
            }

            input.CopyTo(m, 0);
        }

        public void setRow(int index, Vector4 input)
        {
            if (index > 4)
            {
                throw new ArgumentException();
            }

            m[index * 4] = input.x;
            m[index * 4 + 1] = input.y;
            m[index * 4 + 2] = input.z;
            m[index * 4 + 3] = input.w;
        }

        public void setColumn(int index, Vector4 input)
        {
            if (index > 4)
            {
                throw new ArgumentException();
            }

            m[index] = input.x;
            m[index + 4] = input.y;
            m[index + 8] = input.z;
            m[index + 12] = input.w;
        }



        public double getDeterminant()
        {
            Matrix3 matrix3A = new Matrix3(m[5], m[6], m[7], m[9], m[10], m[11], m[13], m[14], m[15]);
            Matrix3 matrix3B = new Matrix3(m[4], m[6], m[7], m[8], m[10], m[11], m[12], m[14], m[15]);
            Matrix3 matrix3C = new Matrix3(m[4], m[5], m[7], m[8], m[9], m[11], m[12], m[13], m[15]);
            Matrix3 matrix3D = new Matrix3(m[4], m[5], m[6], m[8], m[9], m[10], m[12], m[13], m[14]);

            return m[0] * matrix3A.getDeterminant() - m[1] * matrix3B.getDeterminant() + m[2] * matrix3C.getDeterminant() - m[3] * matrix3D.getDeterminant();
        }

        public Matrix4 Identety()
        {
            return new Matrix4(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }

        public Matrix4 Transpose()
        {
            return new Matrix4(
                m[0], m[4], m[8], m[12],
                m[1], m[5], m[9], m[13],
                m[2], m[6], m[10], m[14],
                m[3], m[7], m[11], m[15]);
        }

        public Matrix4 CofactorMatrix()
        {
            return new Matrix4(
                m[0], -1 * m[1], m[2], -1 * m[3],
               -1 * m[4], m[5], -1 * m[6], m[7],
                m[8], -1 * m[9], m[10], -1 * m[11],
                -1 * m[12], m[13], -1 * m[14], m[15]);
        }

        public Matrix4 DeterminantrMatrix()
        {
            return new Matrix4(
                new Matrix3(m[5], m[6], m[7], m[9], m[10], m[11], m[13], m[14], m[15]).getDeterminant(), new Matrix3(m[4], m[6], m[7], m[8], m[10], m[11], m[12], m[14], m[15]).getDeterminant(), new Matrix3(m[4], m[5], m[7], m[8], m[9], m[11], m[12], m[13], m[15]).getDeterminant(), new Matrix3(m[4], m[5], m[6], m[8], m[9], m[10], m[12], m[13], m[14]).getDeterminant(),
                new Matrix3(m[1], m[2], m[3], m[9], m[10], m[11], m[13], m[14], m[15]).getDeterminant(), new Matrix3(m[0], m[2], m[3], m[8], m[10], m[11], m[12], m[14], m[15]).getDeterminant(), new Matrix3(m[0], m[1], m[3], m[8], m[9], m[11], m[12], m[13], m[15]).getDeterminant(), new Matrix3(m[0], m[1], m[2], m[8], m[9], m[10], m[12], m[13], m[14]).getDeterminant(),
                new Matrix3(m[1], m[2], m[3], m[5], m[6], m[7], m[13], m[14], m[15]).getDeterminant(), new Matrix3(m[0], m[2], m[3], m[4], m[6], m[7], m[12], m[14], m[15]).getDeterminant(), new Matrix3(m[0], m[1], m[3], m[4], m[5], m[7], m[12], m[13], m[15]).getDeterminant(), new Matrix3(m[0], m[1], m[2], m[4], m[5], m[6], m[12], m[13], m[14]).getDeterminant(),
                new Matrix3(m[1], m[2], m[3], m[5], m[6], m[7], m[9], m[10], m[11]).getDeterminant(), new Matrix3(m[0], m[2], m[3], m[4], m[6], m[7], m[8], m[10], m[11]).getDeterminant(), new Matrix3(m[0], m[1], m[3], m[5], m[5], m[7], m[8], m[10], m[11]).getDeterminant(), new Matrix3(m[0], m[1], m[2], m[4], m[5], m[6], m[8], m[9], m[10]).getDeterminant());
        }

        public Matrix4 Inverse()
        {
            double det = getDeterminant();

            det = (1 / det);

            Matrix4 matrix4 = Transpose();

            matrix4 = matrix4.DeterminantrMatrix();

            matrix4 = matrix4.CofactorMatrix();

            return matrix4.Multiplication(det);
        }



        public Matrix4 addition(Matrix4 op)
        {
            Matrix4 matrix = new Matrix4(new double[16]);

            for (int i = 0; i < m.Length; i++)
            {
                matrix.m[i] = m[i] + op.m[i];
            }
            return matrix;
        }

        public Matrix4 subtraction(Matrix4 op)
        {
            Matrix4 matrix = new Matrix4(new double[16]);

            for (int i = 0; i < m.Length; i++)
            {
                matrix.m[i] = m[i] - op.m[i];
            }
            return matrix;
        }

        public Matrix4 Multiplication(Matrix4 op)
        {
            // does the dimensions dansen
            return new Matrix4(
                m[0] * op.m[0] + m[1] * op.m[4] + m[2] * op.m[8] + m[3] * op.m[12], m[0] * op.m[1] + m[1] * op.m[5] + m[2] * op.m[9] + m[3] * op.m[13], m[0] * op.m[2] + m[1] * op.m[6] + m[2] * op.m[10] + m[3] * op.m[14], m[0] * op.m[3] + m[1] * op.m[7] + m[2] * op.m[11] + m[3] * op.m[15],
                m[4] * op.m[0] + m[5] * op.m[4] + m[7] * op.m[8] + m[8] * op.m[12], m[4] * op.m[1] + m[5] * op.m[5] + m[6] * op.m[9] + m[7] * op.m[13], m[4] * op.m[2] + m[5] * op.m[6] + m[6] * op.m[10] + m[7] * op.m[14], m[4] * op.m[3] + m[5] * op.m[7] + m[6] * op.m[11] + m[7] * op.m[15],
                m[8] * op.m[0] + m[9] * op.m[4] + m[10] * op.m[8] + m[11] * op.m[12], m[8] * op.m[1] + m[9] * op.m[5] + m[10] * op.m[9] + m[11] * op.m[13], m[8] * op.m[2] + m[9] * op.m[6] + m[2] * op.m[10] + m[11] * op.m[14], m[8] * op.m[3] + m[9] * op.m[7] + m[10] * op.m[11] + m[11] * op.m[15],
                m[12] * op.m[0] + m[13] * op.m[4] + m[14] * op.m[8] + m[15] * op.m[12], m[12] * op.m[1] + m[13] * op.m[5] + m[14] * op.m[9] + m[15] * op.m[13], m[12] * op.m[2] + m[13] * op.m[6] + m[14] * op.m[10] + m[15] * op.m[14], m[12] * op.m[3] + m[13] * op.m[7] + m[14] * op.m[11] + m[15] * op.m[15]);
        }

        public Vector4 Multiplication(Vector4 op)
        {
            // does the dimensions dansen
            return new Vector4(m[0] * op.x + m[1] * op.y + m[2] * op.z + m[3] * op.w, m[4] * op.x + m[5] * op.y + m[6] * op.z + m[7] * op.w, m[8] * op.x + m[9] * op.y + m[10] * op.z + m[11] * op.w, m[12] * op.x + m[13] * op.y + m[14] * op.z + m[15] * op.w);
        }

        public Vector4 Multiplication(Vector3 op)
        {
            Vector4 op4 = new Vector4(op.x, op.y, op.z, 1);

            return new Vector4(m[0] * op4.x + m[1] * op4.y + m[2] * op4.z + m[3] * op4.w, m[4] * op4.x + m[5] * op4.y + m[6] * op4.z + m[7] * op4.w, m[8] * op4.x + m[9] * op4.y + m[10] * op4.z + m[11] * op4.w, m[12] * op4.x + m[13] * op4.y + m[14] * op4.z + m[15] * op4.w);
        }

        public Matrix4 Multiplication(double op)
        {
            return new Matrix4(m[0] * op, m[1] * op, m[2] * op, m[3] * op, m[4] * op, m[5] * op, m[6] * op, m[7] * op, m[8] * op, m[9] * op, m[10] * op, m[11] * op, m[12] * op, m[13] * op, m[14] * op, m[15] * op);
        }

        public bool isEqualTo(Matrix4 op)
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
            return $"{m[0]}, {m[1]}, {m[2]}, {m[3]}\n" +
                    $"{m[4]}, {m[5]}, {m[6]}, {m[7]}\n" +
                    $"{m[8]}, {m[9]}, {m[10]}, {m[11]}\n" +
                    $"{m[12]}, {m[13]}, {m[14]}, {m[15]}\n";
        }
    }
}