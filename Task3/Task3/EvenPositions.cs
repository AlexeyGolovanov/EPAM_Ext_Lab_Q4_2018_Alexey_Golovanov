namespace Task3
{
    using System;

    public class EvenPositions
    {
        public static void EnterPoint()
        {
            var rnd = new Random();
            var array = new int[rnd.Next(2, 25), rnd.Next(2, 25)];
            Console.WriteLine(Resources.arr);
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(-99, 99);//todo pn такие вещи лучше выносить либо в конфиг, либо хотя бы в константы. Тем более у тебя они повторяются неоднократно во многих местах.
                    Console.Write("{0,4}", array[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(Resources.sumOnEven + SumOnEvenPositions(array));
        }

        private static int SumOnEvenPositions(int[,] array)
        {
            var sum = 0;
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }

            return sum;
        } 
    }
}
