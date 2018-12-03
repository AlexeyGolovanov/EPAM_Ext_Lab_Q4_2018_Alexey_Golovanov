namespace Task3
{
    using System;

    public class PlusSum
    {
        public static void EnterPoint()
        {
            var rnd = new Random();
            var array = new int[rnd.Next(2, 25)];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-99, 99);
            }

            Console.WriteLine(Resources.arr + "\n" + string.Join(" ", array));
            Console.WriteLine(Resources.posSum + PositiveSum(array));
        }

        private static int PositiveSum(int[] array)
        {
            var sum = 0;
            foreach (var a in array)
            {
                if (a > 0)
                {
                    sum += a;
                }
            }

            return sum;
        }   
    }
}
