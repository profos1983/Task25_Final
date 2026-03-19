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
        // добавление пользователя в БД
        public static void InsertUserInBD() 
        {
            using (var db = new AppContext())
            {
                var newUser = User.CreateNewUser();
                db.Users.Add(newUser);
                db.SaveChanges();

            }
        }
        // удаление пользователя из БД
        // Обновление имени пользователя по Id
    }
}
