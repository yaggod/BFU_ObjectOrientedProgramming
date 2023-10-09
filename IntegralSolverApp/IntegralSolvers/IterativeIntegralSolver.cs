namespace IntegralSolverApp.IntegralSolvers
{
    internal abstract class IterativeIntegralSolver : IntegralSolver

    {
        protected IterativeIntegralSolver(int stepsCount, Func<double, double> functionToIntegrate)
            : base(stepsCount, functionToIntegrate) { }


        public override sealed double CalculateIntegral(double lowerBound, double upperBound)
        {
            double boundsDelta = upperBound - lowerBound;
            double step = boundsDelta / StepsCount;
            double result = 0;

            for (int i = 0; i < StepsCount; i++)
            {
                double leftPartBound = lowerBound + step * i;
                result += GetSubesultForBounds(leftPartBound, leftPartBound + step);
            }

            return result;
        }

        public abstract double GetSubesultForBounds(double lowerBound, double upperBound);

    }
}
