﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDashboard.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalesDashboard.Entities.Configurations
{
    public partial class TransactionHistoryArchiveConfiguration : IEntityTypeConfiguration<TransactionHistoryArchive>
    {
        public void Configure(EntityTypeBuilder<TransactionHistoryArchive> entity)
        {
            entity.HasKey(e => e.TransactionId).HasName("PK_TransactionHistoryArchive_TransactionID");

            entity.ToTable("TransactionHistoryArchive", "Production", tb => tb.HasComment("Transactions for previous years."));

            entity.HasIndex(e => e.ProductId, "IX_TransactionHistoryArchive_ProductID");

            entity.HasIndex(e => new { e.ReferenceOrderId, e.ReferenceOrderLineId }, "IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID");

            entity.Property(e => e.TransactionId)
            .ValueGeneratedNever()
            .HasComment("Primary key for TransactionHistoryArchive records.")
            .HasColumnName("TransactionID");
            entity.Property(e => e.ActualCost)
            .HasComment("Product cost.")
            .HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Date and time the record was last updated.")
            .HasColumnType("datetime");
            entity.Property(e => e.ProductId)
            .HasComment("Product identification number. Foreign key to Product.ProductID.")
            .HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasComment("Product quantity.");
            entity.Property(e => e.ReferenceOrderId)
            .HasComment("Purchase order, sales order, or work order identification number.")
            .HasColumnName("ReferenceOrderID");
            entity.Property(e => e.ReferenceOrderLineId)
            .HasComment("Line number associated with the purchase order, sales order, or work order.")
            .HasColumnName("ReferenceOrderLineID");
            entity.Property(e => e.TransactionDate)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Date and time of the transaction.")
            .HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
            .HasMaxLength(1)
            .IsFixedLength()
            .HasComment("W = Work Order, S = Sales Order, P = Purchase Order");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<TransactionHistoryArchive> entity);
    }
}