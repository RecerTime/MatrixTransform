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
    public partial class Matrix4Debugger : Form
    {
        Matrix4 input = new Matrix4(new double[16]);
        Matrix4 opMatrix = new Matrix4(new double[16]);
        Vector4 opVector = new Vector4();
        double scalar;

        Matrix4 outputMatrix = new Matrix4(new double[16]);
        Vector4 outputVector = new Vector4();
        double determinant;
        bool compare;

        public Matrix4Debugger()
        {
            InitializeComponent();
        }
        public void GenerateInput()
        {
            double[] fInput = {
                (double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value, (double)numericUpDown44.Value,
                (double)numericUpDown9.Value, (double)numericUpDown8.Value, (double)numericUpDown7.Value, (double)numericUpDown42.Value,
                (double)numericUpDown6.Value, (double)numericUpDown5.Value, (double)numericUpDown4.Value, (double)numericUpDown43.Value,
                (double)numericUpDown37.Value, (double)numericUpDown36.Value, (double)numericUpDown35.Value, (double)numericUpDown41.Value,};
            input = new Matrix4(fInput);

            double[] fOpM = {
                (double)numericUpDown48.Value, (double)numericUpDown18.Value, (double)numericUpDown17.Value, (double)numericUpDown16.Value,
                (double)numericUpDown46.Value, (double)numericUpDown12.Value, (double)numericUpDown11.Value, (double)numericUpDown10.Value,
                (double)numericUpDown47.Value, (double)numericUpDown15.Value, (double)numericUpDown14.Value, (double)numericUpDown13.Value,
                (double)numericUpDown45.Value, (double)numericUpDown40.Value, (double)numericUpDown39.Value, (double)numericUpDown38.Value};
            opMatrix = new Matrix4(fOpM);

            opVector = new Vector4((double)numericUpDown56.Value, (double)numericUpDown55.Value, (double)numericUpDown54.Value, (double)numericUpDown53.Value);

            scalar = (double)numericUpDown58.Value;
        }

        public void GenerateOutputMatrix()
        {
            numericUpDown30.Value = (decimal)outputMatrix.m[0]; numericUpDown29.Value = (decimal)outputMatrix.m[1]; numericUpDown28.Value = (decimal)outputMatrix.m[2]; numericUpDown31.Value = (decimal)outputMatrix.m[3];
            numericUpDown27.Value = (decimal)outputMatrix.m[4]; numericUpDown26.Value = (decimal)outputMatrix.m[5]; numericUpDown25.Value = (decimal)outputMatrix.m[6]; numericUpDown34.Value = (decimal)outputMatrix.m[7];
            numericUpDown21.Value = (decimal)outputMatrix.m[8]; numericUpDown20.Value = (decimal)outputMatrix.m[9]; numericUpDown19.Value = (decimal)outputMatrix.m[10]; numericUpDown32.Value = (decimal)outputMatrix.m[11];
            numericUpDown24.Value = (decimal)outputMatrix.m[12]; numericUpDown23.Value = (decimal)outputMatrix.m[13]; numericUpDown22.Value = (decimal)outputMatrix.m[14]; numericUpDown33.Value = (decimal)outputMatrix.m[15];

            MessageBox.Show("Input: \n" + input.ToString());
            MessageBox.Show("Output: \n" + outputMatrix.ToString());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown44_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown42_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.addition(opMatrix);

            GenerateOutputMatrix();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.subtraction(opMatrix);

            GenerateOutputMatrix();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Multiplication(opMatrix);

            GenerateOutputMatrix();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputVector = input.Multiplication(opVector);

            numericUpDown52.Value = (decimal)outputVector.x;
            numericUpDown51.Value = (decimal)outputVector.y;
            numericUpDown50.Value = (decimal)outputVector.z;
            numericUpDown49.Value = (decimal)outputVector.w;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Multiplication(scalar);

            GenerateOutputMatrix();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerateInput();

            compare = input.isEqualTo(opMatrix);

            label1.Text = compare.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GenerateInput();

            determinant = input.getDeterminant();

            numericUpDown57.Value = (decimal)determinant;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GenerateInput();

            outputMatrix = input.Inverse();

            GenerateOutputMatrix();
        }
    }
}
