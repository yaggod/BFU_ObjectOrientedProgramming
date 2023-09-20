namespace IntegralSolverApp.IntegralSolvers
{
    internal class ParabolicIntegralSolver : IterativeIntegralSolver
    {
        public ParabolicIntegralSolver(int stepsCount, Func<double, double> functionToIntegrate)
            : base(stepsCount, functionToIntegrate) { }

        public override double GetSubesultForBounds(double lowerBound, double upperBound)
        {
            double boundsDelta = upperBound - lowerBound;
            return (FunctionToIntegrate(lowerBound) + 4 * FunctionToIntegrate(lowerBound + boundsDelta / 2) + FunctionToIntegrate(upperBound)) / 6 * boundsDelta;
        }
    }
}
