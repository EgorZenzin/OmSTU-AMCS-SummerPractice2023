namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-9;
         if (-eps < a && a < eps) throw new System.ArgumentException();
        
        if ( double.IsNaN(a)  double.IsInfinity(a)  double.IsNaN(b)  double.IsInfinity(b)  double.IsNaN(c) || double.IsInfinity(c)) throw new System.ArgumentException();
        
        b = b / a;
        c = c / a;
        double d = b * b - 4 * c;
        double[] zeroRoots = new double[] { };
        if (d <= -eps) return zeroRoots;
        else if (-eps < d && d < eps)
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
