namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double e = 1e-9;
        if (-e < a && a < e) throw new System.ArgumentException();
        
        if ( new[] { a, b, c }.Any(double.IsNaN) || new[] { a, b, c }.Any(double.IsInfinity)) throw new System.ArgumentException();
        
        b = b / a;
        c = c / a;
        double d = b * b - 4 * c;
        double[] zeroRoots = new double[] { };
        if (d <= -e) return zeroRoots;
        else if (-e < d && d < e)
        {
            double[] Roots1 = new double[1];
            Roots1[0] = -(b) / 2;
            return Roots1;
        }
        else
        {
            double[] Roots2 = new double[2];
            Roots2[0] = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
            Roots2[1] = c / Roots2[0];
            return Roots2;
        }
    }
}
