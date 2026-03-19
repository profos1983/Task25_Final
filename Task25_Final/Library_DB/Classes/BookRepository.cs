using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DB.Classes
{
    public class BookRepository
    {
        // выбор книги из БД по его идентификатору
        public static void GetBookInfoById(int Id)
        {
            using (var db = new AppContext())
            {
                // Запрос на поиск Пользователя по Id
                var bookById = db.Books.Find(Id);
                if (bookById is not null)
                {
                    Console.Write("Id Книги:           ");
                    Console.WriteLine(bookById.Id);
                    Console.Write("Наименование книги: ");
                    Console.WriteLine(bookById.Title);
                    Console.Write("Год выпуска:        ");
                    Console.WriteLine(bookById.ReleaseYear);
                    Console.Write("Жанр:               ");
                    Console.WriteLine(bookById.Jenre);
                    Console.Write("Количество:         ");
                    Console.WriteLine(bookById.Jenre);
                }
                else
                {
                    Console.WriteLine("Книга с Id=" + Id + " в базе данных не найден!");
                }

            }
        }

        // Вывод информации о всех книгах

        public static void GetAllBooksInfo()
        {
            using (var db = new AppContext())
            {
                // Запрос на вывод всех пользователей в список
                var allBook = db.Books
                    .Include(b => b.Author)
                    .ToList();

                foreach (var book in allBook)
                {
                    Console.Write("Id: ");
                    Console.Write(book.Id);
                    Console.Write(" Название: ");
                    Console.Write(book.Title);
                    Console.Write(" Год издания: ");
                    Console.Write(book.ReleaseYear);
                    Console.Write(" Жанр: ");
                    Console.Write(book.Jenre);
                    Console.Write(" Количество: ");
                    Console.Write(book.Amount);
                    Console.Write(" Автор: ");
                    Console.Write(book.Author.Name);
                    Console.WriteLine();

                }

            }
        }
        // добавление книги в БД

        // удаление книги из БД

        // Обновление года выпуска книги по Id

    }
}
