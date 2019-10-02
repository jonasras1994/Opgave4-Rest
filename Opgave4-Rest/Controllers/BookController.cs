using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;
using ModelLib.Model;

namespace Opgave4Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static readonly List<Book> books = new List<Book>()
        {
            new Book("Harry Potter", "J.K. Rowling", 99, "1234567890123"),
            new Book("Ringenes Herre", "J.K.K. Tolkien", 80, "9876543210987"),
            new Book("Da Vinci Mysteriet", "Dan Brown", 70, "5297430972567"),
        };
        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET: api/Book/5
        [HttpGet("{isbn13}", Name = "Get")]
        public Book Get(string isbn13)
        {
            return books.Find(i => i.Isbn13 == isbn13);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            books.Add(value);
        }

        // PUT: api/Book/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Book value)
        {
            Book book = Get(isbn13);
            if (book!= null)
            {
                book.Title = value.Title;
                book.Writer = value.Writer;
                book.Pages = value.Pages;
                book.Isbn13 = value.Isbn13;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Book book = Get(isbn13);
            books.Remove(book);
        }
    }
}
