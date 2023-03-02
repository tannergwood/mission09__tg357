using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;
using OnlineBookstore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreRepository repo { get; set; }

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }


        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            //load up books view model
            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);
        }
    }
}
