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
                    Console.WriteLine("Пользователь с Id=" + Id + " в базе данных не найден!" );
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
    }
}
