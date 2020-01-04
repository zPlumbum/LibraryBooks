using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!");
            Console.WriteLine("Вас приветствует приложение для поиска, добавления и удаления книг из эл. библиотеки. \n");
            Console.WriteLine("Для добавления книги введите 'Добавить'.");
            Console.WriteLine("Для поиска книги введите 'Найти'.");
            Console.WriteLine("Для удаления книги введите 'Удалить'.");
            string answer = Console.ReadLine();

            if (answer == "Добавить" || answer == "добавить")
            {
                Console.WriteLine(5);
            }





            //Book book1 = new Book("Hey, Man!", DateTime.Parse("02.07.2000"), "Kikot");
            //Console.WriteLine(book1.bookName);
            //Console.WriteLine(book1.Author);
            //Console.WriteLine(book1.publicationYear);
            Console.ReadKey();
        }
    }
}
