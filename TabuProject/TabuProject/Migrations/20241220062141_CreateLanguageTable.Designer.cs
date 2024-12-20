﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TabuProject.DAL;

#nullable disable

namespace TabuProject.Migrations
{
    [DbContext(typeof(TabuDbContext))]
    [Migration("20241220062141_CreateLanguageTable")]
    partial class CreateLanguageTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TabuProject.Entities.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("character(2)")
                        .IsFixedLength();

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Code");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}
