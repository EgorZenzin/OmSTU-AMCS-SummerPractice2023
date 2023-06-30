namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-6;
        if (-eps < a & a < eps || new[] { a, b, c }.Any(double.IsNaN) || new[] { a, b, c }.Any(double.IsInfinity))
        {
            throw new System.ArgumentException("Invalid Values");
        }
        b = b / a;
        c = c / a;
        double d = b * b - 4 * c;
        double[] zeroRoots = new double[] { };
        double[] oneRoots = new double[1];
        double[] twoRoots = new double[2];
        if (d <= -eps) return zeroRoots;
        else if (-eps < d & d < eps)
        {         
            oneRoots[0] = -(b) / 2;
            return oneRoots;
        }
            
        else if (b < eps)
        {
            double x1 = -((b + Math.Sqrt(d)) / 2);
            double x2 = c / x1;
            twoRoots[0] = x1;
            twoRoots[1] = x2;
            return twoRoots;
        }
        else
        {
            double x1 = -((b + Math.Sign(b) * Math.Sqrt(d)) / 2);
            double x2 = c / x1;
            twoRoots[0] = x1;
            twoRoots[1] = x2;
            return twoRoots;
        }

    }
}
