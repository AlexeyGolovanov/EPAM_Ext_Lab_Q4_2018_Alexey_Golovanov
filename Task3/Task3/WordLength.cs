namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WordLength
    {
        public static void EnterPoint()
        {
            Console.WriteLine(Resources.enterStr);//todo pn сильная связность решения.
            var userStr = Console.ReadLine();
            Console.WriteLine(Resources.averageLength + GetAverage(userStr));
        }

        private static int GetAverage(string userStr)
        {
            List<char> separators = new List<char>();
            foreach (var ch in userStr)
            {
                if (!char.IsLetterOrDigit(ch) && !userStr.Contains(ch))
                {
                    separators.Add(ch);
                }
            }

            separators.Remove('-');//todo pn в константы

            var average = 0;
            var number = 0;
            var str = userStr.Split(separators.ToArray());
            foreach (var a in str)
            {
                if (a != string.Empty)
                {
                    average += a.Length;
                    number++;
                }
            }

            return average / number;
        }  
    }
}
