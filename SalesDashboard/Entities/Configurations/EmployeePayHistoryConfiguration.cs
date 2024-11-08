﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDashboard.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalesDashboard.Entities.Configurations
{
    public partial class EmployeePayHistoryConfiguration : IEntityTypeConfiguration<EmployeePayHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeePayHistory> entity)
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.RateChangeDate }).HasName("PK_EmployeePayHistory_BusinessEntityID_RateChangeDate");

            entity.ToTable("EmployeePayHistory", "HumanResources", tb => tb.HasComment("Employee pay history."));

            entity.Property(e => e.BusinessEntityId)
            .HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.")
            .HasColumnName("BusinessEntityID");
            entity.Property(e => e.RateChangeDate)
            .HasComment("Date the change in pay is effective")
            .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Date and time the record was last updated.")
            .HasColumnType("datetime");
            entity.Property(e => e.PayFrequency).HasComment("1 = Salary received monthly, 2 = Salary received biweekly");
            entity.Property(e => e.Rate)
            .HasComment("Salary hourly rate.")
            .HasColumnType("money");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.EmployeePayHistories)
            .HasForeignKey(d => d.BusinessEntityId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<EmployeePayHistory> entity);
    }
}
