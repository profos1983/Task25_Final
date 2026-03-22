using Library_DB.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DB.InterfaceClasses
{
    public class MenuSpecSelect
    {
        public static void StartMenu() 
        {
            while (true) 
            {
                Console.WriteLine("Меню спец.запросов к БД по заданию 25.5.4. Введите:");
                Console.WriteLine("1  - Получить список книг определенного жанра и вышедших между определенными годами.");
                Console.WriteLine("2  - Получить количество книг определенного автора в библиотеке.");
                Console.WriteLine("3  - Получить количество книг определенного жанра в библиотеке.");
                Console.WriteLine("4  - Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.");
                Console.WriteLine("5  - Получить булевый флаг о том, есть ли определенная книга на руках у пользователя.");
                Console.WriteLine("6  - Получить количество книг на руках у пользователя.");
                Console.WriteLine("7  - Получение последней вышедшей книги.");
                Console.WriteLine("8  - Получение списка всех книг, отсортированного в алфавитном порядке по названию.");
                Console.WriteLine("9  - Получение списка всех книг, отсортированного в порядке убывания года их выхода.");
                Console.WriteLine("10 - Возврат в основно меню.");
                Console.WriteLine("11 - Выход из программы.");

                try
                {
                    int userKey = Convert.ToInt32(Console.ReadLine());
                    switch (userKey)
                    {
                        case 1:
                            BookRepository.SelectBookByJenreYear();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;

                        case 2:
                            BookRepository.SelectSumBookByAuthor();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;

                        case 3:
                            BookRepository.SelectBookByJenre();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.WriteLine("Запрос вернул значение: "+ BookRepository.IsBookExist());
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.WriteLine("Запрос вернул значение: " + BookRepository.IsbookOnUser());
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;

                        case 6:
                            BookRepository.GetSumBookOnUser();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;

                        case 7:
                            BookRepository.GetLastYearBook();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;
                        case 8:
                            BookRepository.GetListBookOrderByTitle();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;

                        case 9:
                            BookRepository.GetListBookOrderByYear();
                            Console.WriteLine("Для выхода из пункта меню введите любой символ.");
                            Console.ReadKey();
                            break;
                        case 10:
                            Console.Clear();
                            MainMenu.StartMainMenu();
                            break;

                        case 11:
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
