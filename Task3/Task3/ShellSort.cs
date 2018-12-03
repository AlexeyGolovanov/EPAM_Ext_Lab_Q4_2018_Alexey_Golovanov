namespace Task3
{
    using System;

    public class ShellSort
    {
        public static void SortArray()
        {
            var rand = new Random();
            var arrToSort = new int[rand.Next(1, 20)];
            for (var i = 0; i < arrToSort.Length; i++)
            {
                arrToSort[i] = rand.Next(-99, 99);
            }

            Console.WriteLine(Resources.Sort);
            Console.WriteLine(string.Join(" ", arrToSort));
            arrToSort = Sort(arrToSort);
            Console.WriteLine(Resources.Shell);
            Console.WriteLine(string.Join(" ", arrToSort));
            Console.WriteLine(Resources.SortFirstLast, arrToSort[0], arrToSort[arrToSort.Length - 1]);
        }

        private static int[] Sort(int[] array)
        {
            int j;
            int step = array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (array.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (array[j] > array[j + step]))
                    {
                        int tmp = array[j];
                        array[j] = array[j + step];
                        array[j + step] = tmp;
                        j -= step;
                    }
                }

                step /= 2;
            }

            return array;
        } 
    }
}
