 using System;

class Program {
  public static void Main (string[] args) {
    Complex num = new Complex(3, 4);
    Console.WriteLine($"Real Part: {num.RealPart}, Imaginary Part: {num.ImaginaryPart}");
  }
}

public class Complex
{
    public static readonly Complex Zero = new Complex(0, 0);
    public static readonly Complex Unity = new Complex(1, 0);
    public static readonly Complex ImaginaryUnit = new Complex(0, 1);

    public double RealPart { get; }
    public double ImaginaryPart { get; }

    public Complex(double real, double imaginary)
    {
        RealPart = real;
        ImaginaryPart = imaginary;
    }

    public Complex(double real) : this(real, 0) { }

    public Complex Add(Complex other) =>
        new Complex(RealPart + other.RealPart, ImaginaryPart + other.ImaginaryPart);

    public Complex Subtract(Complex other) =>
        new Complex(RealPart - other.RealPart, ImaginaryPart - other.ImaginaryPart);

    public Complex Multiply(Complex other) =>
        new Complex(RealPart * other.RealPart - ImaginaryPart * other.ImaginaryPart,
                    RealPart * other.ImaginaryPart + ImaginaryPart * other.RealPart);

    public Complex Divide(Complex other)
    {
        double denominator = other.RealPart * other.RealPart + other.ImaginaryPart * other.ImaginaryPart;
        if (denominator == 0)
            throw new DivideByZeroException("Division by zero.");

        double realPart = (RealPart * other.RealPart + ImaginaryPart * other.ImaginaryPart) / denominator;
        double imaginaryPart = (ImaginaryPart * other.RealPart - RealPart * other.ImaginaryPart) / denominator;

        return new Complex(realPart, imaginaryPart);
    }

    public Complex Negate() => new Complex(-RealPart, -ImaginaryPart);

    public double Modulus => Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);

    public override string ToString() => $"{RealPart} + {ImaginaryPart}i";
}
