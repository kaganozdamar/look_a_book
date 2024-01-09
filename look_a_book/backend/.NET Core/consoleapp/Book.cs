using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consoleapp
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookWriterId { get; set; }
        public string BookImageUrl { get; set; }
        public int BookStock { get; set; }
        public int BookOnSale { get; set; }
        public double BookPrice { get; set; }
        public double BookOldPrice { get; set; }
    }
}