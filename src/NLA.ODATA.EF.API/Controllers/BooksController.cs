using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLA.ODATA.EF.API.Data;
using NLA.ODATA.EF.API.Models;
using System.Linq;

namespace NLA.ODATA.EF.API.Controllers
{
    public class BooksController : NLABaseController<Book, BooksController>
    {
        public BooksController(ILogger<BooksController> logger, BooksDBContext booksDBContext) : base(logger, booksDBContext) { }

        [HttpPost]
        public IActionResult AddRating([FromODataUri] int key, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Book book = _booksDBContext.Books.Find(key);
            book.Rating = (int)parameters["Rating"];
            _booksDBContext.Books.Update(book);
            _booksDBContext.SaveChanges();
            return new JsonResult(book);
        }

        [HttpGet]
        public IActionResult BestSelling()
        {
            Book book = _booksDBContext.Books.Where(b => b.Rating > 0).OrderBy(b => b.Rating).Include(b => b.Author).FirstOrDefault();
            return new JsonResult(book);
        }

        // unbound sample
        [HttpGet("/odata/GetTotalBookSalesValue(BookCategory={BookCategory})")]
        public IActionResult GetTotalBookSalesValue([FromODataUri] int BookCategory)
        {
            double fakeBookSalesForCategory = 12500.52;
            return Ok(fakeBookSalesForCategory);
        }
    }
}
