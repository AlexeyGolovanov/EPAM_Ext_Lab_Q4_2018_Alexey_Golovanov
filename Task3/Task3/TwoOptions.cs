namespace Task3
{
    using System;

    public class TwoOptions
    {
        private const int OptionsN = 2;

        public static int ChooseOne()
        {
            int res = 0;
            if (int.TryParse(Console.ReadLine(), out int parsRes) && parsRes <= OptionsN && parsRes > 0)
            {
                switch (parsRes)
                {
                    case 1:
                    {
                        res = 1;
                        break;
                    }

                    case 2:
                    {
                        res = 2;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine(Resources.errorTwo);
            }

            return res;
        }
    }
}
