using System;

class EquationSolver {
  public static void Main (string[] args) {

  }
}

public interface IEquationSolver
{
    int Size { get; }
    double[] Parameters { get; }
    Complex[] CalculateRoots();
}
