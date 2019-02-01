namespace Extensions1
{
    using System;

    public static class SumOfElements
    {
        public static int Summarize(this int[] array)
        {
            var sum = 0;

            foreach (int i in array)
            {
                sum += i;
            }

            return sum;
        }
    }

    public class Program
    {
        private static void Main()
        {
            var check = new Values();
            var exampleArray = new int[check.ArraySize];
            Random rnd = new Random();
            for (int i = 0; i < check.ArraySize; i++)
            {
                exampleArray[i] = rnd.Next(check.RndMin, check.RndMax);
                Console.Write(exampleArray[i] + " ");
            }

            Console.WriteLine("\nSum of all array elements: {0}", exampleArray.Summarize());
            Console.ReadLine();
        }

        public class Values
        {
            public int RndMin { get; private set; } = -99;

            public int RndMax { get; private set; } = 99;

            public int ArraySize { get; private set; } = 15;
        }
    } 
}
