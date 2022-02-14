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
    public partial class Matrix2Debugger : Form
    {
        Matrix2 input = new Matrix2(new double[4]);
        Matrix2 opMatrix = new Matrix2(new double[4]);
        Vector2 opVector = new Vector2();
        double scalar;

        Matrix2 outputMatrix = new Matrix2(new double[4]);
        Vector2 outputVector = new Vector2();
        double determinant;
        bool compare;

        public Matrix2Debugger()
        {
            InitializeComponent();
        }

        public void GenerateInput()
        {
            double[] fInput = {
                (double)numericUpDown1.Value, (double)numericUpDown2.Value,
                (double)numericUpDown3.Value, (double)numericUpDown4.Value};
            input = new Matrix2(fInput);

            double[] fOpM = {
                (double)numericUpDown5.Value, (double)numericUpDown6.Value,
                (double)numericUpDown7.Value, (double)numericUpDown8.Value};
            opMatrix = new Matrix2(fOpM);

            opVector = new Vector2((double)numericUpDown13.Value, (double)numericUpDown15.Value);

            scalar = (double)numericUpDown14.Value;
        }

        public void GenerateOutputMatrix()
        {
            numericUpDown16.Value = (decimal)outputMatrix.m[0]; numericUpDown17.Value = (decimal)outputMatrix.m[1];
            numericUpDown18.Value = (decimal)outputMatrix.m[2]; numericUpDown19.Value = (decimal)outputMatrix.m[3];

            MessageBox.Show("Input: \n" + input.ToString());
            MessageBox.Show("Output: \n" + outputMatrix.ToString());
        }

        private void Addition_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.addition(opMatrix);

            GenerateOutputMatrix();
        }

        private void Subtraction_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.subtraction(opMatrix);

            GenerateOutputMatrix();
        }

        private void Multiplication_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Multiplication(opMatrix);

            GenerateOutputMatrix();
        }

        private void MultiplicationVector_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputVector = input.Multiplication(opVector);

            numericUpDown20.Value = (decimal)outputVector.x;
            numericUpDown21.Value = (decimal)outputVector.y;
        }

        private void MultiplicationScalar_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Multiplication(scalar);

            GenerateOutputMatrix();
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            GenerateInput();

            compare = input.isEqualTo(opMatrix);

            label1.Text = compare.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GenerateInput();

            determinant = input.getDeterminant();

            numericUpDown22.Value = (decimal)determinant;
        }

        private void Inverse_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Inverse();

            GenerateOutputMatrix();
        }
    }
}
