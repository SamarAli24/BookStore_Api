using BookShop.Db;
using BookShop.Dto;
using BookShop.Entities;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace BookShop
{
    public class BookService
    {
        private AppDbAccess _context;

        public BookService(AppDbAccess context)
        {
            _context = context;

        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(x=>x.Id== bookId);
        }


        public void AddBookRepo(BookModel bookObj)
        {
            var _book = new Book()
            {
                Title = bookObj.Title,
                Description= bookObj.Description,
                IsRead= bookObj.IsRead,
                Rate= bookObj.Rate, 
                Author= bookObj.Author,
            };

            _context!.Add(_book); 
           _context.SaveChanges();
             

        }

        public Book UpdateBookRepo(int bookId,BookModel bookObj)
        {
            var _book = _context.Books.FirstOrDefault(x=>x.Id==bookId);
            if (_book!= null)
            {
                _book.Title = bookObj.Title;
                _book.Description = bookObj.Description;
                _book.IsRead = bookObj.IsRead;
                _book.Rate = bookObj.Rate;
                _book.Author = bookObj.Author;
            }
            

            _context!.Update(_book);
            _context.SaveChanges();

            return _book;
        }

        public int DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if (_book != null)
            {
                _book.Id = bookId;


            }
            _context.Remove(_book);
            return _context.SaveChanges();

        }




    }
}
