using System;
using System.Collections.Generic;
using System.Text;
using Library_DB.Classes;
using Library_DB.InterfaceClasses;

namespace Library_DB.InterfaceClasses
{
    public class MenuSelect
    {
        public static void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("Меню получения данных из БВ. Введите:");
                Console.WriteLine("1 - Для получения данных по Id пользователя.");
                Console.WriteLine("2 - Вывод данных по всем пользователям.");
                Console.WriteLine("3 - Для получения данных по Id книги.");
                Console.WriteLine("4 - Вывод данных по всех книгах.");
                Console.WriteLine("5 - Возврат в основно меню.");
                Console.WriteLine("6 - Выход из программы.");

                try
                {
                    int userKey = Convert.ToInt32(Console.ReadLine());
                    switch (userKey)
                    {
                        case 1:
                            Console.WriteLine("Введите Id пользователя: ");
                            if (int.TryParse(Console.ReadLine(), out int userKeyId))
                            {
                                UserRepository.GetUserInfoById(userKeyId);
                            }
                            else Console.WriteLine("Необходимо ввести число!.");
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                        case 2:
                            UserRepository.GetAllUsersInfo();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.WriteLine("Введите Id книги: ");
                            if (int.TryParse(Console.ReadLine(), out int bookKeyId))
                            {
                                BookRepository.GetBookInfoById(bookKeyId);
                            }
                            else Console.WriteLine("Необходимо ввести число!.");
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                        case 4:
                            BookRepository.GetAllBooksInfo();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.Clear();
                            MainMenu.StartMainMenu();
                            break;

                        case 6:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Необходимо ввести корректное число!");
                            break;

                    }
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);  
                    Console.WriteLine("Необходимо ввести число !");
                    Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }
    }
}
