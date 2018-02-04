using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repository
{
    public class BDRepo
    {
        private ApplicationDBContext dbc = new ApplicationDBContext();

        public User GetUser(string username, bool checkpassword, string password)
        {
            var user = new User();

            if (checkpassword)
            {
                user = dbc.Users.Where(x => x.Username == username && x.Password == password).ToList<User>().FirstOrDefault();
            }
            else
            {
                try
                {
                    user = dbc.Users.Where(x => x.Username == username).ToList<User>().FirstOrDefault();
                }
                catch
                {
                    return null;
                }

            }

            return user;
        }


        public List <Book> GetBooks ( bool filterByGenre, string genre)
        {
            var books = new List<Book>();
            if(filterByGenre)
            {
                var bookIds = dbc.GenreLists.Where(x => x.BookGenre == genre).Select(x => x.BookId).ToList();
                foreach (var id in bookIds)
                {
                    var book = dbc.Books.Where(x => x.BookId == id).ToList<Book>().FirstOrDefault();
                    if (book != null)
                    {
                        books.Append(book);
                    }
                }
            }
            else
            {
                books = GetObjects<Book>();
            }
            return books;
        }

        public Book GetBook(string bookId)
        {
            try
            {
                var book = dbc.Books.Where(x => x.BookId == bookId).ToList<Book>().FirstOrDefault();

                return book;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string GenerateIdBookList()
        {
            var nextNumber = dbc.Books.OrderByDescending(x => Int32.Parse(x.BookId)).FirstOrDefault();

            if (nextNumber == null)
                return "1";

            return (Int32.Parse(nextNumber.BookId) + 1).ToString();
        }

        public Wishlist GetWishlist(string email)
        {
            var wishlist = new Wishlist();


            return wishlist;
        }

        public T PostObject<T>(T item) where T : class
        {
            try
            {
                dbc.Add<T>(item);

                dbc.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }

            return item;
        }

        public T PutObject<T>(T item) where T : class
        {
            try
            {
                dbc.Update<T>(item);

                dbc.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }

            return item;
        }

        public T DeleteObject<T>(T item) where T : class
        {
            try
            {
                dbc.Remove<T>(item);

                dbc.SaveChanges(); 

            }
            catch(Exception e)
            {
                return null;
            }

            return item;
        }

        public List<T> GetObjects<T>() where T : class
        {
            try
            {
                var list = dbc.Set<T>().ToList<T>();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
