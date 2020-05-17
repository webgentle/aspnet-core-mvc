using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                Language = model.Language,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };

                return bookDetails;
            }

            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id =1, Title="MVC", Author = "Nitish", Description="This is the description for MVC book", Category="Programming", Language="English", TotalPages=134 },
                new BookModel(){Id =2, Title="Dot Net Core", Author = "Nitish", Description="This is the description for Dot Net Core book", Category="Framework", Language="Chinese", TotalPages=567 },
                new BookModel(){Id =3, Title="C#", Author = "Monika", Description="This is the description for C# book", Category="Developer", Language="Hindi", TotalPages=897 },
                new BookModel(){Id =4, Title="Java", Author = "Webgentle", Description="This is the description for Java book", Category="Concept", Language="English", TotalPages=564 },
                new BookModel(){Id =5, Title="Php", Author = "Webgentle", Description="This is the description for Php book", Category="Programming", Language="English", TotalPages=100 },
                new BookModel(){Id =6, Title="Azure DevOps", Author = "Nitish", Description="This is the description for Azure Devops book", Category="DevOps", Language="English", TotalPages=800 },
            };
        }
    }
}
