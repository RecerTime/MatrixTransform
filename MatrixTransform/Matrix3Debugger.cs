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
    public partial class Matrix3Debugger : Form
    {
        Matrix3 input = new Matrix3(new double[9]);
        Matrix3 opMatrix = new Matrix3(new double[9]);
        Vector3 opVector = new Vector3();
        double scalar;

        Matrix3 outputMatrix = new Matrix3(new double[9]);
        Vector3 outputVector = new Vector3();
        double determinant;
        bool compare;

        public Matrix3Debugger()
        {
            InitializeComponent();
        }

        public void GenerateInput()
        {
            double[] fInput = {
                (double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value,
                (double)numericUpDown4.Value, (double)numericUpDown5.Value, (double)numericUpDown6.Value,
                (double)numericUpDown7.Value, (double)numericUpDown8.Value, (double)numericUpDown9.Value};
            input = new Matrix3(fInput);

            double[] fOpM = {
                (double)numericUpDown10.Value, (double)numericUpDown11.Value, (double)numericUpDown12.Value,
                (double)numericUpDown13.Value, (double)numericUpDown14.Value, (double)numericUpDown15.Value,
                (double)numericUpDown16.Value, (double)numericUpDown17.Value, (double)numericUpDown18.Value};
            opMatrix = new Matrix3(fOpM);

            opVector = new Vector3((double)numericUpDown33.Value, (double)numericUpDown34.Value, (double)numericUpDown35.Value);

            scalar = (double)numericUpDown32.Value;
        }

        public void GenerateOutputMatrix()
        {
            numericUpDown19.Value = (decimal)outputMatrix.m[0]; numericUpDown20.Value = (decimal)outputMatrix.m[1]; numericUpDown21.Value = (decimal)outputMatrix.m[2];
            numericUpDown22.Value = (decimal)outputMatrix.m[3]; numericUpDown23.Value = (decimal)outputMatrix.m[4]; numericUpDown24.Value = (decimal)outputMatrix.m[5];
            numericUpDown25.Value = (decimal)outputMatrix.m[6]; numericUpDown26.Value = (decimal)outputMatrix.m[7]; numericUpDown27.Value = (decimal)outputMatrix.m[8];

            MessageBox.Show("Input: \n" + input.ToString());
            MessageBox.Show("Output: \n" + outputMatrix.ToString());
        }

        private void AdditionButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.addition(opMatrix);

            GenerateOutputMatrix();
        }

        private void SubtractionButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.subtraction(opMatrix);

            GenerateOutputMatrix();
        }

        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Multiplication(opMatrix);

            GenerateOutputMatrix();
        }

        private void MultiplicationVectorButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputVector = input.Multiplication(opVector);

            numericUpDown28.Value = (decimal)outputVector.x;
            numericUpDown29.Value = (decimal)outputVector.y;
            numericUpDown30.Value = (decimal)outputVector.z;

            MessageBox.Show("Output: \n(" + outputVector.x + ", " + outputVector.y + ", " + outputVector.z + ")");
        }

        private void MultiplicationScalarButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Multiplication(scalar);

            GenerateOutputMatrix();
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            compare = input.isEqualTo(opMatrix);

            label1.Text = compare.ToString();

            MessageBox.Show("Output: \n" + compare.ToString());
        }

        private void DeterminantButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            determinant = input.getDeterminant();

            numericUpDown31.Value = (decimal)determinant;
            MessageBox.Show("Output: \n" + determinant.ToString());
        }

        private void InverseButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Inverse();

            GenerateOutputMatrix();
        }

        private void TransposeButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Transpose();

            GenerateOutputMatrix();
        }

        private void MatrixDetButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.DeterminantMatrix();

            GenerateOutputMatrix();
        }

        private void CofactorMatrixButton_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.CofactorMatrix();

            GenerateOutputMatrix();
        }
    }
}
