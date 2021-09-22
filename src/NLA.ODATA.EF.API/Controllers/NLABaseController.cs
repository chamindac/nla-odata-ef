using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLA.ODATA.EF.API.Data;
using NLA.ODATA.EF.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLA.ODATA.EF.API.Controllers
{
    public class NLABaseController<T,S> : ODataController where T:BaseEntity<T> where S: ODataController
    {
        protected readonly BooksDBContext _booksDBContext;
        protected readonly ILogger<S> _logger;
        private readonly DbSet<T> dbSet;
        public NLABaseController(ILogger<S> logger, BooksDBContext booksDBContext)
        {
            _logger = logger;
            _booksDBContext = booksDBContext;
            dbSet = _booksDBContext.Set<T>();
        }

        [EnableQuery]
        public virtual IActionResult Get()
        {
            return Ok(_booksDBContext.Set<T>().AsQueryable<T>());
        }

        public virtual IActionResult Post([FromBody] T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            dbSet.Add(entity);
            _booksDBContext.SaveChanges();
            return Created(entity);
        }


        public virtual IActionResult Put(int key, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            dbSet.Update(entity);
            _booksDBContext.SaveChanges();
            return Ok(entity);
        }

        public virtual IActionResult Delete(int key)
        {
            dbSet.Remove(dbSet.Find(key));
            _booksDBContext.SaveChanges();
            return NoContent();
        }
    }
}
