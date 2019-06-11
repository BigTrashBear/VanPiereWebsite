using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VanPiereWebsite.Logic;
using VanPiereWebsite.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Web;
using Newtonsoft.Json;

namespace VanPiereWebsite.Controllers.Books
{
    public class BookController : Controller
    {
        SearchBook logic;
        List<BookModel> books;
        private readonly IConfiguration _configuration;

        public BookController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(int searchKey, string searchInput)
        {
            books = new List<BookModel>();
            books.Clear();

            logic = new SearchBook(_configuration);
                                
            books = logic.SearchUnfiltered(searchKey, searchInput);
          
            return RedirectToAction("ViewBooks", new { _foundbooks = JsonConvert.SerializeObject(books as List<BookModel>)});
        }

        public IActionResult ViewBook(string ISBN)
        {
            logic = new SearchBook(_configuration);
            Models.BookModel book = logic.ReturnBook(ISBN);

            return View("ViewBook", book);
        }

        public IActionResult ViewBooks(string _foundbooks)
        {
            List<BookModel> foundbookslist = JsonConvert.DeserializeObject<List<BookModel>>(_foundbooks).ToList();
            List<BookModel> foundbooks = foundbookslist;

            return View("ViewBooks", foundbooks);
        }
    }
}