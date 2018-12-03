namespace Task3
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Menu.ShowMenu();
                Menu.ChooseOption(Console.ReadLine());
            }
        }
    }
}
