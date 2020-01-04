using System;
using System.Collections.Generic;

namespace LibraryBooks
{
    class Book
    {
        public string bookName { get; }
        public DateTime publicationYear { get; }
        public string Author { get; }

        List<Book> bookList = new List<Book>();

        public Book(string name, DateTime date, string author)
        {
            #region Chec
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название книги не может быть пустым.", nameof(name));
            }

            if (date < DateTime.Parse("01.01.0001") && date > DateTime.Now)
            {
                throw new ArgumentException("Дата публикации не может быть раньше 00.00.0000 или позже сегодняшнего дня.", nameof(date));
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException("Имя автора не может быть пустым.");
            }
            #endregion
            bookName = name;
            publicationYear = date;
            Author = author;
        }

        public override string ToString()
        {
            return bookName;
        }
    }
}
