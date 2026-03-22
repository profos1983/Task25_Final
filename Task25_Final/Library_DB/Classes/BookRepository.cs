using Library_DB.InterfaceClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        // Метод, для добавлениия новой в БД
        public static void InsertBookInBD()
        {
            using (var db = new AppContext())
            {
                var newBook = BookRepository.CreateNewBook();
                try
                {
                    db.Books.Add(newBook);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }


        // удаление книги из БД
        public static void DeleteBookFromDB(int bookId)
        {
            using (var db = new AppContext())
            {
                var bookForDelete = db.Books.Find(bookId);
                if (bookForDelete != null)
                {
                    db.Books.Remove(bookForDelete);
                    db.SaveChanges();
                    Console.WriteLine("Книга с Id=" + bookId + " удалена из БД!");
                }
                else
                {
                    Console.WriteLine("Книга с Id=" + bookId + " не найдена.");
                }
            }
        }

        // Обновление года выпуска книги по Id
        public static void UpdateYearOfRelease(int bookId)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Find(bookId);
                bool success = false;
                int year;

                if (book != null)
                {
                    do
                    {
                        success = false;
                        Console.WriteLine("Введите откорректированный год выпуска книги: ");
                        if (!int.TryParse(Console.ReadLine(), out year))
                        {
                            Console.WriteLine("Необходимо ввести целое число!");
                        }
                        else success = true;
                    }
                    while (success == false);

                    book.ReleaseYear = year;
                    db.Books.Update(book);
                    db.SaveChanges();
                    Console.WriteLine("Год издания книги с Id=" + bookId + " изменено.");
                }
                else
                {
                    Console.WriteLine("Книга с Id=" + bookId + " не найден.");
                }

            }
        }

        // Метод для создания новой книги
        public static Book CreateNewBook()
        {

            bool success = false;
            string bookTitle;
            int bookReleaseYear;
            string bookJenre;
            int bookAmount;
            int bookAuthorId;


            do
            {
                Console.WriteLine("Введите наименование книги: ");
                bookTitle = Console.ReadLine();
                if (bookTitle.IsNullOrEmpty())
                {
                    Console.WriteLine("Наименование не может быть пустым!");
                }
            }
            while (bookTitle.IsNullOrEmpty());


            do
            {
                success = false;
                Console.WriteLine("Введите год издания книги: ");
                if (!int.TryParse(Console.ReadLine(), out bookReleaseYear))
                {
                    Console.WriteLine("Необходимо ввести целое число!");
                }
                else success = true;
            }
            while (success == false);

            do
            {
                Console.WriteLine("Введите жанр книги: ");
                bookJenre = Console.ReadLine();
                if (bookJenre.IsNullOrEmpty())
                {
                    Console.WriteLine("Наименование жанра книги не может быть пустым!");
                }
            }
            while (bookJenre.IsNullOrEmpty());

            do
            {
                success = false;
                Console.WriteLine("Введите количество книг в библиотеке: ");
                if (!int.TryParse(Console.ReadLine(), out bookAmount))
                {
                    Console.WriteLine("Необходимо ввести целое число!");
                }
                else success = true;
            }
            while (success == false);

            do
            {
                success = false;
                List<AuthorIdName> authorIdName = null;
                // Получаем список автор + id из BD
                using (var db = new AppContext())
                {
                    authorIdName =
                        (from a in db.Authors
                         select new AuthorIdName
                         {
                             Id = a.Id,
                             Name = a.Name
                         }
                        ).ToList();
                }
                Console.WriteLine("Cписок имеющихся в БД авторов. Укажите Id автора, который написал книгу: ");

                // Выводим пользователю список авторов, имеющихся в базе данных:
                foreach (var a in authorIdName)
                {
                    Console.WriteLine("Id автора: " + a.Id + "| Имя автора: " + a.Name);
                }

                if (!int.TryParse(Console.ReadLine(), out bookAuthorId))
                {
                    Console.WriteLine("Необходимо ввести целое число!");
                }
                else
                {
                    // поиск введенного числа в списке авторов
                    foreach (var a in authorIdName)
                    {
                        if (a.Id == bookAuthorId)
                        {
                            success = true;
                        }
                    }

                    if (success == false) Console.WriteLine("Введенное число не соответствует имеющимся ID авторов.");
                }
            }
            while (success == false);

            return new Book() { Title = bookTitle, ReleaseYear = bookReleaseYear, Jenre = bookJenre, Amount = bookAmount, AuthorId = bookAuthorId };
        }

        // Метод для поиска книг по жанру вышедших между определенными годами.
        public static void SelectBookByJenreYear()
        {
            int startYear;
            int endYear;
            bool isInt = false;

            Console.WriteLine("Введите название жанра: ");
            string jenre = Console.ReadLine();

            do
            {
                isInt = false;
                Console.WriteLine("Введите начальный год поиска книги по жанру: ");
                if (int.TryParse(Console.ReadLine(), out startYear))
                {
                    isInt = true;
                }
                else Console.WriteLine("Необходимо ввести целое число!.");
            }
            while (isInt == false);

            do
            {
                isInt = false;
                Console.WriteLine("Введите конечный год поиска книги по жанру: ");
                if (int.TryParse(Console.ReadLine(), out endYear))
                {
                    isInt = true;
                }
                else Console.WriteLine("Необходимо ввести целое число!.");
            }
            while (isInt == false);

            using (var db = new AppContext())
            {
                var selectBookByJenreYear =
                    (from a in db.Books
                     where a.Jenre == jenre && (a.ReleaseYear >= startYear && a.ReleaseYear <= endYear)
                     select new
                     {
                         Title = a.Title
                     }
                     ).ToList();

                if (selectBookByJenreYear.Count != 0)
                {
                    foreach (var b in selectBookByJenreYear)
                    {
                        Console.WriteLine(b.Title);
                    }
                }
                else Console.WriteLine("По Вашему запросу ничего не найдено!");
            }
        }

        // Метод получения книг определенного автора в библиотеке
        public static void SelectSumBookByAuthor()
        {
            Console.WriteLine("Введите ФИО автора книг: ");
            string nameAuthor = Console.ReadLine();

            using (var db = new AppContext())
            {
                var result =
                    (from a in db.Authors
                     join b in db.Books on a.Id equals b.AuthorId
                     where a.Name == nameAuthor
                     select
                    b.Amount).Sum();

                Console.WriteLine("Количество книг автора: " + nameAuthor + " равно" + result);

            }
        }

        // Метод получения книг определенного Жанра в библиотеке в библиотеке
        public static void SelectBookByJenre()
        {
            Console.WriteLine("Введите жанр: ");
            string jenre = Console.ReadLine();

            using (var db = new AppContext())
            {
                var sumBookByJenre =
                    (from b in db.Books
                     where b.Jenre == jenre
                     select b.Amount).Sum();

                Console.WriteLine("Количество книг в жанре: " + jenre + " равно " + sumBookByJenre);
            }
        }

        // Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public static bool IsBookExist()
        {
            Console.WriteLine("Введите Имя автора: ");
            string nameAutor = Console.ReadLine();

            Console.WriteLine("Введите название книги: ");
            string title = Console.ReadLine();
            
            using (var db = new AppContext())
            {
                var book =
                    (from b in db.Books
                    join a in db.Authors on b.AuthorId equals a.Id
                    where b.Title == title && a.Name == nameAutor
                    select b.Id).FirstOrDefault();

                if (book != 0) 
                {
                    return true;
                }
                else return false; 
            }

        }

        // Получить булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public static bool IsbookOnUser()
        {
            Console.WriteLine("Введите название книги: ");
            string title = Console.ReadLine();

            Console.WriteLine("Введите ФИО пользователя: ");
            string name = Console.ReadLine();

            using (var db = new AppContext())
            {
                var query =
                    (from a in db.UserBooks
                    join b in db.Books on a.BookId equals b.Id
                    join u in db.Users on a.UserId equals u.Id
                    where b.Title == title && u.Name == name
                    select a.BookId).FirstOrDefault();

                if (query != 0)
                {
                    return true;
                }
                else return false;
            }

        }

        // Получить количество книг на руках у пользователя
        public static void GetSumBookOnUser()
        {
            Console.WriteLine("Введите ФИО пользователя: ");
            string name = Console.ReadLine();

            using (var db = new AppContext())
            {
                var sumBook =
                    (from a in db.UserBooks
                     join u in db.Users on a.UserId equals u.Id
                     where u.Name == name
                     select a.Amount).Sum();

                Console.WriteLine("Количество книг у пользователя: " + name + " равно: " + sumBook);
            }
        }

    }
}
