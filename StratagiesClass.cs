using System;

class EquationSolver {
    public static void Main (string[] args) {

    }
}
public class LinearEquationFinder : IRootFinder
{
    public Complex[] FindRoots(double[] equationCoefficients)
    {
        if (equationCoefficients.Length != 2)
            throw new ArgumentException("The coefficients array must contain 2 elements for a linear equation.");

        double a = equationCoefficients[0];
        double b = equationCoefficients[1];

        if (a == 0)
        {
            if (b == 0) throw new InvalidOperationException("Infinite number of roots.");
            else throw new InvalidOperationException("No roots.");
        }

        return new Complex[] { new Complex(-b / a) };
    }
}

public class QuadraticEquationFinder : IRootFinder
{
    public Complex[] FindRoots(double[] equationCoefficients)
    {
        if (equationCoefficients.Length != 3)
            throw new ArgumentException("The coefficients array must contain 3 elements for a quadratic equation.");

        double a = equationCoefficients[0];
        double b = equationCoefficients[1];
        double c = equationCoefficients[2];

        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double sqrtDiscriminant = Math.Sqrt(discriminant);
            return new Complex[] { new Complex((-b + sqrtDiscriminant) / (2 * a)), new Complex((-b - sqrtDiscriminant) / (2 * a)) };
        }
        else if (discriminant == 0) return new Complex[] { new Complex(-b / (2 * a)) };
        else throw new InvalidOperationException("No roots.");
    }
}
