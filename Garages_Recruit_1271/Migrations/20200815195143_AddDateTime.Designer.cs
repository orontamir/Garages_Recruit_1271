﻿// <auto-generated />
using System;
using Garages_Recruit_1271.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garages_Recruit_1271.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200815195143_AddDateTime")]
    partial class AddDateTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Garages_Recruit_1271.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Mail")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Phone");

                    b.Property<string>("PhotoPath");

                    b.Property<int?>("Status");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 2, Address = "ddddeee", CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Mail = "eee@gmail.com", Name = "gggg", Password = "ddddfff", Phone = 33333, UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
