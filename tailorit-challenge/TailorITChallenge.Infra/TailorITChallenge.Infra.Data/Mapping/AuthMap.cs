using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Infra.Data.Mapping
{
    public class AuthMap : BaseMap<Authentication>
    {
        public override void Configure(EntityTypeBuilder<Authentication> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Username)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
