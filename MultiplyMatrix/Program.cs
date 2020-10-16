using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MultiplyMatrix
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Test Number=2
            Console.WriteLine("Проверочный блок кода:");
            int N = 2;
            int[,] A = new int[N, N];
            int[,] B = new int[N, N];
            int[,] C = new int[N, N];
            CreatArray(ref A, N);
            CreatArray(ref B, N);
            Parallel.For(0, N, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i =>
             {
                 Console.WriteLine($"Сообщение от потока id {Thread.CurrentThread.ManagedThreadId}");
                 for (int j = 0; j < N; j++)
                 {
                     C[i, j] = 0;
                     for (int k = 0; k < N; k++)
                         C[i, j] += A[i, k] * B[k, j];
                 }
             });
            Console.WriteLine("Array 1:");
            PrintArray(A, N);
            Console.WriteLine("Array 2:");
            PrintArray(B, N);
            Console.WriteLine("Multiplied array:");
            PrintArray(C, N);
            #endregion


            #region Number=100 parallel
            Console.WriteLine("\n\nПеремножение матриц 100х100 параллельно:");
            int M = 100;
            int[,] A1 = new int[M, M];
            int[,] B1 = new int[M, M];
            int[,] C1 = new int[M, M];
            int[,] D1 = new int[M, M];
            CreatArray(ref A1, M);
            CreatArray(ref B1, M);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, M, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i =>
            {
                //Console.WriteLine($"Сообщение от потока id {Thread.CurrentThread.ManagedThreadId}");
                for (int j = 0; j < M; j++)
                {
                    C1[i, j] = 0;
                    for (int k = 0; k < M; k++)
                        C1[i, j] += A1[i, k] * B1[k, j];
                }
            });
            stopwatch.Stop();
            Console.WriteLine("Потрачено времени: {0}", stopwatch.Elapsed);
            #endregion


            #region Number=100 consistently
            Console.WriteLine("\n\nПеремножение матриц 100х100 последовательно:");
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            MultiPlyArrays(ref D1, A1, B1, M);
            stopwatch1.Stop();
            Console.WriteLine("Потрачено времени: {0}", stopwatch1.Elapsed);
            #endregion
        }

        public static void CreatArray(ref int [,] Ar, int n)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Ar[i, j] = r.Next(11);
        }
        public static void PrintArray(int[,] Ar, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) Console.Write(Ar[i, j]+" ");
                Console.WriteLine();
            }
        }

        public static void MultiPlyArrays(ref int[,] Ar, int[,] Ar1, int[,] Ar2,  int n)
        {
            for(int i=0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Ar[i, j] = 0;
                    for (int k = 0; k < n; k++)
                        Ar[i, j] += Ar1[i, k] * Ar2[k, j];
                }
            }
        }
    }
}
