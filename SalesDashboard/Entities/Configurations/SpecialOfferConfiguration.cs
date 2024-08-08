﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDashboard.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalesDashboard.Entities.Configurations
{
    public partial class SpecialOfferConfiguration : IEntityTypeConfiguration<SpecialOffer>
    {
        public void Configure(EntityTypeBuilder<SpecialOffer> entity)
        {
            entity.HasKey(e => e.SpecialOfferId).HasName("PK_SpecialOffer_SpecialOfferID");

            entity.ToTable("SpecialOffer", "Sales", tb => tb.HasComment("Sale discounts lookup table."));

            entity.HasIndex(e => e.Rowguid, "AK_SpecialOffer_rowguid").IsUnique();

            entity.Property(e => e.SpecialOfferId)
            .HasComment("Primary key for SpecialOffer records.")
            .HasColumnName("SpecialOfferID");
            entity.Property(e => e.Category)
            .HasMaxLength(50)
            .HasComment("Group the discount applies to such as Reseller or Customer.");
            entity.Property(e => e.Description)
            .HasMaxLength(255)
            .HasComment("Discount description.");
            entity.Property(e => e.DiscountPct)
            .HasDefaultValueSql("((0.00))")
            .HasComment("Discount precentage.")
            .HasColumnType("smallmoney");
            entity.Property(e => e.EndDate)
            .HasComment("Discount end date.")
            .HasColumnType("datetime");
            entity.Property(e => e.MaxQty).HasComment("Maximum discount percent allowed.");
            entity.Property(e => e.MinQty).HasComment("Minimum discount percent allowed.");
            entity.Property(e => e.ModifiedDate)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Date and time the record was last updated.")
            .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
            .HasDefaultValueSql("(newid())")
            .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            .HasColumnName("rowguid");
            entity.Property(e => e.StartDate)
            .HasComment("Discount start date.")
            .HasColumnType("datetime");
            entity.Property(e => e.Type)
            .HasMaxLength(50)
            .HasComment("Discount type category.");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<SpecialOffer> entity);
    }
}
