namespace SearchMeths
{
    using System;
    using System.Diagnostics;
    using static Search;

    public class Program
    {
        private const int MinRand = -99;
        private const int MaxRand = -99;
        private const int ArraySize = 10000;
        private const int Iterations = 1000;

        public delegate bool SearchCond(int number);

        public static bool Cond(int num)
        {
            return num > 0;
        }

        public static int[] CreateIntArray(int size)
        {
            var array = new int[ArraySize];

            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(MinRand, MaxRand);
            }

            return array;
        }

        private static void Main()
        {
            Console.WriteLine("Integer array contains {0} elements. Number of measurements for each method: {1}", ArraySize, Iterations);

            var testArray = CreateIntArray(ArraySize);

            TimeSpan time = TimeSpan.Zero;

            for (int i = 0; i < Iterations; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Direct(testArray);
                sw.Stop();
                time += sw.Elapsed;
            }

            Console.WriteLine("average search time of direct search: {0}ms", time.TotalMilliseconds / Iterations);

            time = TimeSpan.Zero;
            SearchCond delegUsual = Cond;

            for (int i = 0; i < Iterations; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                DelegCondition(testArray, delegUsual);
                sw.Stop();
                time += sw.Elapsed;
            }

            Console.WriteLine("average search time of search with condition provided through delegate: {0}ms", time.TotalMilliseconds / Iterations);

            time = TimeSpan.Zero;
            SearchCond delegAnon = delegate(int num) { return num > 0; };

            for (int i = 0; i < Iterations; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                DelegCondition(testArray, delegAnon);
                sw.Stop();
                time += sw.Elapsed;
            }

            Console.WriteLine("average search time of search with condition provided through delegate as anonymous method: {0}ms", time.TotalMilliseconds / Iterations);

            time = TimeSpan.Zero;
            SearchCond delegLambda = (x) => (x > 0);

            for (int i = 0; i < Iterations; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                DelegCondition(testArray, delegLambda);
                sw.Stop();
                time += sw.Elapsed;
            }

            Console.WriteLine("average search time of search with condition provided through delegate as lambda expression: {0}ms", time.TotalMilliseconds / Iterations);

            time = TimeSpan.Zero;

            for (int i = 0; i < Iterations; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Linq(testArray);
                sw.Stop();
                time += sw.Elapsed;
            }

            Console.WriteLine("average search time of LINQ-expression search: {0}ms", time.TotalMilliseconds / Iterations);
            Console.ReadLine();
        }
    }
}
