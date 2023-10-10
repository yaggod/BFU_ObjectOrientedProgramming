using System.Linq;

using System.Globalization;

namespace Array3D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lambda = (int i, int j, int k) =>
                100 * i + 10 * j + k;

            Array3D<int> fakeArray = new Array3D<int>(6, 4, 3, lambda);
            fakeArray[5, 3, 2] = 2345789;
            Console.WriteLine(fakeArray);

            int[,] twoDimensionalValues = fakeArray.GetValues0(3);
            int[] oneDimensinalValues = fakeArray.GetValues12(1, 1);

            for (int j = 0; j  < twoDimensionalValues.GetLength(0); j++)
                for(int k = 0; k < twoDimensionalValues.GetLength(1); k++)
                    Console.WriteLine($"{j} {k}: {twoDimensionalValues[j,k]}");

            Console.WriteLine('\n');


            for (int i = 0; i < oneDimensinalValues.Length; i++)
                Console.WriteLine($"{i}: {oneDimensinalValues[i]}");

            fakeArray.SetValues0(1, twoDimensionalValues);

            Console.WriteLine('\n');

            Console.WriteLine(fakeArray);

        }
    }
}