using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibraryBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Приветствие
            Console.WriteLine("Здравствуйте!");
            Console.WriteLine("Вас приветствует приложение для поиска, добавления и удаления книг \nиз электронной библиотеки. \n");
            Console.WriteLine("- Для добавления книги введите 'Добавить'.");
            Console.WriteLine("- Для поиска книги введите 'Найти'.");
            Console.WriteLine("- Для удаления книги введите 'Удалить'.");
            Console.WriteLine("- Для просмотра всего списка книг, хранящихся в библиотеке, \nвведите 'Показать все'.");
            Console.WriteLine("- Для выхода из программы введите 'Выход'.\n");

            //Список для загрузки книг из файла.
            List<Book> bookList = new List<Book>();
            
            //Десериализация данных из файла в список.
            using (var fileStream = new FileStream("books.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    BinaryFormatter bfDiser = new BinaryFormatter();
                    bookList = (List<Book>)bfDiser.Deserialize(fileStream);
                    fileStream.Seek(0, SeekOrigin.Begin);
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    Console.WriteLine("- В данный момент библиотека пуста! Операции 'Найти' и 'Удалить'\nмогут не работать.\n\n");
                }
            }

            string answer = Console.ReadLine();
            Console.WriteLine();

            //Цикл для бесконечной работы, пока пользователь не захочет завершить.
            while (answer != "Выход" && answer != "выход")
            {

                //Добавление книги в список.
                if (answer == "Добавить" || answer == "добавить")
                {
                    Console.WriteLine("Добавление");
                    Console.Write("Введите название книги: ");
                    string bookName = Console.ReadLine();
                    Console.Write("Введите дату публикации (дд.мм.гггг): ");
                    DateTime publicationYear = DateTime.Parse(Console.ReadLine());
                    Console.Write("Введите ФИО автора: ");
                    string Author = Console.ReadLine();

                    Book book = new Book(bookName, publicationYear, Author);
                    bool isAdded = false;

                    foreach (var item in bookList)
                    {
                        if (bookName == item.bookName && publicationYear == item.publicationYear && Author == item.Author)
                        {
                            Console.WriteLine("\n\nУказанная книга уже есть в библиотеке. \nДобавить книгу невозможно.");
                            isAdded = true;
                            break;
                        }
                    }

                    if (!isAdded)
                    {
                        bookList.Add(book);
                        Console.WriteLine("\nКнига успешно добавлена!");
                    }
                }


                //Поиск книги по запросу.
                else if (answer == "Найти" || answer == "найти")
                {
                    Console.WriteLine("Поиск");
                    Console.Write("Введите название книги: ");
                    string searchName = Console.ReadLine();
                    Console.Write("Введите ФИО автора: ");
                    string searchAuthor = Console.ReadLine();
                    Console.WriteLine("\n\n\nПо вашему запросу найдены следующие книги:\n\n");
                    Console.WriteLine("---------------------------------------");

                    //Перебор всего списка на совпадение данных из запроса с содержанием.
                    foreach (var book in bookList)
                    {
                        if (book.bookName == searchName || book.Author == searchAuthor)
                        {
                            Console.WriteLine(book.ToString() + "\n" + "---------------------------------------" + "\n");
                        }
                    }
                }


                //Удаление указанной книги.
                else if (answer == "Удалить" || answer == "удалить")
                {
                    Console.WriteLine("Удаление");
                    Console.Write("Введите название книги: ");
                    string deleteName = Console.ReadLine();
                    Console.Write("Введите дату публикации (дд.мм.гггг): ");
                    DateTime deleteDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Введите ФИО автора: ");
                    string deleteAuthor = Console.ReadLine();

                    bool isDeleted = false;

                    foreach (var book in bookList)
                    {
                        if (book.bookName == deleteName && book.publicationYear == deleteDate && book.Author == deleteAuthor)
                        {
                            int index = bookList.IndexOf(book);
                            bookList.RemoveAt(index);
                            Console.WriteLine("\nКнига успешно удалена.");
                            isDeleted = true;
                            break;
                        }
                    }
                    if (!isDeleted)
                    {
                        Console.WriteLine("\nПо вашему запросу не найдено ни одной книги.");
                    }
                }


                //Показ всех книг в списке
                else if (answer == "Показать все" || answer == "показать все")
                {
                    Console.WriteLine("Все книги, записанные в электронной библиотеке: \n\n");
                    Console.WriteLine("---------------------------------------");
                    foreach (var book in bookList)
                    {
                        Console.WriteLine(book.ToString() + "\n" + "---------------------------------------" + "\n");
                    }
                }


                //Переключение обратно на панель команд, если неверно ввели команду.
                else
                {
                    Console.WriteLine("\nНеверно введена команда. \nПожалуйста, попробуйте еще раз.");
                }

                //Сохранение данных списка с книгами в файл.
                using (var fileStream = new FileStream("books.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter bfSer = new BinaryFormatter();
                    bfSer.Serialize(fileStream, bookList);
                }


                Console.WriteLine("\n\n\n- Для добавления книги введите 'Добавить'.");
                Console.WriteLine("- Для поиска книги введите 'Найти'.");
                Console.WriteLine("- Для удаления книги введите 'Удалить'.");
                Console.WriteLine("- Для просмотра всего списка книг, хранящихся в библиотеке, \nвведите 'Показать все'.");
                Console.WriteLine("- Для выхода из программы введите 'Выход'.\n");
                answer = Console.ReadLine();
                Console.Clear();
            }
        }
    }
}