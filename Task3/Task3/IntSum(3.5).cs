namespace Task3
{
    using System;

    public class IntSum_3
    {
        public static void Solve35()
        {
            int limit = 1000;
            int firstInt = 3;
            int secondInt = 5;
            var sum1 = Sum(firstInt, limit);
            var sum2 = Sum(secondInt, limit);
            Console.WriteLine(Resources.sumStr, firstInt, secondInt, limit, sum1 + sum2);//todo pn сильная связность решения.
        }

        private static int Sum(int step, int limit)
        {
            var endParam = 0;
            var sum = 0;
            while (endParam < limit - step)
            {
                endParam += step;
                sum += endParam;
            }

            return sum;
        } 
    }
}
