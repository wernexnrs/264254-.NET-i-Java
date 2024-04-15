using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wielowatkowosc
{
    internal class Matrix
    {
        public int[,] Data { get; private set; }
        public int N { get; private set; }
        public int Seed { get; private set; }
        public int MaxValue { get; private set; }

        public Matrix(int n, int seed, int maxValue)
        {
            N = n;
            Seed = seed;
            MaxValue = maxValue;

            Data = new int[n, n];

            var rnd = new Random(seed);

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Data[i, j] = rnd.Next(MaxValue);
                }
            }
        }
        public override string ToString()
        {
            var matrixString = new StringBuilder();

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    matrixString.Append(Data[i, j].ToString().PadRight(5));
                }
                matrixString.AppendLine();
            }

            return matrixString.ToString();
        }

    }
}
