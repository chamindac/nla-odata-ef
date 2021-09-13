using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Logging;
using NLA.ODATA.EF.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLA.ODATA.EF.API.Controllers
{
    public class AuthorsController : ControllerBase
    {
        private readonly BooksDBContext _booksDBContext;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(ILogger<AuthorsController> logger, BooksDBContext booksDBContext)
        {
            _logger = logger;
            _booksDBContext = booksDBContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_booksDBContext.Authors.AsQueryable());
        }
    }
}
