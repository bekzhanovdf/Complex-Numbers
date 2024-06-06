using System;

public class EquationSolver : IEquationSolver
{
    private readonly double[] parameters;
    private readonly IRootFinder strategy;

    public int Size => parameters.Length;
    public double[] Parameters => (double[])parameters.Clone();

    public EquationSolver(double[] parameters)
    {
        parameters = RemoveExtraParameters(parameters);
        this.parameters = parameters;
        this.strategy = RootFindingStrategies.ChooseFinder(parameters);
    }

    public Complex[] CalculateRoots()
    {
        if (strategy == null)
            throw new InvalidOperationException("Unknown equation type.");

        return strategy.FindRoots(parameters);
    }

    private double[] RemoveExtraParameters(double[] parameters)
    {
        int lastIndex = parameters.Length - 1;
        while (lastIndex >= 0 && parameters[lastIndex] == 0) lastIndex--;

        return lastIndex < parameters.Length - 1 ? parameters[(lastIndex + 1)] : parameters;
    }
}