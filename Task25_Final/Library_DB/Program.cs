using Library_DB.Classes;
using Library_DB.InterfaceClasses;
using System.Runtime.Intrinsics.X86;
using AppContext = Library_DB.Classes.AppContext;



// Запускаем интерфейс
MainMenu.StartMainMenu();

// Создание таблицы Users и добавление в нее пользователей
//using (var db = new AppContext()) 
//{
//    var user1 = new User { Name = "Алексей М", Email = "123@male.ru" };
//    var user2 = new User { Name = "Николай Н", Email = "321@male.ru" };

//    db.Users.Add(user1);
//    db.Users.Add(user2);
//    db.SaveChanges();
//    Console.WriteLine("Блок 1 отработал");
//}

//// Создание таблицы Авторы и добавление в нее пользователей
//using (var db = new AppContext())
//{
//    var autor1 = new Author { Name = "Толстой" };
//    var autor2 = new Author { Name = "Достоевский" };

//    db.Authors.Add(autor1);
//    db.Authors.Add(autor2);
//    db.SaveChanges();
//    Console.WriteLine("Блок 2 отработал");
//}

// Создание таблицы books и добавление в нее пользователей
//using (var db = new AppContext())
//{
//    var book1 = new Book { Title = "Война и мир", ReleaseYear = 1865, Jenre = "Роман", AuthorId = 1, Amount = 4};
//    var book2 = new Book { Title = "Преступление и наказание", ReleaseYear = 1866, Jenre ="Роман", AuthorId = 2, Amount = 10 };
//    db.Books.Add(book1);
//    db.Books.Add(book2);
//    db.SaveChanges();
//    Console.WriteLine("Блок 3 отработал");
//}

