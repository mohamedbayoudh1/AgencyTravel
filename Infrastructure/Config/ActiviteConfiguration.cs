using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class ActiviteConfiguration : IEntityTypeConfiguration<Activite>
    {
        public void Configure(EntityTypeBuilder<Activite> builder)
        {
            builder.OwnsOne(a => a.Zone);
        }
    }
}
