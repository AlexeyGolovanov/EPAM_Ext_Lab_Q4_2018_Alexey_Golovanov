namespace Task3
{
    using System;
    using System.Linq;

    public class FontTask
    {
        private const int OptionsQ = 3;
        private static string[] font = new string[OptionsQ];
        private static bool flag = true;

        public static void Menu()
        {
            while (flag)
            {
                var paramList = string.Join(" ", font);
                if (string.IsNullOrWhiteSpace(paramList))
                {
                    paramList = Resources.none;
                }

                Console.WriteLine(Resources.strParams + paramList);//todo pn сильная связность решения.
                Console.WriteLine(Resources.enter); 
                Console.WriteLine('\t' + Resources.font1);
                Console.WriteLine('\t' + Resources.font2);
                Console.WriteLine('\t' + Resources.font3);
                Console.WriteLine('\t' + Resources.font0);
                MenuProc();
            }
        }

        public static void MenuProc()
        {
                if (int.TryParse(Console.ReadLine(), out int parsRes) && parsRes <= OptionsQ && parsRes >= 0)
                {
                    switch (parsRes)
                    {
                        case 0:
                            flag = false;
                            break;
                        case 1:
                        {
                            font[0] = font.Contains(Resources.bold) ? string.Empty : Resources.bold;
                            break;
                        }

                        case 2:
                        {
                            font[1] = font.Contains(Resources.italic) ? string.Empty : Resources.italic;
                            break;
                        }

                        case 3:
                        {
                            font[2] = font.Contains(Resources.underlined) ? string.Empty : Resources.underlined;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(Resources.errorMenu, OptionsQ);//todo pn сильная связность решения.
            }
        }
    }
}