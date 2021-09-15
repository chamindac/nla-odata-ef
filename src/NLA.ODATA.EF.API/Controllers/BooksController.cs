using Microsoft.Extensions.Logging;
using NLA.ODATA.EF.API.Data;
using NLA.ODATA.EF.API.Models;

namespace NLA.ODATA.EF.API.Controllers
{
    public class BooksController : NLABaseController<Book, BooksController>
    {
        public BooksController(ILogger<BooksController> logger, BooksDBContext booksDBContext) : base(logger, booksDBContext) { }
        
    }
}
