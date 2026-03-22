using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DB.Classes
{
    public class Book
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Jenre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int Amount { get; set; }
        

        // Связь с промежуточной таблицей UserBook 
        public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();
    }
}

