using System;
using System.Collections.Generic;
using System.Text;
using VanPiereWebsite.Data;
using Microsoft.Extensions.Configuration;

namespace VanPiereWebsite.Logic
{
    public class SearchBook
    {
        private readonly IConfiguration _configuration;

        public SearchBook(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Models.BookModel> SearchUnfiltered(int searchKey, string searchInput)
        {
            return new SearchRepository(_configuration).SearchBook(searchKey, searchInput);
        }

        public Models.BookModel ReturnBook(string ISBN)
        {
            return new SearchRepository(_configuration).ReturnBook(ISBN);
        }
    }
}
