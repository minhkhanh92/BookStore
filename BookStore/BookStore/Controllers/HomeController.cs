using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        BookBLL bookBLL = new BookBLL();

        public ActionResult Index()
        {
            List<Book> list = bookBLL.GetListBook();

            return View(list);
        }

        public ActionResult Search(String title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return RedirectToAction("Index");
            }
            List<Book> list = bookBLL.Search(title);
            if (list.Count == 0)
            {
                ViewBag.name = title;
                return View("NotFound");
            }
            return View("Index", list);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            bookBLL.Dispose();
        }
    }
}
