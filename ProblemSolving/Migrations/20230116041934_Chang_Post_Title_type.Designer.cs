﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProblemSolving.Data.Context;

#nullable disable

namespace ProblemSolving.Migrations
{
    [DbContext(typeof(ProblemSolvingContext))]
    [Migration("20230116041934_Chang_Post_Title_type")]
    partial class ChangPostTitletype
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProblemSolving.Domain.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Owner")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("Post_PrimaryKey_PostId");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("ProblemSolving.Domain.Entities.Star", b =>
                {
                    b.Property<Guid>("Post_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("User_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Post_Id", "User_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("ProblemSolving.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar");

                    b.HasKey("Id")
                        .HasName("User_PrimaryKey_UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ProblemSolving.Domain.Entities.Star", b =>
                {
                    b.HasOne("ProblemSolving.Domain.Entities.Post", "Post")
                        .WithMany("Stars")
                        .HasForeignKey("Post_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Stars_ForeignKey_PostId");

                    b.HasOne("ProblemSolving.Domain.Entities.User", "User")
                        .WithMany("Stars")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Stars_ForeignKey_UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProblemSolving.Domain.Entities.Post", b =>
                {
                    b.Navigation("Stars");
                });

            modelBuilder.Entity("ProblemSolving.Domain.Entities.User", b =>
                {
                    b.Navigation("Stars");
                });
#pragma warning restore 612, 618
        }
    }
}
