using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Logging;
using NLA.ODATA.EF.API.Data;
using NLA.ODATA.EF.API.Models;

namespace NLA.ODATA.EF.API.Controllers
{
    public class AuthorsController : NLABaseController<Author, AuthorsController, BooksDBContext>
    {

        public AuthorsController(ILogger<AuthorsController> logger, BooksDBContext booksDBContext) : base(logger, booksDBContext) { }

        //[EnableQuery]
        //public override IActionResult Get()
        //{
        //    return Ok(_booksDBContext.Authors.AsQueryable());
        //}
    }
}
