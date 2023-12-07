﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aes.Data;

#nullable disable

namespace aes.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211211091145_init")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    partial class init
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("aes.Models.ApartmentUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfData")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExecutedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Interrupted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdateBegan")
                        .HasColumnType("datetime2");

                    b.Property<bool>("UpdateComplete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateEnded")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ApartmentUpdate");
                });

            modelBuilder.Entity("aes.Models.Dopis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("PredmetId")
                        .HasColumnType("int");

                    b.Property<string>("Urbroj")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("VrijemeUnosa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PredmetId");

                    b.ToTable("Dopis");
                });

            modelBuilder.Entity("aes.Models.ElektraKupac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Napomena")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OdsId")
                        .HasColumnType("int");

                    b.Property<long>("UgovorniRacun")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("VrijemeUnosa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OdsId");

                    b.ToTable("ElektraKupac");
                });

            modelBuilder.Entity("aes.Models.Ods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Napomena")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Omm")
                        .HasColumnType("int");

                    b.Property<int>("StanId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("VrijemeUnosa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Omm")
                        .IsUnique();

                    b.HasIndex("StanId");

                    b.ToTable("Ods");
                });

            modelBuilder.Entity("aes.Models.Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Klasa")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Naziv")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime?>("VrijemeUnosa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunElektra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumPotvrde")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DopisId")
                        .HasColumnType("int");

                    b.Property<int?>("ElektraKupacId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsItTemp")
                        .HasColumnType("bit");

                    b.Property<double>("Iznos")
                        .HasColumnType("float");

                    b.Property<string>("KlasaPlacanja")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Napomena")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RedniBroj")
                        .HasColumnType("int");

                    b.Property<DateTime?>("VrijemeUnosa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DopisId");

                    b.HasIndex("ElektraKupacId");

                    b.ToTable("RacunElektra");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunElektraIzvrsenjeUsluge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumIzvrsenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumPotvrde")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DopisId")
                        .HasColumnType("int");

                    b.Property<int?>("ElektraKupacId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsItTemp")
                        .HasColumnType("bit");

                    b.Property<double>("Iznos")
                        .HasColumnType("float");

                    b.Property<string>("KlasaPlacanja")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Napomena")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RedniBroj")
                        .HasColumnType("int");

                    b.Property<string>("Usluga")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("VrijemeUnosa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DopisId");

                    b.HasIndex("ElektraKupacId");

                    b.ToTable("RacunElektraIzvrsenjeUsluge");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunElektraRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumPotvrde")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DopisId")
                        .HasColumnType("int");

                    b.Property<int?>("ElektraKupacId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsItTemp")
                        .HasColumnType("bit");

                    b.Property<double>("Iznos")
                        .HasColumnType("float");

                    b.Property<string>("KlasaPlacanja")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Napomena")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Razdoblje")
                        .HasColumnType("datetime2");

                    b.Property<int>("RedniBroj")
                        .HasColumnType("int");

                    b.Property<DateTime?>("VrijemeUnosa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DopisId");

                    b.HasIndex("ElektraKupacId");

                    b.ToTable("RacunElektraRate");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunHolding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumPotvrde")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DopisId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsItTemp")
                        .HasColumnType("bit");

                    b.Property<double>("Iznos")
                        .HasColumnType("float");

                    b.Property<string>("KlasaPlacanja")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Napomena")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RedniBroj")
                        .HasColumnType("int");

                    b.Property<int>("StanId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("VrijemeUnosa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DopisId");

                    b.HasIndex("StanId");

                    b.ToTable("RacunHolding");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunHoldingEdit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditingByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RacunHoldingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RacunHoldingId");

                    b.ToTable("RacunHoldingEdit");
                });

            modelBuilder.Entity("aes.Models.Stan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("BrojSTana")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("DioNekretnine")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Kat")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Korisnik")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Naselje")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<double?>("Površina")
                        .HasColumnType("float");

                    b.Property<string>("Sektor")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("SifraObjekta")
                        .HasColumnType("int");

                    b.Property<int>("StanId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("StatusKorištenja")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Vlasništvo")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime?>("VrijemeUnosa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vrsta")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Četvrt")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Stan");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("aes.Models.Dopis", b =>
                {
                    b.HasOne("aes.Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predmet");
                });

            modelBuilder.Entity("aes.Models.ElektraKupac", b =>
                {
                    b.HasOne("aes.Models.Ods", "Ods")
                        .WithMany()
                        .HasForeignKey("OdsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ods");
                });

            modelBuilder.Entity("aes.Models.Ods", b =>
                {
                    b.HasOne("aes.Models.Stan", "Stan")
                        .WithMany()
                        .HasForeignKey("StanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stan");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunElektra", b =>
                {
                    b.HasOne("aes.Models.Dopis", "Dopis")
                        .WithMany()
                        .HasForeignKey("DopisId");

                    b.HasOne("aes.Models.ElektraKupac", "ElektraKupac")
                        .WithMany()
                        .HasForeignKey("ElektraKupacId");

                    b.Navigation("Dopis");

                    b.Navigation("ElektraKupac");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunElektraIzvrsenjeUsluge", b =>
                {
                    b.HasOne("aes.Models.Dopis", "Dopis")
                        .WithMany()
                        .HasForeignKey("DopisId");

                    b.HasOne("aes.Models.ElektraKupac", "ElektraKupac")
                        .WithMany()
                        .HasForeignKey("ElektraKupacId");

                    b.Navigation("Dopis");

                    b.Navigation("ElektraKupac");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunElektraRate", b =>
                {
                    b.HasOne("aes.Models.Dopis", "Dopis")
                        .WithMany()
                        .HasForeignKey("DopisId");

                    b.HasOne("aes.Models.ElektraKupac", "ElektraKupac")
                        .WithMany()
                        .HasForeignKey("ElektraKupacId");

                    b.Navigation("Dopis");

                    b.Navigation("ElektraKupac");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunHolding", b =>
                {
                    b.HasOne("aes.Models.Dopis", "Dopis")
                        .WithMany()
                        .HasForeignKey("DopisId");

                    b.HasOne("aes.Models.Stan", "Stan")
                        .WithMany()
                        .HasForeignKey("StanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dopis");

                    b.Navigation("Stan");
                });

            modelBuilder.Entity("aes.Models.Racuni.RacunHoldingEdit", b =>
                {
                    b.HasOne("aes.Models.Racuni.RacunHolding", "RacunHolding")
                        .WithMany()
                        .HasForeignKey("RacunHoldingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RacunHolding");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
