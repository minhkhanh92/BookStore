using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore
{
    public class BookBLL
    {
        BookStoreEntities db = new BookStoreEntities();

        public List<Book> GetListBook()
        {
            return db.Books.ToList();
        }

        public List<Book> Search(string title)
        {
            var query = from b in db.Books
                        where b.title.ToLower().Contains(title.ToLower().Trim())
                        select b;

            return query.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}