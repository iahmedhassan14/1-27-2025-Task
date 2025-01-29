using Liberary_Mangement_System;
using Microsoft.VisualBasic;

namespace Liberary_Mangement_System
{

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }

        public Book(string title = "UNKNOWN", string author = "UNKNOWN", string iSBN = "97800000000", bool availability = true)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Availability = availability;
        }
    }

    public class Library
    {
        public List<Book> Collection = new List<Book>();

        public string AddBook(Book book)
        {
            Collection.Add(book);
            return $"{book.Title} Book added successfully!";
        }

        public string SearchBook(string title)
        {
            // Corrected: Find a book based on its title
            Book found = Collection.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (found == null)
            {
                return $"{title} book is not available";
                
            }
            else
            {
                return $"{title} book is available";
            }
        }

        public string BorrowBook(string title)
        {
            Book book = Collection.Find(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null)
            {
                return $"{title} book is not in the library";
            }
            if (!book.Availability)
            {
                return $"{title} book is already borrowed";
            }

            book.Availability = false;
            return $"You have borrowed {book.Title}";
        }

        public string ReturnBook(string title)
        {
            Book book = Collection.Find(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null)
            {
                return $"{title} book is not borrowed";
            }
            if (book.Availability)
            {
                return $"{title} is already available ";
            }

            book.Availability = true;
            return $"successfully returned {book.Title} book";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            Console.WriteLine(library.BorrowBook("Gatsby"));
            Console.WriteLine(library.BorrowBook("1984"));
            Console.WriteLine(library.BorrowBook("Harry Potter")); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            Console.WriteLine(library.ReturnBook("Gatsby"));
            Console.WriteLine(library.ReturnBook("Harry Potter")); // This book is not borrowed

            Console.ReadLine();
        }
    }
}