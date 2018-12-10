namespace Task3
{
    using System;

    public class Menu
    {
        private const int TasqQuantity = 13;

        public static void ShowMenu()
        {
            Console.WriteLine(Resources.MenuHead);//todo pn сильная связность решения.
            Console.WriteLine(Resources.task1);
            Console.WriteLine(Resources.task2);
            Console.WriteLine(Resources.task3);
            Console.WriteLine(Resources.task4);
            Console.WriteLine(Resources.task5);
            Console.WriteLine(Resources.task6);
            Console.WriteLine(Resources.task7);
            Console.WriteLine(Resources.task8);
            Console.WriteLine(Resources.task9);
            Console.WriteLine(Resources.task10);
            Console.WriteLine(Resources.task11);
            Console.WriteLine(Resources.task12);
            Console.WriteLine(Resources.task13);
            Console.WriteLine(Resources.exit);
        }

        public static void ChooseOption(string entered)
        {
            Console.Clear();
            if (int.TryParse(entered, out int parsRes) && parsRes <= TasqQuantity && parsRes >= 0)
            {
                switch (parsRes)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                    {
                        var flag = true;
                        while (flag)
                        {
                            RectangleArea.AreaMenu();
                            Console.WriteLine(Resources.FuncFinish);
                            flag = TwoOptions.ChooseOne() != 2;
                        }

                        break;
                    }

                    case 2:
                    {
                        var flag = true;
                        while (flag)
                        {
                            StarsTasks.StarsMenu(1);
                            Console.WriteLine(Resources.FuncFinish);
                            flag = TwoOptions.ChooseOne() != 2;
                        }

                        break;
                    }

                    case 3:
                    {
                        var flag = true;
                        while (flag)
                        {
                            StarsTasks.StarsMenu(2);
                            Console.WriteLine(Resources.FuncFinish);
                            flag = TwoOptions.ChooseOne() != 2;
                        }

                        break;
                    }

                    case 4:
                    {
                        var flag = true;
                        while (flag)
                        {
                            StarsTasks.StarsMenu(3);
                            Console.WriteLine(Resources.FuncFinish);
                            flag = TwoOptions.ChooseOne() != 2;
                        }

                        break;
                    }

                    case 5:
                    {
                        var flag = true;
                        while (flag)
                        {
                            IntSum_3.Solve35();
                            Console.WriteLine(Resources.FuncFinish);
                            flag = TwoOptions.ChooseOne() != 2;
                        }

                        break;
                    }

                    case 6:
                    {
                        FontTask.Menu();
                        break;
                    }

                    case 7:
                    {
                        var flag = true;
                        while (flag)
                        {
                            ShellSort.SortArray();
                            Console.WriteLine(Resources.arraySortExit);
                            flag = TwoOptions.ChooseOne() != 2;
                            Console.Clear();
                        }

                        break;
                    }

                    case 8:
                    {
                        var flag = true;
                        while (flag)
                        {
                            Array3d.Array3DEnterPoint();
                            Console.WriteLine(Resources.arraySortExit);
                            flag = TwoOptions.ChooseOne() != 2;
                            Console.Clear();
                        }

                        break;
                    }

                    case 9:
                    {
                        var flag = true;
                        while (flag)
                        {
                            PlusSum.EnterPoint();
                            Console.WriteLine(Resources.arraySortExit);
                            flag = TwoOptions.ChooseOne() != 2;
                            Console.Clear();
                        }

                        break;
                    }

                    case 10:
                    {
                        var flag = true;
                        while (flag)
                        {
                            EvenPositions.EnterPoint();
                            Console.WriteLine(Resources.arraySortExit);
                            flag = TwoOptions.ChooseOne() != 2;
                            Console.Clear();
                        }

                        break;
                    }

                    case 11:
                    {
                        var flag = true;
                        while (flag)
                        {
                            WordLength.EnterPoint();
                            Console.WriteLine(Resources.arraySortExit);
                            flag = TwoOptions.ChooseOne() != 2;
                            Console.Clear();
                        }

                        break;
                    }

                    case 12:
                    {
                        var flag = true;
                        while (flag)
                        {
                            DoubleChars.EnterPoint();
                            Console.WriteLine(Resources.arraySortExit);
                            flag = TwoOptions.ChooseOne() != 2;
                            Console.Clear();
                        }

                        break;
                    }

                    case 13:
                    {
                        var flag = true;
                        while (flag)
                        {
                            StrOpTime.EnterPoint();
                            Console.WriteLine(Resources.arraySortExit);
                            flag = TwoOptions.ChooseOne() != 2;
                            Console.Clear();
                        }

                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine(Resources.errorMenu, TasqQuantity);
            }
        }
    }
}
