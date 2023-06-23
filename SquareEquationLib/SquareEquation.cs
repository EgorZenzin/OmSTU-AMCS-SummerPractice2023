namespace SquareEquationLib;
public static class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        const double epsilon = 1e-9;
        if (Math.Abs(a) < epsilon)
        {
            throw new ArgumentException("Coefficient 'a' should not be zero.");
        }
        if (!double.IsFinite(a) || !double.IsFinite(b) || !double.IsFinite(c))
        {
            throw new ArgumentException("Coefficients should be finite numbers.");
        }
        b /= a;
        c /= a;
        double discriminant = b * b - 4 * c;
        if (Math.Abs(discriminant) < epsilon)
        {
            return new double[] { -b / 2 };
        }
        else if (discriminant < -epsilon)
        {
            return new double[0];
        }
        else
        {
            double sqrtDiscriminant = Math.Sqrt(discriminant);
            double root1 = (-b + Math.Sign(b) * sqrtDiscriminant) / 2;
            double root2 = c / root1;
            return new double[] { root1, root2 };
        }
    }
}
