﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDashboard.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalesDashboard.Entities.Configurations
{
    public partial class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> entity)
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Store_BusinessEntityID");

            entity.ToTable("Store", "Sales", tb => tb.HasComment("Customers (resellers) of Adventure Works products."));

            entity.HasIndex(e => e.Rowguid, "AK_Store_rowguid").IsUnique();

            entity.HasIndex(e => e.SalesPersonId, "IX_Store_SalesPersonID");

            entity.HasIndex(e => e.Demographics, "PXML_Store_Demographics");

            entity.Property(e => e.BusinessEntityId)
            .ValueGeneratedNever()
            .HasComment("Primary key. Foreign key to Customer.BusinessEntityID.")
            .HasColumnName("BusinessEntityID");
            entity.Property(e => e.Demographics)
            .HasComment("Demographic informationg about the store such as the number of employees, annual sales and store type.")
            .HasColumnType("xml");
            entity.Property(e => e.ModifiedDate)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Date and time the record was last updated.")
            .HasColumnType("datetime");
            entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasComment("Name of the store.");
            entity.Property(e => e.Rowguid)
            .HasDefaultValueSql("(newid())")
            .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            .HasColumnName("rowguid");
            entity.Property(e => e.SalesPersonId)
            .HasComment("ID of the sales person assigned to the customer. Foreign key to SalesPerson.BusinessEntityID.")
            .HasColumnName("SalesPersonID");

            entity.HasOne(d => d.BusinessEntity).WithOne(p => p.Store)
            .HasForeignKey<Store>(d => d.BusinessEntityId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SalesPerson).WithMany(p => p.Stores).HasForeignKey(d => d.SalesPersonId);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Store> entity);
    }
}
