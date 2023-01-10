using LibraryManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business
{
    public class LibraryManager
    {
        public List<Book> books { get; private set; }
        public LibraryManager()
        {
            books = new List<Book>()
            {
                new Book("Deathless","Catherynne M. Valente"),
                new Book("Ash","Malinda Lo"),
                new Book("Atonement ","Ian McEwan"),
                new Book("Battleborn","Claire Vaye Watkins"),
                new Book("Beloved","Toni Morrison"),
                new Book("Celine","Peter Heller"),
                new Book("Duplex","Kathryn Davis")
            };
        }
        public void BorrowBook(Customer customer, Book book)
        {
            if (book.Status == BookStatus.Available)
            {
                book.UpdateStatus(BookStatus.Unavailable);
                book.UpdateCustomer(customer);
            }
            else
            {
                throw new Exception($"{book.Title} is already borrowed by {book.Customer}.");
            }
        }

        public void ReturnBook(Customer customer, Book book)
        {
            if (book.Customer == customer)
            {
                book.UpdateStatus(BookStatus.Available);
                book.UpdateCustomer(null);
            }
            else
            {
                throw new Exception("Book is not borrowed by anyone.");
            }
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public List<Book> GetAvailableBooks()
        {
            return books.Where(b => b.Status == BookStatus.Available).ToList();
        }

        public List<string> GetBookTitles(string author)
        {
            return books
                .Where(b => b.Author == author)
                .OrderBy(b => b.Status)
                .Select(b => b.Title).ToList();
        }

        public List<Book> GetUnavailableBooks()
        {
            return books.Where(b => b.Status == BookStatus.Unavailable).ToList();
        }


        public void ShowAllBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{books.IndexOf(book) + 1} | {book.Title} | {book.Author} | {book.Status}");
            }
        }
        public void ShowAllBooks(List<Book> books) //Can receive LINQ extension methods
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{books.IndexOf(book) + 1} | {book.Title} | {book.Author} | {book.Status}");
            }
        }
    }
}
