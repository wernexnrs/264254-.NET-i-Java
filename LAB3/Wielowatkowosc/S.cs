﻿using System;
using System.Threading.Tasks;

namespace Wielowatkowosc
{
    internal class S
    {
        public int N { get; private set; }
        public int Threads { get; private set; }
        public Matrix LeftMatrix;
        public Matrix RightMatrix;
        public Matrix ResultMatrix;

        public S(int n, int threads, int seedRight, int maxvalue)
        {
            N = n;
            Threads = Math.Min(n, threads);

            LeftMatrix = new Matrix(N, seedRight, maxvalue);
            RightMatrix = new Matrix(N, seedRight, maxvalue);
            ResultMatrix = new Matrix(N, seedRight, maxvalue);

            for (var i = 0; i < n; i++)
            {
                for (var k = 0; k < N; k++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        ResultMatrix.Data[i, j] += LeftMatrix.Data[i, k] * RightMatrix.Data[k, j];
                    }
                }
            }

        }
    }
}