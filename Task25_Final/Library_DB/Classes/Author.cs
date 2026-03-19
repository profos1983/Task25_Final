using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DB.Classes
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Связь с таблией Book
        public ICollection<Book> books { get; set; }
    }
}
