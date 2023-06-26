namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-9;
        if (-eps < a && a < eps || new[] { a, b, c }.Any(double.IsNaN) || new[] { a, b, c }.Any(double.IsInfinity))
        {
            throw new ArgumentException();
        }
        b = b / a;
        c = c / a;
        double d = b * b - 4 * c;
        double[] zeroRoots = new double[] { };
        if (d <= -eps) return zeroRoots;
        else if (-eps < d & d < eps)
        { 
            double[] oneRoots = new double[1];
            oneRoots[0] = -(b) / 2;
            return oneRoots;
        }
        else
        {
            double[] twoRoots = new double[2];
            twoRoots[0] = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
            twoRoots[1] = c / twoRoots[0];
            return twoRoots;
        }

    }
}
