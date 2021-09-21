using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NLA.ODATA.EF.API.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Author: BaseEntity<Author>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(250)]
        public string Email { get; set; }
        public ICollection<Book> Books{ get; set; }
    }
}
