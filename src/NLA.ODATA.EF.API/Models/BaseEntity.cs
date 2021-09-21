using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NLA.ODATA.EF.API.Models
{
    public class BaseEntity<T> : IEntityTypeConfiguration<T> where T : class
    {
        [ConcurrencyCheck]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public uint xmin { get; set; }

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.UseXminAsConcurrencyToken();
        }
    }
}
