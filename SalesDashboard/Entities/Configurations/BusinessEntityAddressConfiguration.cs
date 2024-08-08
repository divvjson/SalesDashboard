﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDashboard.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalesDashboard.Entities.Configurations
{
    public partial class BusinessEntityAddressConfiguration : IEntityTypeConfiguration<BusinessEntityAddress>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityAddress> entity)
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.AddressId, e.AddressTypeId }).HasName("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID");

            entity.ToTable("BusinessEntityAddress", "Person", tb => tb.HasComment("Cross-reference table mapping customers, vendors, and employees to their addresses."));

            entity.HasIndex(e => e.Rowguid, "AK_BusinessEntityAddress_rowguid").IsUnique();

            entity.HasIndex(e => e.AddressId, "IX_BusinessEntityAddress_AddressID");

            entity.HasIndex(e => e.AddressTypeId, "IX_BusinessEntityAddress_AddressTypeID");

            entity.Property(e => e.BusinessEntityId)
            .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.")
            .HasColumnName("BusinessEntityID");
            entity.Property(e => e.AddressId)
            .HasComment("Primary key. Foreign key to Address.AddressID.")
            .HasColumnName("AddressID");
            entity.Property(e => e.AddressTypeId)
            .HasComment("Primary key. Foreign key to AddressType.AddressTypeID.")
            .HasColumnName("AddressTypeID");
            entity.Property(e => e.ModifiedDate)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Date and time the record was last updated.")
            .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
            .HasDefaultValueSql("(newid())")
            .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            .HasColumnName("rowguid");

            entity.HasOne(d => d.Address).WithMany(p => p.BusinessEntityAddresses)
            .HasForeignKey(d => d.AddressId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AddressType).WithMany(p => p.BusinessEntityAddresses)
            .HasForeignKey(d => d.AddressTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.BusinessEntityAddresses)
            .HasForeignKey(d => d.BusinessEntityId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<BusinessEntityAddress> entity);
    }
}
