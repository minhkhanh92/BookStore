using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;

namespace BookStore
{
    public class UserBLL
    {
        private BookStoreEntities db = new BookStoreEntities();

        public bool CreateUser(string username, string password, string email)
        {
            if (db.Users.Find(username) != null)
            {
                return false;
            }
            User newUser = new User();
            newUser.username = username;
            newUser.password = password;
            newUser.email = email;

            db.Users.Add(newUser);
            db.SaveChanges();

            return true;
        }

        public bool IsExist(string username)
        {
            return db.Users.Find(username) != null;
        }

        public bool CheckLogin(string username, string password)
        {
            User user = db.Users.Find(username);
            if (user != null && user.password.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}