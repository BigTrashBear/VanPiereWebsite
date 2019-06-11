using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace VanPiereWebsite.Data
{
    public class SearchRepository
    {
        private readonly ISearchContext _context;

        public SearchRepository(IConfiguration configuration)
        {
            _context = new SearchXMLContext(configuration);
        }

        public List<Models.BookModel> SearchBook(int searchKey, string searchInput)
        {
            return _context.SearchBook(searchKey, searchInput);
        }

        public Models.BookModel ReturnBook(string ISBN)
        {
            return _context.ReturnBook(ISBN);
        }
    }
}
