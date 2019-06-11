using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Microsoft.Extensions.Configuration;
using System.Globalization;


namespace VanPiereWebsite.Data
{
    public class SearchXMLContext : ISearchContext
    {
        
        XmlDocument XmlDoc;
        XmlNode root;
        private string searchKeyString;
        private List<string> searchKeys;
        private readonly IConfiguration _configuration;

        public SearchXMLContext(IConfiguration configuration)
        {
            _configuration = configuration;

            XmlDoc = new XmlDocument();
            XmlDoc.Load(@"c:\\Users\Alex\source\repos\VanPiereWebsite\ClassLibrary1\BookTest.xml");
            root = XmlDoc.DocumentElement;
            ManageKeyList();
        }

        public List<Models.BookModel> SearchBook(int searchKey, string searchInput)
        {
            List<Models.BookModel> booklist = new List<Models.BookModel>();
            
            searchKeyString = searchKeys[searchKey - 1];
          
            XmlNodeList returnnodes = null;
          
            if (searchKey == 1)
            {
                returnnodes = root.SelectNodes($"//Product/{searchKeyString}[text()='{searchInput}']/ancestor::Product");
            }
            else
            {
                returnnodes = root.SelectNodes($"//Product/{searchKeyString}[contains(text(),'{searchInput}')]/ancestor::Product"); 
            }

            
            if (returnnodes != null)
            {
                for (int i = 0; i < returnnodes.Count; i ++)
                {
                    var BkISBN = returnnodes[i].SelectSingleNode($".//RecordReference/text()").Value;
                    var Title = returnnodes[i].SelectSingleNode($".//Title/TitleText/text()").Value;
                    var Price = returnnodes[i].SelectSingleNode($".//Price/PriceAmount/text()").Value;
                    var Author = returnnodes[i].SelectSingleNode($".//PersonNameInverted/text()").Value;
                    var AuthorText = returnnodes[i].SelectSingleNode($".//OtherText[TextTypeCode=13]/Text/text()").Value;
                    var Desc = returnnodes[i].SelectSingleNode($".//OtherText[TextTypeCode=18]/Text/text()").Value;
                    var Reviews = returnnodes[i].SelectSingleNode($".//OtherText[TextTypeCode=08]/Text/text()").Value;
                    var PubDate = returnnodes[i].SelectSingleNode($".//PublicationDate/text()").Value;
                    var Publisher = returnnodes[i].SelectSingleNode($".//Publisher/PublisherName/text()").Value;
                    var PageNmbr = returnnodes[i].SelectSingleNode($".//NumberOfPages/text()").Value;

                    booklist.Add(new Models.BookModel(BkISBN, Title, Price, Author, AuthorText, Desc, PubDate, Reviews, Publisher, PageNmbr));
                }

                return booklist;
            }
            else 
            {
                return null;
            }
        }

        public Models.BookModel ReturnBook(string ISBN)
        {
            Models.BookModel book = null;
            
            searchKeyString = searchKeys[0];
            XmlNode returnnode = root.SelectSingleNode($"//Product/{searchKeyString}[text()='{ISBN}']/ancestor::Product");

            if (returnnode != null)
            {
                var BkISBN = returnnode.SelectSingleNode($".//RecordReference/text()").Value;
                var Title = returnnode.SelectSingleNode($".//Title/TitleText/text()").Value;
                var Price = returnnode.SelectSingleNode($".//Price/PriceAmount/text()").Value;
                var Author = returnnode.SelectSingleNode($".//PersonNameInverted/text()").Value;
                var AuthorText = returnnode.SelectSingleNode($".//OtherText[TextTypeCode=13]/Text/text()").Value;
                var Desc = returnnode.SelectSingleNode($".//OtherText[TextTypeCode=18]/Text/text()").Value;
                var Reviews = returnnode.SelectSingleNode($".//OtherText[TextTypeCode=08]/Text/text()").Value;
                var PubDate = returnnode.SelectSingleNode($".//PublicationDate/text()").Value;
                var Publisher = returnnode.SelectSingleNode($".//Publisher/PublisherName/text()").Value;
                var PageNmbr = returnnode.SelectSingleNode($".//NumberOfPages/text()").Value;

                book = new Models.BookModel(BkISBN, Title, Price, Author, AuthorText, Desc, PubDate, Reviews, Publisher, PageNmbr);
            }
            return book;
        }

        private void ManageKeyList()
        {
            searchKeys = new List<string>();
            searchKeys.Add("RecordReference");
            searchKeys.Add("Title/TitleText");
            searchKeys.Add("Contributor/PersonName");
        }
    }
}
