namespace Task3
{
    using System;
    using System.Linq;
    using System.Text;

    public class DoubleChars
    {
        public static void EnterPoint()
        {
            var userStr = new StringBuilder();
            Console.WriteLine(Resources.entStrToChng);//todo pn сильная связность решения.
            userStr.Append(Console.ReadLine());
            Console.WriteLine(Resources.entStrSecond);
            var charSource = Console.ReadLine();
            Console.WriteLine(DoubleC(userStr, charSource));
        }

        private static StringBuilder DoubleC(StringBuilder userStr, string chars)
        {
            for (var i = userStr.Length - 1; i >= 0; i--)
            {
                if (chars.Contains(userStr[i]))
                {
                    userStr.Insert(i, userStr[i]);
                }
            }

            return userStr;
        }  
    }
}
