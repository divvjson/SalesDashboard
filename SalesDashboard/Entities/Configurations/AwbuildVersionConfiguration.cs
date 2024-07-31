﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDashboard.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalesDashboard.Entities.Configurations
{
    public partial class AwbuildVersionConfiguration : IEntityTypeConfiguration<AwbuildVersion>
    {
        public void Configure(EntityTypeBuilder<AwbuildVersion> entity)
        {
            entity.HasKey(e => e.SystemInformationId).HasName("PK_AWBuildVersion_SystemInformationID");

            entity.ToTable("AWBuildVersion", tb => tb.HasComment("Current version number of the AdventureWorks 2016 sample database. "));

            entity.Property(e => e.SystemInformationId)
                .ValueGeneratedOnAdd()
                .HasComment("Primary key for AWBuildVersion records.")
                .HasColumnName("SystemInformationID");
            entity.Property(e => e.DatabaseVersion)
                .HasMaxLength(25)
                .HasComment("Version number of the database in 9.yy.mm.dd.00 format.")
                .HasColumnName("Database Version");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.VersionDate)
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<AwbuildVersion> entity);
    }
}
