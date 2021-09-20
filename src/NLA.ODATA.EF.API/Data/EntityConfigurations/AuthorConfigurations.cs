using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLA.ODATA.EF.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLA.ODATA.EF.API.Data.EntityConfigurations
{
    public class AuthorConfigurations : BaseEntityConfigurations<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder); // Must call this

            // other configurations here
        }
    }
}
