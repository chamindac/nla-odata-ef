using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Logging;
using NLA.ODATA.EF.API.Data;
using NLA.ODATA.EF.API.Models;

namespace NLA.ODATA.EF.API.Controllers
{
    // remove web api routing to allow OData routing
    //[ApiController]
    //[Route("[controller]/api")]
    public class BooksController : ODataController
    {
        private readonly BooksDBContext _booksDBContext;
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger, BooksDBContext booksDBContext)
        {
            _logger = logger;
            _booksDBContext = booksDBContext;
        }

        [EnableQuery]
        //[HttpGet("books")] // remove web api routing to allow OData routing
        public IActionResult Get() 
        {
            return Ok(_booksDBContext.Books.AsQueryable());
        }

        public IActionResult Post([FromBody] Book book)
        {
            _booksDBContext.Books.Add(book);
            _booksDBContext.SaveChanges();
            return Created(book);
        }


        public IActionResult Put(int key, [FromBody] Book book)
        {
            _booksDBContext.Books.Update(book);
            _booksDBContext.SaveChanges();
            return Updated(book);
        }

        public IActionResult Delete(int key)
        {
            _booksDBContext.Books.Remove(_booksDBContext.Books.Find(key));
            _booksDBContext.SaveChanges();
            return NoContent();
        }
    }
}
