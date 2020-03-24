using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Infra.Data.Mapping
{
    public class GenderMap : BaseMap<Gender>
    {
        public override void Configure(EntityTypeBuilder<Gender> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
