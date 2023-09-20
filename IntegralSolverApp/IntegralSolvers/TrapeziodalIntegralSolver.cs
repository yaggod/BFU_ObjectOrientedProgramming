namespace IntegralSolverApp.IntegralSolvers
{
    internal class TrapeziodalIntegralSolver : IterativeIntegralSolver
    {
        public TrapeziodalIntegralSolver(int stepsCount, Func<double, double> functionToIntegrate)
            : base(stepsCount, functionToIntegrate) { }

        public override double GetSubesultForBounds(double lowerBound, double upperBound)
        {
            double boundsDelta = upperBound - lowerBound;
            return (FunctionToIntegrate(lowerBound) + FunctionToIntegrate(upperBound)) / 2 * boundsDelta;
        }
    }
}
