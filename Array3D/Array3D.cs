using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array3D
{
    internal class Array3D<T>
    {
        private readonly T[] array;
        private readonly int _firstDimension;
        private readonly int _secondDimension;
        private readonly int _thirdDimension;

        public int FirstDimension => _firstDimension;

        public int SecondDimension => _secondDimension;

        public int ThirdDimension => _thirdDimension;


        private int FirstDimensionSubArraySize => SecondDimensionSubArraySize * SecondDimension;
        private int SecondDimensionSubArraySize => ThirdDimensionSubArraySize * ThirdDimension;
        private int ThirdDimensionSubArraySize => 1;



        public int TotalSize => FirstDimension * SecondDimension * ThirdDimension;

        public T this[int i, int j, int k]
        {
            get
            {
                if (!IsValidIndexes(i, j, k))
                    throw new ArgumentOutOfRangeException();
                return array[GetOneDimensionalIndexFromThreeDimensionalIndex(i, j, k)];
            }

            set
            {
                if (!IsValidIndexes(i, j, k))
                    throw new ArgumentOutOfRangeException();
                array[GetOneDimensionalIndexFromThreeDimensionalIndex(i, j, k)] = value;
            }
        }


        public Array3D(int firstDimension, int secondDimension, int thirdDimension, T valuesToFillWith = default) 
            : this(firstDimension, secondDimension, thirdDimension, (i,j,k) => valuesToFillWith)
        {
        }

        public Array3D(int firstDimension, int secondDimension, int thirdDimension, Func<int, int, int, T> indexesToValue)
        {
            _firstDimension = firstDimension;
            _secondDimension = secondDimension;
            _thirdDimension = thirdDimension;

            array = new T[firstDimension * secondDimension * thirdDimension];

            for (int i = 0; i < FirstDimension; i++)
                for(int j = 0; j < SecondDimension; j++)
                    for(int k = 0; k < ThirdDimension; k++)
                        this[i, j, k] = indexesToValue(i, j, k);
        }

        public T[,] GetValues0(int i)
        {
            T[,] result = new T[SecondDimension, ThirdDimension];
            for (int j = 0; j < SecondDimension; j++)
                for (int k = 0; k < ThirdDimension; k++)
                    result[j,k] = this[i, j, k];

            return result;
        }

        public T[,] GetValues1(int j)
        {
            T[,] result = new T[FirstDimension, ThirdDimension];
            for (int i = 0; i < FirstDimension; i++)
                for (int k = 0; k < ThirdDimension; k++)
                    result[j, k] = this[i, j, k];

            return result;
        }

        public T[,] GetValues2(int k)
        {
            T[,] result = new T[FirstDimension, SecondDimension];
            for (int i = 0; i < FirstDimension; i++)
                for (int j = 0; j < SecondDimension; j++)
                    result[j, k] = this[i, j, k];

            return result;
        }

        public T[] GetValues01(int i, int j)
        {
            T[] result = new T[ThirdDimension];

            for (int k = 0; k < ThirdDimension; k++)
                result[k] = this[i, j, k];

            return result;
        }

        public T[] GetValues02(int i, int k)
        {
            T[] result = new T[SecondDimension];

            for (int j = 0; j < SecondDimension; j++)
                result[j] = this[i, j, k];

            return result;
        }

        public T[] GetValues12(int j, int k)
        {
            T[] result = new T[FirstDimension];

            for (int i = 0; i < FirstDimension; i++)
                result[i] = this[i, j, k];

            return result;
        }



        private int GetOneDimensionalIndexFromThreeDimensionalIndex(int i, int j, int k)
        {
            int temp = i * FirstDimensionSubArraySize + j * SecondDimensionSubArraySize + k;
            return temp;
        }

        private bool IsValidIndexes(int i, int j, int k)
        {
            return IsInRange(i, -1, FirstDimension) &&
                IsInRange(j, -1, SecondDimension) &&
                IsInRange(k, -1, ThirdDimension);
        }

        private bool IsInRange(int value, int min, int max)
        {
            return value > min && value < max;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append('[');
            for(int i = 0; i < FirstDimension;i++)
            {
                stringBuilder.Append('[');
                for (int j = 0; j < SecondDimension; j++)
                {
                    stringBuilder.Append('{');

                    var thirdDimensionValues = Enumerable.Range(0, ThirdDimension).Select(k => this[i,j, k]);
                    stringBuilder.AppendJoin(',', thirdDimensionValues);

                    stringBuilder.Append('}');

                }
                stringBuilder.Append(']');
                stringBuilder.Append('\n');

            }

            return stringBuilder.ToString();
        }

    }
}
