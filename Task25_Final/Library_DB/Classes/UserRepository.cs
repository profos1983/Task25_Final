using Library_DB.InterfaceClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DB.Classes
{
    public class UserRepository
    {
        // выбор пользователя из БД по его идентификатору
        public static void GetUserInfoById(int Id)
        {
            using (var db = new AppContext())
            {
                // Запрос на поиск Пользователя по Id
                var userById = db.Users.Find(Id);
                if (userById is not null)
                {
                    Console.Write("Id Пользователя:    ");
                    Console.WriteLine(userById.Id);
                    Console.Write("Имя пользователя:   ");
                    Console.WriteLine(userById.Name);
                    Console.Write("Email пользователя: ");
                    Console.WriteLine(userById.Email);
                }
                else
                {
                    Console.WriteLine("Пользователь с Id=" + Id + " в базе данных не найден!");
                }
            }
        }
        // Вывод данных по всем пользователям
        public static void GetAllUsersInfo()
        {
            using (var db = new AppContext())
            {
                // Запрос на вывод всех пользователей в список
                var userById = db.Users.ToList();

                foreach (var user in userById)
                {
                    Console.Write("Id: ");
                    Console.Write(user.Id);
                    Console.Write(" Имя: ");
                    Console.Write(user.Name);
                    Console.Write(" Email: ");
                    Console.Write(user.Email);
                    Console.WriteLine();
                }

            }
        }
        // добавление нового пользователя в БД
        public static void InsertUserInBD()
        {
            using (var db = new AppContext())
            {
                var newUser = UserRepository.CreateNewUser();
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
        // удаление пользователя из BD
        public static void DeletetUserFromBD(int userIdForDelete)
        {
            using (var db = new AppContext())
            {
                var userForDelete = db.Users.Find(userIdForDelete);
                if (userForDelete != null)
                {
                    db.Users.Remove(userForDelete);
                    db.SaveChanges();
                    Console.WriteLine("Пользователь с Id=" + userForDelete + " удален из БД!");
                }
                else
                {
                    Console.WriteLine("Пользователь с Id=" + userIdForDelete + " не найден.");
                }
            }
        }
        // Обновление имени пользователя по Id
        public static void UpdatetUserNameById(int userId)
        {
            using (var db = new AppContext())
            {
                var userForUpdateName = db.Users.Find(userId);
                if (userForUpdateName != null)
                {
                    Console.WriteLine("Введите новое имя пользователя: ");
                    string newName = Console.ReadLine();

                    userForUpdateName.Name = newName;
                    db.Users.Update(userForUpdateName);
                    db.SaveChanges();
                    Console.WriteLine("Имя пользователя с Id=" + userId + " изменено!");
                }
                else
                {
                    Console.WriteLine("Пользователь с Id=" + userId + " не найден.");
                }
            }
        }
        // Метод для создания нового пользователя в БД
        public static User CreateNewUser()
        {
            string newUserName;
            string newUserEmail;
            do
            {
                Console.WriteLine("Имя пользователя не может быть пустым! Введите имя пользователя: ");
                newUserName = Console.ReadLine();

                Console.WriteLine("Введите Email пользователя (может отсутствовать у пользователя): ");
                newUserEmail = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(newUserName));

            return new User() { Name = newUserName, Email = newUserEmail };
        }

        // Взять книгу пользователем
        public static void GetBookUser()
        {
            int userId;
            int bookId;
            bool isInt = false;
            bool userFound = false;
            bool bookFound = false;
            User user = null;
            Book book = null;

            // Ввод ID пользователя
            do
            {
                userFound = false;
                do
                {
                    isInt = false;
                    Console.WriteLine("Введите Id пользователя, который берет книгу: ");
                    if (int.TryParse(Console.ReadLine(), out userId))
                    {
                        isInt = true;
                    }
                    else Console.WriteLine("Необходимо ввести целое число!.");
                }
                while (isInt == false);

                // Проверка существования пользователя
                using (var db = new AppContext())
                {
                    user = db.Users.Find(userId);
                    if (user != null)
                    {
                        userFound = true;
                        Console.WriteLine("Пользователь с Id=" + userId + " найден в БД");
                    }
                    else Console.WriteLine("Пользователь с введенным id=" + userId + " не найден.");
                }
            }
            while (!userFound);

            // Ввод ID книги
            do
            {
                bookFound = false;
                do
                {
                    isInt = false;
                    Console.WriteLine("Введите Id книги, которую берет пользователь: ");
                    if (int.TryParse(Console.ReadLine(), out bookId))
                    {
                        isInt = true;
                    }
                    else Console.WriteLine("Необходимо ввести целое число!.");
                }
                while (isInt == false);

                // Проверка существования книги
                using (var db = new AppContext())
                {
                    book = db.Books.Find(bookId);
                    if (book != null)
                    {
                        bookFound = true;
                        Console.WriteLine("Книга с Id=" + bookId + " найдена в библиотеке");
                    }
                    else Console.WriteLine("Книга с введенным id=" + bookId + " не найдена.");
                }
            }
            while (!bookFound);

            // Вывод информации
            Console.WriteLine($"Id пользователя: {user.Id} Имя пользователя: {user.Name}");
            Console.WriteLine($"Id книги: {book.Id} Название книги: {book.Title} жанр: {book.Jenre}");
            Console.WriteLine($"Доступное количество книг: {book.Amount}");

            using (var db = new AppContext())
            {

                var trackedUser = db.Users
                    .Include(u => u.UserBooks)  // Важно: загружаем коллекцию
                    .FirstOrDefault(u => u.Id == userId);

                var trackedBook = db.Books
                    .FirstOrDefault(b => b.Id == bookId);

                if (trackedUser == null || trackedBook == null)
                {
                    Console.WriteLine("Ошибка: пользователь или книга не найдены в текущем контексте");
                    return;
                }

                // Проверяем, достаточно ли книг
                if (trackedBook.Amount <= 0)
                {
                    Console.WriteLine("Извините, книга закончилась!");
                    return;
                }

                // Проверяем, не брал ли пользователь уже эту книгу
                var existingLink = trackedUser.UserBooks
                    .FirstOrDefault(ub => ub.BookId == bookId);

                if (existingLink != null)
                {
                    // Если уже брал, увеличиваем количество
                    existingLink.Amount += 1;
                    Console.WriteLine($"Пользователь уже брал эту книгу. Количество увеличено до {existingLink.Amount}");
                }
                else
                {
                    // Создаем новую связь
                    var userBook = new UserBook
                    {
                        UserId = trackedUser.Id,
                        BookId = trackedBook.Id,
                        Amount = 1
                    };

                    trackedUser.UserBooks.Add(userBook);
                    Console.WriteLine("Создана новая связь пользователь-книга");
                }

                // Уменьшаем количество доступных книг
                trackedBook.Amount -= 1;

                // Сохраняем изменения
                try
                {
                    int changes = db.SaveChanges();
                    Console.WriteLine($"Сохранено изменений: {changes}");
                    Console.WriteLine("Информация о том, что пользователь взял книгу, успешно добавлена.");
                    Console.WriteLine($"Осталось книг: {trackedBook.Amount}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Детали: {ex.InnerException.Message}");
                    }
                }
            }
        }

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

                foreach(var b in selectBookByJenreYear)
                {
                    Console.WriteLine(b.Title);
                }


                //using (var db = new AppContext())
                //{
                //    authorIdName =
                //        (from a in db.Authors
                //         select new AuthorIdName
                //         {
                //             Id = a.Id,
                //             Name = a.Name
                //         }
                //        ).ToList();
            }
        }
    }
}
