﻿using Baalaven.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baalaven.Repositories.EFCore.EntityConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            //builder.HasKey(p => new { p.Id });
            builder.Property(p => p.OrderId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();            
            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey(p => p.OrderId);
            //builder.Property(p => p.AmountPayable);
                //.IsRequired();           
        }
    }
}
