using System;

namespace OnlineShop.Shops.UI
{
    public class PrintMenu
    {
        public static string[] item = null;
      
        public static void Print(int choice)
        {
            Console.Clear();
            for (int i = 0; i < item.Length; ++i)
            {
                if (i == choice)
                {
                    Console.Write("=>");
                }

                Console.WriteLine(item[i]);
            }
        }

        public static string MenuShow()
        {
            int choice = 0;
            string command = string.Empty;

            while (true)
            {
                Print(choice);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (choice != 0)
                            --choice;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choice != item.Length - 1)
                            ++choice;
                        break;
                    case ConsoleKey.Enter:
                        return command = item[choice];
                }
            }
        }
    }
}
