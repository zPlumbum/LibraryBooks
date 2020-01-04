using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Hey, Man!", DateTime.Parse("02.07.2000"), "Kikot");
            Console.WriteLine(book1.bookName);
            Console.WriteLine(book1.Author);
            Console.WriteLine(book1.publicationYear);
            Console.ReadKey();
        }
    }
}
