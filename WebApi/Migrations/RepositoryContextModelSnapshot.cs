﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.EFCore;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Manisa/Akhisar",
                            Price = 4000m,
                            Type = "Ege bungalov"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Ordu/Ünye",
                            Price = 3000m,
                            Type = "Karadeniz ahşap"
                        },
                        new
                        {
                            Id = 3,
                            Location = "Konya/Ilgın",
                            Price = 2000m,
                            Type = "İçanadolu kerpiç"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
