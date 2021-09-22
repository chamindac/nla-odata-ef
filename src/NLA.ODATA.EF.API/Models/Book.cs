using Microsoft.EntityFrameworkCore;
using NLA.ODATA.EF.API.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NLA.ODATA.EF.API.Models
{
    [Index(nameof(ISBN), IsUnique = true)]
    public class Book:BaseEntity<Book>
    {
        //updatable, insert only fields how to
        // uppercase checks
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        [Uppercase]
        public string ISBN { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int Rating { get; set; }
    }
}
