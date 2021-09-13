using Microsoft.EntityFrameworkCore;
using NLA.ODATA.EF.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLA.ODATA.EF.API.Data
{
    public class BooksDBContext : DbContext
    {
        public BooksDBContext() : base() { }
        public BooksDBContext(DbContextOptions<BooksDBContext> options) : base(options) { }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BooksDBContext).Assembly);
        }
    }
}

