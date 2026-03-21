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
    }
}
