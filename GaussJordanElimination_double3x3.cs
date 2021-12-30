using FrooxEngine;
using FrooxEngine.LogiX;
using BaseX;
using Mehroz;

namespace MatrixMod
{
    [HiddenNode] // Hide overload from node browser
    [NodeName("Reduced Echelon Form")]
    [NodeOverload("ReducedEchelonForm")]
    [Category(new string[] { "LogiX/Math/Matrix" })]

    public sealed class GaussJordanElimination_double3x3 : LogixOperator<double3> //T is the node output type
    {
        public readonly Input<double3x3> LinearEquationMatrix;
        public readonly Input<double3> LinearSolutionMatrix;

        public override double3 Content //T is the node output type
        {
            get // Code goes here!
            {
                Matrix m1 = new Matrix(LinearEquationMatrix.EvaluateRaw().To2DArray());
                Matrix m2 = new Matrix(3, 1);
                m2[0, 0] = new Fraction(LinearSolutionMatrix.EvaluateRaw().x);
                m2[1, 0] = new Fraction(LinearSolutionMatrix.EvaluateRaw().y);
                m2[2, 0] = new Fraction(LinearSolutionMatrix.EvaluateRaw().z);
                Matrix m3 = Matrix.Concatenate(m1, m2);
                m3 = m3.ReducedEchelonForm();
                return new double3(m3[0, 2].ToDouble(), m3[1, 2].ToDouble(), m3[2, 2].ToDouble());
            }
        }
    }
}