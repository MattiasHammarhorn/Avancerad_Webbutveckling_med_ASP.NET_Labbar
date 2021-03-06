﻿// <auto-generated />
using CustomerRegisterDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CustomerRegisterDatabase.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerRegisterDatabase.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("GenderType");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
