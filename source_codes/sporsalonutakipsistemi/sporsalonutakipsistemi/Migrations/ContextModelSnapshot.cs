﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sporsalonutakipsistemi.Models.Data;

#nullable disable

namespace sporsalonutakipsistemi.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BlogDate")
                        .HasColumnType("Date");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Nvarchar(30)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("Nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Nvarchar(30)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Nvarchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("Nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ExpenseValue")
                        .HasColumnType("money");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Months")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceValue")
                        .HasColumnType("smallmoney");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.Revenue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceValue")
                        .HasColumnType("money");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Revenues");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.SiteAdressInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Nvarchar(200)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("Nvarchar(50)");

                    b.Property<string>("MapUrl")
                        .HasMaxLength(500)
                        .HasColumnType("Nvarchar(500)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Nvarchar(50)");

                    b.Property<string>("Phone2")
                        .HasMaxLength(50)
                        .HasColumnType("Nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SiteAdressInfos");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.SiteInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TwUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YoutubeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SiteInfos");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("PlanEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PlanStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PriceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Tc")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PriceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("sporsalonutakipsistemi.Models.Data.UserInfo", b =>
                {
                    b.HasOne("sporsalonutakipsistemi.Models.Data.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sporsalonutakipsistemi.Models.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Price");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
