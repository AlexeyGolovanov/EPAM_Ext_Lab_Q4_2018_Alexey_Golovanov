namespace Task3
{
    using System;

    public class StarsTasks
    {
        private const int RowsMax = 15;

        public static void StarsMenu(int option)
        {
            Console.WriteLine(Resources.testRnd);
            Console.WriteLine(Resources.testUser);

            var whatToDo = TwoOptions.ChooseOne();
            int height = 0;
            switch (whatToDo)
            {
                case 1:
                {
                    height = DrawStarsRnd();
                    break;
                }

                case 2:
                {
                    height = DrawStarsManual();
                    break;
                }
            }

            if (height != 0)
            {
                switch (option)
                {
                    case 1:
                        Count(height);
                        break;

                    case 2:
                        CountCenter(height);
                        break;

                    case 3:
                        TriangleGroup(height);
                        break;
                }
            }
        }

        private static string Shift(string s, int count)
        {
            count %= s.Length;
            return s.Substring(s.Length - count) + s.Substring(0, s.Length - count);
        }

        private static int DrawStarsRnd()
        {
            Random rand = new Random();
            var height = rand.Next(1, RowsMax);
            return height;
        }

        private static int DrawStarsManual()
        {
            Console.WriteLine(Resources.Stars1);
            if (int.TryParse(Console.ReadLine(), out int height) && height > 0 && height <= RowsMax)
            {
                return height;
            }

            Console.WriteLine(Resources.errorStars1);
            return 0;
        }

        private static void Count(int height)
        {
            for (int i = 1; i < height + 1; i++)
            {
                var s = new string('*', i);//todo pn в константы
                Console.WriteLine(s);
            }
        }

        private static void CountCenter(int height)
        {
            int stars = 1;
            for (int i = 0; i < height; i++)
            {
                int spaces = (height * 2) - 1 - stars;
                var s = new string('*', stars) + new string(' ', spaces);//todo pn в константы
                stars += 2;
                s = Shift(s, spaces / 2);
                Console.WriteLine(s);
            }
        }

        private static void TriangleGroup(int height)
        {
            for (var i = 1; i < height + 1; i++)
            {
                int stars = 1;
                for (int j = 0; j < i; j++)
                {
                    int spaces = (height * 2) - 1 - stars;
                    var s = new string('*', stars) + new string(' ', spaces);//todo pn в константы
                    stars += 2;
                    s = Shift(s, spaces / 2);
                    Console.WriteLine(s);
                }
            }
        }
    }
}
