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

        public User GetUser(string userName, string password)
        {
            var user = dbc.Users.Where(x => x.UserName == userName && x.Password == password).ToList<User>().FirstOrDefault();
            if (user == null)
                return null;

            return user;
        }

        public T PostObject<T>(T item) where T : class
        {
            try
            {
                dbc.Add<T>(item);

                dbc.SaveChanges();
            }
            catch
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
            catch
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
            catch
            {
                return null;
            }

            return item;
        }

        public List<T> GetObjects<T>() where T : class
        {
            var list = dbc.Set<T>().ToList<T>();

            return list;
        }
    }
}
