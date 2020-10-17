using System;
using System.Threading;

namespace MultiThreadedComputing
{
    class Program
    {
        static void Main(string[] args)
        {
            var main_thread = Thread.CurrentThread;
            main_thread.Name = "Главный поток!";
            PrintThreadInfo();
            int N;
            Console.WriteLine("Введите число N к которому посчитается факториал и" +
                " сумма целых чисел до N");
            N = Convert.ToInt32(Console.ReadLine());
            var FacThread = new Thread(PrintFactorial)
            {
                Name = "Поток факториала"
            };
            FacThread.Start(N);
            var SumThread = new Thread(PrintSum)
            {
                Name = "Поток Суммы"
            };
            SumThread.Start(N);
            Console.WriteLine("Главный поток завершил работу");
        }

        public static void PrintFactorial(object obj)
        {
            int N = (int)obj;
            PrintThreadInfo();
            Console.WriteLine($"\nФакториал равен: { Factorial(N) }");
        }


        public static void PrintSum(object obj)
        {
            int N = (int)obj;
            PrintThreadInfo();
            Console.WriteLine($"\nСумма целых чисел равна: { Sum(N) }");
        }

        public static int Factorial(int N)
        {
            int f = 1, n = 1;
            while(N>0)
            {
                Console.WriteLine($"Фактариал: {f} * {n}");
                f *=n;
                n++;
                N--;
                Thread.Sleep(100);
            }
            return f;
        }

        public static int Sum(int N)
        {
            int Sum = 0, s=1;
            while(N>0)
            {
                Console.WriteLine($"Сумма: {Sum} + {s}");
                Sum += s;
                s++;
                N--;
                Thread.Sleep(100);
            }
            return Sum;
        }

        private static void PrintThreadInfo()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine( 
                "\nПоток id: {0}; name: {1}; priority: {2}\n",
               thread.ManagedThreadId, thread.Name, thread.Priority);
        }
    }
}
