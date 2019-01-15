namespace _6._1v2
{
    using System;

    public class Program
    {
        private delegate bool DelegateUsing(string a, string b);

        private static bool Compare(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return str1.Length > str2.Length;
            }
           
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return str1[i] > str2[i];
                }
            }

            return false;
        }

        private static string[] Sort(string[] strArray, DelegateUsing compare)
        {
            string tmp;
            for (int i = 0; i < strArray.Length; i++)
            {
                for (int j = i + 1; j < strArray.Length; j++)
                {
                    if (compare(strArray[i], strArray[j]))
                    {
                        tmp = strArray[i];
                        strArray[i] = strArray[j];
                        strArray[j] = tmp;
                    }
                }
            }

            return strArray;
        }

        private static void Main()
        {
            string[] exampleArray = { "c", "a", "bacd", "abcd", "1abc", "1bac" };

            Console.WriteLine("Array before sorting:");
            Console.WriteLine(string.Join(" ", exampleArray));

            DelegateUsing compareMeth = Compare;

            Console.WriteLine("\nArray after sorting:");
            Console.WriteLine(string.Join(" ", Sort(exampleArray, compareMeth)));
            Console.ReadLine();
        }
    }
}
