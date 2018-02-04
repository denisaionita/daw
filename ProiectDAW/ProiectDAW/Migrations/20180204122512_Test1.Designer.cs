﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProiectDAW;
using System;

namespace ProiectDAW.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20180204122512_Test1")]
    partial class Test1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProiectDAW.Models.Book", b =>
                {
                    b.Property<string>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Description");

                    b.Property<string>("ISBN");

                    b.Property<string>("Language");

                    b.Property<string>("Title");

                    b.Property<string>("Year");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ProiectDAW.Models.GenreList", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookGenre");

                    b.Property<string>("BookId");

                    b.HasKey("Id");

                    b.ToTable("GenreLists");
                });

            modelBuilder.Entity("ProiectDAW.Models.User", b =>
                {
                    b.Property<string>("EmailAddress")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Firstname");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("ProfilePicture");

                    b.Property<string>("Role");

                    b.HasKey("EmailAddress");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProiectDAW.Models.Wishlist", b =>
                {
                    b.Property<string>("WishlistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookId");

                    b.Property<string>("UserEmail");

                    b.HasKey("WishlistId");

                    b.ToTable("Wishlists");
                });
#pragma warning restore 612, 618
        }
    }
}