using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DB.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Связь с промежуточной таблицей UserBook
        public ICollection<UserBook> UserBooks { get; set; }

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
