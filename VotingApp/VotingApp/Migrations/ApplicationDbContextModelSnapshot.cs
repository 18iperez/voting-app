﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VotingApp.Data;

#nullable disable

namespace VotingApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("VotingApp.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Voter_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Voter_id")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("VotingApp.Models.Business", b =>
                {
                    b.Property<int>("BusinessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BusinessId"));

                    b.Property<int>("BusinessLoginId")
                        .HasColumnType("int");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumCurrentLogins")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.HasKey("BusinessId");

                    b.HasIndex("BusinessLoginId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("VotingApp.Models.BusinessLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BusinessLogins");
                });

            modelBuilder.Entity("VotingApp.Models.General", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusinessLoginId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("VotedForBits")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("VotedForBytes")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("VotedForCollege")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("VoterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusinessLoginId");

                    b.ToTable("Voters");
                });

            modelBuilder.Entity("VotingApp.Models.Teams", b =>
                {
                    b.Property<string>("CompeteLevel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VotesReceived")
                        .HasColumnType("int");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("VotingApp.Models.Admin", b =>
                {
                    b.HasOne("VotingApp.Models.General", "General")
                        .WithOne("Admin")
                        .HasForeignKey("VotingApp.Models.Admin", "Voter_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("General");
                });

            modelBuilder.Entity("VotingApp.Models.Business", b =>
                {
                    b.HasOne("VotingApp.Models.BusinessLogin", "BusinessLogin")
                        .WithMany("Businesses")
                        .HasForeignKey("BusinessLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessLogin");
                });

            modelBuilder.Entity("VotingApp.Models.General", b =>
                {
                    b.HasOne("VotingApp.Models.BusinessLogin", "BusinessLogin")
                        .WithMany("Generals")
                        .HasForeignKey("BusinessLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessLogin");
                });

            modelBuilder.Entity("VotingApp.Models.BusinessLogin", b =>
                {
                    b.Navigation("Businesses");

                    b.Navigation("Generals");
                });

            modelBuilder.Entity("VotingApp.Models.General", b =>
                {
                    b.Navigation("Admin")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
