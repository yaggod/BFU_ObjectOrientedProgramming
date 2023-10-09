namespace IntegralSolverApp.IntegralSolvers
{
    internal abstract class IntegralSolver
    {
        private int _stepsCount;

        public int StepsCount
        {
            get => _stepsCount;
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(StepsCount)} can not be negative");
                _stepsCount = value;
            }
        }

        public Func<double, double> FunctionToIntegrate
        {
            get;
            protected set;
        }

        protected IntegralSolver(int stepsCount, Func<double, double> functionToIntegrate)
        {
            StepsCount = stepsCount;
            FunctionToIntegrate = functionToIntegrate;
        }


        public abstract double CalculateIntegral(double lowerBound, double upperBound);
    }
}
