using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wielowatkowosc
{
    class LL
    {
        public int N { get; private set; }
        public int Threads { get; private set; }
        public Matrix LeftMatrix;
        public Matrix RightMatrix;
        public Matrix ResultMatrix;


        public LL(int n, int threads, int seedLeft, int maxvalue)
        {
            N = n;
            Threads = Math.Min(n, threads);

            LeftMatrix = new Matrix(N, seedLeft, maxvalue);
            RightMatrix = new Matrix(N, seedLeft, maxvalue);
            ResultMatrix = new Matrix(N, seedLeft, maxvalue);
            Multiply(Threads);
        }

        public Matrix Multiply(int threads)
        {

            var th = new Thread[threads];

            for (var t = 0; t < threads; t++)
            {
                var threadIndex = t;
                th[t] = new Thread(() => MultiplyPart(threadIndex, threads));
                th[t].Start();
            }

            foreach (var thread in th)
            {
                thread.Join();
            }

            return ResultMatrix;
        }

        private void MultiplyPart(int threadIndex, int totalThreads)
        {
            var sizePerThread = N / totalThreads;
            var startRow = threadIndex * sizePerThread;
            var endRow = (threadIndex == totalThreads - 1) ? N : startRow + sizePerThread;

            for (var i = startRow; i < endRow; i++)
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
