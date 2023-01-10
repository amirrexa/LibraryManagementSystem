using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public BookStatus Status { get; private set; }
        public Customer Customer { get; private set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            Status = BookStatus.Available;
        }
        public void UpdateCustomer(Customer customer)
        {
            Customer = customer;
        }
        public void UpdateStatus(BookStatus status)
        {
            Status = status;
        }
    }
}
