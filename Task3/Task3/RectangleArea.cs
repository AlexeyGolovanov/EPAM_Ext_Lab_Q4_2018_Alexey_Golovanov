namespace Task3
{
    using System;

    public class RectangleArea
    {
        public static void AreaMenu()
        {
            Console.WriteLine(Resources.testRnd);
            Console.WriteLine(Resources.testUser);

            var whatToDo = TwoOptions.ChooseOne();

            switch (whatToDo)
            {
                case 1:
                {
                    CountAreaRnd();
                    break;
                }

                case 2:
                {
                    CountArea();
                    break;
                }
            }
        }

        private static void CountAreaRnd()
        {
            Random rand = new Random();
            var width = rand.Next(1, 1000);
            var height = rand.Next(1, 1000);
            Console.WriteLine(Resources.area, height, width, height * width);
        }

        private static void CountArea()
        {
            Console.WriteLine(Resources.height);
            if (int.TryParse(Console.ReadLine(), out int height) && height > 0)
            {
                Console.WriteLine(Resources.width);
                if (int.TryParse(Console.ReadLine(), out int width) && width > 0)
                {
                    Console.WriteLine(Resources.area, height, width, height * width);
                }
                else
                {
                    Console.WriteLine(Resources.errorArea);
                }
            }
            else
            {
                Console.WriteLine(Resources.errorArea);
            }
        } 
    }
}
