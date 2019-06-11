using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VanPiereWebsite.Models
{
    public class BookModel
    {
        public string ISBN { get; set; }
        public string Title { get;  set; }
        public string Price { get;  set; }
        public string Author { get;  set; }
        public string AuthorText { get;  set; }
        public string Desc { get;  set; }
        public DateTime PubDate { get;  set; }
        public string Reviews { get;  set; }
        public string Publisher { get;  set; }
        public string PageNmbr { get;  set; }

        public BookModel(string _ISBN, string _Title, string _Price,  string _Author, string _AuthorText, string _Desc, string _PubDate, string _Reviews, string _Publisher, string _PageNmbr)
        {
            ISBN = _ISBN;
            Title = _Title;
            Price = _Price;
            Author = _Author;
            AuthorText = _AuthorText;
            Desc = _Desc;
            PubDate = ToDateTime(_PubDate);
            Reviews = _Reviews;
            Publisher = _Publisher;
            PageNmbr = _PageNmbr;
        }

        private DateTime ToDateTime(string dateString)
        {
            DateTime PubDate = new DateTime(2001, 01, 01);

            if (dateString != null)
            {
                PubDate = DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            }

            return PubDate;
        }

    }
}
