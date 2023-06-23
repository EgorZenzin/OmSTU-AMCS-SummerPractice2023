amespace SquareEquationLib
{
    public static class SquareEquation
    {
        public static double[] Solve(double a, double b, double c)
        {
            double epsilon = double.Epsilon;
            if (Math.Abs(a) < epsilon)
            {
                throw new ArgumentException("The coefficient 'a' should not be zero.");
            }
            if (double.IsNaN(a) || double.IsInfinity(a) || double.IsNaN(b) || double.IsInfinity(b) || double.IsNaN(c) || double.IsInfinity(c))
            {
                throw new ArgumentException("The coefficients should be finite numbers.");
            }
            b /= a;
            c /= a;
            double discriminant = b * b - 4 * c;
            double[] roots;
            if (discriminant < -epsilon)
            {
                roots = new double[0];
            }
            else if (Math.Abs(discriminant) < epsilon)
            {
                roots = new double[] { -b / 2 };
            }
            else
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double root1 = -(b + Math.Sign(b) * sqrtDiscriminant) / 2;
                double root2 = c / root1;
                roots = new double[] { root1, root2 };
            }
            return roots;
        }
    }
}  
