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
                Console.WriteLine("3 - Для выхода из программы.");

                try
                {
                    int userKey = Convert.ToInt32(Console.ReadLine());
                    switch (userKey)
                    {
                        case 1:
                            MenuSelect.StartMenuSelect();
                            break;
                        case 2:
                            Console.WriteLine("Запуститься окно, отвечающее за зарпосы на изменения в БД.");
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;
                        case 3:
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
