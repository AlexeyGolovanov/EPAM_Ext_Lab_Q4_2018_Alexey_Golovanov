namespace Task3
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class StrOpTime
    {
        public static void EnterPoint()
        {
            var n = 100;
            for (int i = 0; i < 5; i++)
            {
                CountTime(n);
                n *= 10;
            }
        }

        private static void CountTime(int n)
        {
            var results = new string[2];
            var watch = new Stopwatch();

            string str = string.Empty;
            StringBuilder sb = new StringBuilder();
            watch.Restart();
            for (int i = 0; i < n; i++)
            {
                str += "*";
            }

            results[0] = watch.ElapsedMilliseconds.ToString();
            watch.Restart();
            for (int i = 0; i < n; i++)
            {
                sb.Append("*");
            }

            results[1] = watch.ElapsedMilliseconds.ToString();

            Console.WriteLine(Resources.strGrow, n);
            Console.WriteLine(Resources.strVsSB, results[0], results[1], '\t');
        }  
    }
}
