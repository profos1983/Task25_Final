using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Library_DB.Classes
{
    public class AppContext: DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<Author> Authors { get; set; }

        // К
        public AppContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка составного первичного ключа для таблицы UserBooks
            modelBuilder.Entity<UserBook>()
                .HasKey(ub => new { ub.UserId, ub.BookId });

            // Настройка связей
            modelBuilder.Entity<UserBook>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBooks)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserBook>()
                .HasOne(ub => ub.Book)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(ub => ub.BookId);

            // Настройка первичного ключа для таблицы Autors
            modelBuilder.Entity<Author>()
                .HasKey(a => new{a.Id}); // Устанавливаем первичный ключ
        }


        // Подключение к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MIRONOV;Database=Library_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
