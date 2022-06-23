﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Okul.Domain;

namespace Okul.Domain.Migrations
{
    [DbContext(typeof(OkulDbContext))]
    partial class OkulDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Okul.Domain.Brans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BransAdi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Branslar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BransAdi = "Matematik",
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BransAdi = "Fizik",
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BransAdi = "Muzik",
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            BransAdi = "Tarih",
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            BransAdi = "Kimya",
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            BransAdi = "Edebiyat",
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Okul.Domain.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("user");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Okul.Domain.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gsm")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("SinifId")
                        .HasColumnType("int");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("SinifId");

                    b.ToTable("Ogrenciler");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adi = "Ali",
                            Cinsiyet = false,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DogumTarihi = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SinifId = 2,
                            Soyadi = "Veli",
                            TcNo = "12345678901"
                        });
                });

            modelBuilder.Entity("Okul.Domain.Ogretmen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("BransId")
                        .HasColumnType("int");

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gsm")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Maas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("BransId");

                    b.ToTable("Ogretmenler");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adi = "Ayse",
                            BransId = 1,
                            Cinsiyet = false,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DogumTarihi = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Maas = 0m,
                            Soyadi = "Yilmaz",
                            TcNo = "12345678901"
                        });
                });

            modelBuilder.Entity("Okul.Domain.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BransId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OgretmenId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Saat")
                        .HasColumnType("datetime2");

                    b.Property<int>("SinifId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BransId");

                    b.HasIndex("OgretmenId");

                    b.HasIndex("SinifId");

                    b.ToTable("Planlar");
                });

            modelBuilder.Entity("Okul.Domain.Sinif", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kapasite")
                        .HasColumnType("int");

                    b.Property<string>("SinifAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Siniflar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Kapasite = 30,
                            SinifAdi = "11A"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Kapasite = 30,
                            SinifAdi = "12A"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Kapasite = 30,
                            SinifAdi = "13A"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Kapasite = 30,
                            SinifAdi = "14A"
                        });
                });

            modelBuilder.Entity("Okul.Domain.Yoklama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("int");

                    b.Property<int>("PlanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Saat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OgrenciId");

                    b.HasIndex("PlanID");

                    b.ToTable("Yoklamalar");
                });

            modelBuilder.Entity("Okul.Domain.Ogrenci", b =>
                {
                    b.HasOne("Okul.Domain.Sinif", "Sinif")
                        .WithMany("Ogrenciler")
                        .HasForeignKey("SinifId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sinif");
                });

            modelBuilder.Entity("Okul.Domain.Ogretmen", b =>
                {
                    b.HasOne("Okul.Domain.Brans", "Brans")
                        .WithMany("Ogretmenler")
                        .HasForeignKey("BransId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brans");
                });

            modelBuilder.Entity("Okul.Domain.Plan", b =>
                {
                    b.HasOne("Okul.Domain.Brans", "Brans")
                        .WithMany("Planlar")
                        .HasForeignKey("BransId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Okul.Domain.Ogretmen", "Ogretmen")
                        .WithMany("Planlar")
                        .HasForeignKey("OgretmenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Okul.Domain.Sinif", "Sinif")
                        .WithMany("Planlar")
                        .HasForeignKey("SinifId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brans");

                    b.Navigation("Ogretmen");

                    b.Navigation("Sinif");
                });

            modelBuilder.Entity("Okul.Domain.Yoklama", b =>
                {
                    b.HasOne("Okul.Domain.Ogrenci", "Ogrenci")
                        .WithMany("Yoklamalar")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Okul.Domain.Plan", "Plan")
                        .WithMany("Yoklamalar")
                        .HasForeignKey("PlanID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ogrenci");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Okul.Domain.Brans", b =>
                {
                    b.Navigation("Ogretmenler");

                    b.Navigation("Planlar");
                });

            modelBuilder.Entity("Okul.Domain.Ogrenci", b =>
                {
                    b.Navigation("Yoklamalar");
                });

            modelBuilder.Entity("Okul.Domain.Ogretmen", b =>
                {
                    b.Navigation("Planlar");
                });

            modelBuilder.Entity("Okul.Domain.Plan", b =>
                {
                    b.Navigation("Yoklamalar");
                });

            modelBuilder.Entity("Okul.Domain.Sinif", b =>
                {
                    b.Navigation("Ogrenciler");

                    b.Navigation("Planlar");
                });
#pragma warning restore 612, 618
        }
    }
}
