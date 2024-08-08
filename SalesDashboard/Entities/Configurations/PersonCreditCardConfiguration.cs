﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDashboard.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalesDashboard.Entities.Configurations
{
    public partial class PersonCreditCardConfiguration : IEntityTypeConfiguration<PersonCreditCard>
    {
        public void Configure(EntityTypeBuilder<PersonCreditCard> entity)
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.CreditCardId }).HasName("PK_PersonCreditCard_BusinessEntityID_CreditCardID");

            entity.ToTable("PersonCreditCard", "Sales", tb => tb.HasComment("Cross-reference table mapping people to their credit card information in the CreditCard table. "));

            entity.Property(e => e.BusinessEntityId)
            .HasComment("Business entity identification number. Foreign key to Person.BusinessEntityID.")
            .HasColumnName("BusinessEntityID");
            entity.Property(e => e.CreditCardId)
            .HasComment("Credit card identification number. Foreign key to CreditCard.CreditCardID.")
            .HasColumnName("CreditCardID");
            entity.Property(e => e.ModifiedDate)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Date and time the record was last updated.")
            .HasColumnType("datetime");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.PersonCreditCards)
            .HasForeignKey(d => d.BusinessEntityId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CreditCard).WithMany(p => p.PersonCreditCards)
            .HasForeignKey(d => d.CreditCardId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PersonCreditCard> entity);
    }
}
