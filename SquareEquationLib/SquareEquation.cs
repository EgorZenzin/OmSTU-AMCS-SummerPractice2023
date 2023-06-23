namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double e = 1e-9;
        if (-e < a && a < e) throw new ArgumentException();
        
        if ( double.IsNaN(a)  double.IsInfinity(a)  double.IsNaN(b)  double.IsInfinity(b)  double.IsNaN(c) || double.IsInfinity(c)) throw new System.ArgumentException();
        
        b = b / a;
        c = c / a;
        double discr = b * b - 4 * c;
        double[] zeroRoots = new double[] { };
        if (discr <= -e) return zeroRoots;
        else if (-e < discr && discr < e)
        {
            double[] Roots1 = new double[1];
            oneRoots[0] = -(b) / 2;
            return Roots1;
        }
        else
        {
            double[] Roots2 = new double[2];
            Roots2[0] = -(b + Math.Sign(b) * Math.Sqrt(discr)) / 2;
            Roots2[1] = c / Roots2[0];
            return Roots2;
        }
    }
}     
