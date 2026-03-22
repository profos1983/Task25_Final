using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DB.InterfaceClasses
{
    public class MainMenu
    {
        public static void StartMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Меню выбора действий с базой данных Library_DB. Введите:");
                Console.WriteLine("1 - Для получения данных из БД.");
                Console.WriteLine("2 - Для изменения данных в БД.");
                Console.WriteLine("3 - Для спец.запросов к БД (Задание 25.5.4*).");
                Console.WriteLine("4 - Для выхода из программы.");

                try
                {
                    int userKey = Convert.ToInt32(Console.ReadLine());
                    switch (userKey)
                    {
                        case 1:
                            MenuSelect.StartMenu();
                            break;
                        case 2:
                            MenuUpdateDelete.StartMenu();
                            break;
                        case 3:
                            MenuSpecSelect.StartMenu();
                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Необходимо ввести либо 1 либо 2!");
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                    }
                }
                catch (Exception ex) 
                {
                    // Console.WriteLine(ex.Message);  
                    Console.WriteLine("Необходимо ввести число (1 или 2)!!!");
                    Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                    Console.ReadKey();
                }

                Console.Clear();

            }
        }
    }
}
