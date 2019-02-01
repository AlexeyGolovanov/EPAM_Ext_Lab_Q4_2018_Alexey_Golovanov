namespace Extension2
{
    using System;
    using System.Linq;

    public static class IntInString
    {
        public static bool IsPosInt(this string str)
        { 
            char[] allowedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (str[0] == '-')
            {
                return false;
            }

            foreach (var ch in str)
            {
                if (!allowedChars.Contains(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Program
    {
        private static void Main()
        {
            var exampleString = Console.ReadLine();
            if (exampleString.IsPosInt())
            {
                Console.WriteLine("Entered string is positive integer");
            }
            else
            {
                Console.WriteLine("Entered string is either not integer or it is not positive");
            }

            Console.ReadLine();
        }
    }
}
