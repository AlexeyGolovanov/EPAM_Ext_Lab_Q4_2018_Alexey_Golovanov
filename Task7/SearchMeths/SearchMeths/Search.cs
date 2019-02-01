namespace SearchMeths
{
    using System.Collections.Generic;
    using System.Linq;
    using static Program;

    public class Search
    {
        public static int[] Direct(int[] array)
        {
            var positive = new List<int>();

            foreach (var element in array)
            {
                if (element > 0)
                {
                    positive.Add(element);
                }
            }

            return positive.ToArray();
        }

        public static int[] DelegCondition(int[] array, SearchCond cond)
        {
            var suitsTo = new List<int>();

            foreach (var element in array)
            {
                if (cond(element))
                {
                    suitsTo.Add(element);
                }
            }

            return suitsTo.ToArray();
        }

        public static int[] Linq(int[] array)
        {
            var positive = from element in array
                           where element > 0
                           select element;
            return positive.ToArray();
        }
    }
}
