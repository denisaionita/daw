using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.FrontendModels;
using ProiectDAW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace ProiectDAW.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/books")]
    public class BookController : Controller
    {
        private BDRepo _repo = new BDRepo();

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] BookContent bookContent)
        {
            var book = new Book();
            book.BookId = _repo.GenerateIdBookList();
            book.Author = bookContent.Author;
            book.Title = bookContent.Title;
            book.Year = bookContent.Year;
            book.Description = bookContent.Description;
            book.ISBN = bookContent.ISBN;
            book.Language = bookContent.Language;

            if (bookContent.Genres.Count() != 0 && bookContent.Genres != null)
            {
                foreach (var genre in bookContent.Genres)
                {
                    genre.Id = _repo.GenerateIdGenreList();
                    genre.BookId = book.BookId;
                    _repo.PostObject<GenreList>(genre);
                }
            }

            bookContent.BookId = book.BookId;
            var result = _repo.PostObject<Book>(book);
            if (result != null)
            {
                return Ok(bookContent);
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("{bookId}/update")]
        public IActionResult Update([FromBody] BookContent book, string bookId)
        {
            var existingBook = _repo.GetBook(bookId);
            var genres = _repo.GetGenresForBook(bookId);
            if (existingBook == null)
            {
                return NoContent();
            }

            existingBook.Author = book.Author ?? existingBook.Author;
            existingBook.Title = book.Title ?? existingBook.Title;
            existingBook.Year = book.Year ?? existingBook.Year;
            existingBook.Description = book.Description ?? existingBook.Description;
            existingBook.ISBN = book.ISBN ?? existingBook.ISBN;
            existingBook.Language = book.Language ?? existingBook.Language;

            if (book.Genres != null && book.Genres.Count() != 0 )
            {
                // delete existing genres if they exist:
                var existingGenres = _repo.GetGenresForBook(bookId);
                 foreach (var genre in existingGenres)
                    {
                        _repo.DeleteObject<GenreList>(genre);
                    }

                    foreach (var genre in book.Genres)
                    {
                        genre.Id = _repo.GenerateIdGenreList();
                        genre.BookId = bookId;
                        _repo.PostObject<GenreList>(genre);
                    }
            }
            book.BookId = bookId;
            var result = _repo.PutObject<Book>(existingBook);
            return Ok(book);
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("{bookId}/delete")]
        public IActionResult Delete(string bookId)
        {
            var existingBook = _repo.GetBook(bookId);
            var genres = _repo.GetGenresForBook(bookId);
            if (existingBook == null)
            {
                return NotFound();
            }
            var result = _repo.DeleteObject<Book>(existingBook);

            foreach (var genre in genres)
            {
                _repo.DeleteObject<GenreList>(genre);
            }

            if (result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var booksList = new List<BookContent>();
            var books = _repo.GetBooks(filterByGenre: false, genre: null);
            foreach (var book in books)
            {
                var bookContent = new BookContent();
                bookContent.Author = book.Author;
                bookContent.Title = book.Title;
                bookContent.Year = book.Year;
                bookContent.Description = book.Description;
                bookContent.ISBN = book.ISBN;
                bookContent.BookId = book.BookId;

                var genres = _repo.GetGenresForBook(book.BookId);
                bookContent.Genres = genres;
                booksList.Add(bookContent);
            }
            return Ok(booksList);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("filterBy/{genre}")]
        public IActionResult GetAllByGenre(string genre)
        {
            var booksList = new List<BookContent>();
            var books = _repo.GetBooks(filterByGenre: true, genre: genre);
            foreach (var book in books)
            {
                var bookContent = new BookContent();
                bookContent.Author = book.Author;
                bookContent.Title = book.Title;
                bookContent.Year = book.Year;
                bookContent.Description = book.Description;
                bookContent.ISBN = book.ISBN;
                bookContent.BookId = book.BookId;

                var genres = _repo.GetGenresForBook(book.BookId);
                bookContent.Genres = genres;

                booksList.Add(bookContent);
            }
            return Ok(booksList);
        }
    }
}

