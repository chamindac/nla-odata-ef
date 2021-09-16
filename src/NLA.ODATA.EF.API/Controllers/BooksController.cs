using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.Extensions.Logging;
using NLA.ODATA.EF.API.Data;
using NLA.ODATA.EF.API.Models;

namespace NLA.ODATA.EF.API.Controllers
{
    public class BooksController : NLABaseController<Book, BooksController>
    {
        public BooksController(ILogger<BooksController> logger, BooksDBContext booksDBContext) : base(logger, booksDBContext) { }

        //[HttpPost("({key})/AddRating")]
        [HttpPost]
        public IActionResult AddRating([FromODataUri] int key, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Book book = _booksDBContext.Books.Find(key);
            book.Rating = (int)parameters["Rating"];
            _booksDBContext.Books.Update(book);
            _booksDBContext.SaveChanges();
            return Ok();
        }
    }
}
