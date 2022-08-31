using AndariaFinHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndariaFinHub.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.Ignore(e => e.Password);

            builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(t => t.LastName).IsRequired().HasMaxLength(50);
            builder.Property(t => t.EmailAddress).IsRequired().HasMaxLength(50);
            builder.Property(t => t.IdNumber).IsRequired().HasMaxLength(20);
            builder.Property(t => t.DateOfBirth).IsRequired();
        }
    }
}
