using System;
using System.Collections.Generic;
using System.Text;
using VanPiereWebsite.Models;
using Microsoft.Extensions.Configuration;

namespace VanPiereWebsite.Data
{
    public interface ISearchContext
    {
        List<BookModel> SearchBook(int searchKey, string searchInput);

        BookModel ReturnBook(string ISBN);
    }
}
