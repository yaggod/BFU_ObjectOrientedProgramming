using IntegralSolverApp.IntegralSolvers;

namespace IntegralSolverApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> functionToIntegrate =
                (argument) =>
                {
                    return Math.Exp(argument);
                };

            int stepsCount = 100;
            double lowerBound = 0;
            double upperBound = 20;

            IntegralSolver trapeziodalIntegralSolver = new TrapeziodalIntegralSolver(stepsCount, functionToIntegrate);
            IntegralSolver parabolicIntegralSolver = new ParabolicIntegralSolver(stepsCount, functionToIntegrate);

            double trapeziodalIntegralSolverResult = trapeziodalIntegralSolver.CalculateIngegral(lowerBound, upperBound);
            double parabolicIntegralSolverResult = parabolicIntegralSolver.CalculateIngegral(lowerBound, upperBound);

            Console.WriteLine($"Результат для метода трапеций:\n\tЧисло шагов: {stepsCount}. Результат от {lowerBound} до {upperBound} - {trapeziodalIntegralSolverResult}\n\n");
            Console.WriteLine($"Результат для метода парабол:\n\tЧисло шагов: {stepsCount}. Результат от {lowerBound} до {upperBound} - {parabolicIntegralSolverResult}\n\n");
        }
    }
}