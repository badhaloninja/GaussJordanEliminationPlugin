using FrooxEngine;
using FrooxEngine.LogiX;
using BaseX;
using Mehroz;

namespace MatrixMod
{
    [NodeName("Reduced Echelon Form")]
    [NodeOverload("ReducedEchelonForm")]
    [Category(new string[] { "LogiX/Math/Matrix" })]

    public sealed class GaussJordanElimination : LogixOperator<double2> //T is the node output type
    {
        public readonly Input<double2x2> LinearEquationMatrix;
        public readonly Input<double2> LinearSolutionMatrix;

        public override double2 Content //T is the node output type
        {
            get // Code goes here!
            {
                Matrix m1 = new Matrix(LinearEquationMatrix.EvaluateRaw().To2DArray());
                Matrix m2 = new Matrix(2, 1);
                m2[0, 0] = new Fraction(LinearSolutionMatrix.EvaluateRaw().x);
                m2[1, 0] = new Fraction(LinearSolutionMatrix.EvaluateRaw().y);
                Matrix m3 = Matrix.Concatenate(m1, m2);
                m3 = m3.ReducedEchelonForm();
                return new double2(m3[0, 2].ToDouble(), m3[1, 2].ToDouble());
            }
        }
    }
}