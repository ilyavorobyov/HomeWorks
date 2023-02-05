using System;
using System.Collections.Generic;

namespace ConsoleApp65
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ControlPanel controlPanel= new ControlPanel();
            controlPanel.Work();
        }
    }

    class Book
    {
        public Book(string name, string author, int year)
        {
            Name = name;
            Author = author;
            Year = year;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
    }

    class BookStorage
    {
        private List<Book> _books = new List<Book>();

        public BookStorage()
        {
            _books.Add(new Book("Мастер и Маргарита", "Михаил Булгаков", 1929));
            _books.Add(new Book("Мёртвые души", "Николай Гоголь", 1842));
            _books.Add(new Book("Граф Монте-Кристо", "Александр Дюма", 1844));
            _books.Add(new Book("Война и мир", "Лев Толстой", 1865));
        }

        public void AddBook()
        {
            string userInput;
            string bookName;
            string author;
            int year;

            Console.Write("Введите название книги: ");
            bookName = Console.ReadLine();
            Console.Write("Введите автора книги: ");
            author = Console.ReadLine();
            Console.Write("Введите год написания книги: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out year) && bookName != null && author != null)
            {
                _books.Add(new Book(bookName, author, year));
                Console.WriteLine("Книга успешно добавлена");
            }
            else
            {
                Console.WriteLine("Данные введены неверно, попробуй ещё раз");
            }
        }

        public void ShowAllBooks()
        {
            foreach (var book in _books)
            {
                Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.Year}");
            }
        }

        public void DeleteBook()
        {
            int numberToDecrease = 1;
            string userInput;
            int bookNumber;
            Console.Write("Введите номер той книги, которую хотите удалить: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out bookNumber))
            {
                if (bookNumber > 0 && bookNumber <= _books.Count)
                {
                    _books.Remove(_books[bookNumber - numberToDecrease]);
                    Console.WriteLine("Книга успешно удалена");
                }
                else
                {
                    Console.WriteLine("Книги с таким номером нет");
                }
            }
            else
            {
                Console.WriteLine("Данные введены неверно, попробуй ещё раз");
            }
        }

        public void SelectDesiredOption()
        {
            const string FindBookByAuthorCommand = "1";
            const string FindBookByNameCommand = "2";
            const string FindBookByYearCommand = "3";
            const string ToMenuCommand = "4";

            Console.Clear();
            Console.WriteLine($"Введите команду:\n{FindBookByAuthorCommand} - Найти книгу по автору \n{FindBookByNameCommand} - Найти книгу по имени \n{FindBookByYearCommand} - Найти книгу по году\n{ToMenuCommand} - Вернуться в меню");
            Console.Write("Введите команду: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case FindBookByAuthorCommand:
                    FindBookByAuthor();
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case FindBookByNameCommand:
                    FindBookByName();
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case FindBookByYearCommand:
                    FindBookByYear();
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case ToMenuCommand:
                    break;
            }
        }

        private void FindBookByAuthor()
        {
            bool isHaveBook = false;
            Console.WriteLine("Введите имя нужного автора: ");
            string author = Console.ReadLine();

            foreach (var book in _books)
            {
                if (author.ToLower() == book.Author.ToLower())
                {
                    Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.Year}");
                    isHaveBook = true;
                }
            }

            if (isHaveBook == false)
            {
                Console.WriteLine("Таких книг нет");
            }
        }

        private void FindBookByName()
        {
            bool isHaveBook = false;
            Console.WriteLine("Введите нужное название книги: ");
            string bookName = Console.ReadLine();

            foreach (var book in _books)
            {
                if (bookName.ToLower() == book.Name.ToLower())
                {
                    Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.Year}");
                    isHaveBook = true;
                }
            }

            if (isHaveBook == false)
            {
                Console.WriteLine("Таких книг нет");
            }
        }

        private void FindBookByYear()
        {
            bool isHaveBook = false;
            Console.WriteLine("Введите нужный год книги: ");
            int bookYear;
            string input = Console.ReadLine();

            if (int.TryParse(input, out bookYear))
            {
                foreach (var book in _books)
                {
                    if (bookYear == book.Year)
                    {
                        Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.Year}");
                        isHaveBook = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Введена неправильная информация, попробуйте ещё раз");
            }

            if (isHaveBook == false)
            {
                Console.WriteLine("Таких книг нет");
            }
        }
    }

    class ControlPanel
    {
        public void Work()
        {
            const string AddBookCommand = "1";
            const string DeleteBookCommand = "2";
            const string ShowAllBooksCommand = "3";
            const string ShowBooksByParameterCommand = "4";
            const string ExitCommand = "5";

            BookStorage bookStorage = new BookStorage();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Хранилище книг:\n{AddBookCommand} Добавить книгу \n{DeleteBookCommand} Удалить книгу " +
                    $"\n{ShowAllBooksCommand} Показать все книги\n{ShowBooksByParameterCommand} Показать книги по нужному параметру" +
                    $"\n{ExitCommand} Завершить выполнение программы");
                Console.Write("Введите команду: ");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case AddBookCommand:
                        bookStorage.AddBook();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case DeleteBookCommand:
                        bookStorage.DeleteBook();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ShowAllBooksCommand:
                        bookStorage.ShowAllBooks();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ShowBooksByParameterCommand:
                        bookStorage.SelectDesiredOption();
                        Console.Clear();
                        break;

                    case ExitCommand:
                        Console.WriteLine("Выход из программы успешно выполнен.");
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка. Введена неправильная команда. Попробуй ещё раз");
                        break;
                }
            }
        }
    }
}