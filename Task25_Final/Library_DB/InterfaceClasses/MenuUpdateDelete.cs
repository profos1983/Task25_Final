using Library_DB.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DB.InterfaceClasses
{
    public class MenuUpdateDelete
    {
        public static void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("Меню изменения данных в БВ. Введите:");
                Console.WriteLine("1 - Добавление пользователя в БД.");
                Console.WriteLine("2 - Удаление пользователя из БД по Id.");
                Console.WriteLine("3 - Обновление имени пользователя по Id.");
                Console.WriteLine("4 - Добавление книги в БД.");
                Console.WriteLine("5 - Удаление книги из БД по Id.");
                Console.WriteLine("6 - Обновление года выпуска книги по Id.");
                Console.WriteLine("7 - Возврат в основно меню.");
                Console.WriteLine("8 - Выход из программы.");

                try
                {
                    int userKey = Convert.ToInt32(Console.ReadLine());
                    switch (userKey)
                    {
                        case 1:
                            UserRepository.InsertUserInBD();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;

                        case 2:
                            Console.WriteLine("Введите Id пользователя для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int userIdForDelete))
                            {
                                UserRepository.DeletetUserFromBD(userIdForDelete);
                            }
                            else Console.WriteLine("Необходимо ввести число!.");
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.WriteLine("Введите Id пользователя для изменения имени: ");
                            if (int.TryParse(Console.ReadLine(), out int userId))
                            {
                                UserRepository.UpdatetUserNameById(userId);
                            }
                            else Console.WriteLine("Необходимо ввести число!.");
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                        case 4:
                            BookRepository.InsertBookInBD();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.WriteLine("Введите Id книги для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int bookId))
                            {
                                BookRepository.DeleteBookFromDB(bookId);
                            }
                            else Console.WriteLine("Необходимо ввести число!.");
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                        case 6:
                            Console.WriteLine("Введите Id книги для изменения года выпуска: ");
                            if (int.TryParse(Console.ReadLine(), out int bookId6))
                            {
                                BookRepository.UpdateYearOfRelease(bookId6);
                            }
                            else Console.WriteLine("Необходимо ввести число!.");
                            Console.WriteLine("Для выхода из пункта меню введите любой символ. ");
                            Console.ReadKey();
                            break;

                        case 7:
                            Console.Clear();
                            MainMenu.StartMainMenu();
                            break;

                        case 8:
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
