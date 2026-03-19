using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DB.Classes
{
    public class UserBook
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Amount { get; set; }
    }
}
