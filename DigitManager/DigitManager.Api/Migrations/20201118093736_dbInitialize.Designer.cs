// <auto-generated />
using System;
using DigitManager.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitManager.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201118093736_dbInitialize")]
    partial class dbInitialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DigitManager.ModelLibrary.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("AgentCommissionMultiply")
                        .HasColumnType("real");

                    b.Property<string>("AgentGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AgentOrPlayer")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsByOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("DigitManager.ModelLibrary.AgentRefreshToken", b =>
                {
                    b.Property<int>("AgentRefreshTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentRefreshTokenId");

                    b.HasIndex("AgentId");

                    b.ToTable("AgentRefreshTokens");
                });

            modelBuilder.Entity("DigitManager.ModelLibrary.MainDigit", b =>
                {
                    b.Property<int>("MainDigitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<int>("AmmountOne")
                        .HasColumnType("int");

                    b.Property<int>("AmmountTwo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionToShowUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IntendedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MorningOrEvening")
                        .HasColumnType("int");

                    b.Property<string>("NumStr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShortcutType")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VoucherId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MainDigitId");

                    b.HasIndex("AgentId");

                    b.ToTable("MainDigits");
                });

            modelBuilder.Entity("DigitManager.ModelLibrary.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedData")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeadlineHourAM")
                        .HasColumnType("int");

                    b.Property<int>("DeadlineHourPM")
                        .HasColumnType("int");

                    b.Property<int>("DeadlineMinutesAM")
                        .HasColumnType("int");

                    b.Property<int>("DeadlineMinutesPM")
                        .HasColumnType("int");

                    b.Property<int>("DefaultMaxAmmountToPlay")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LuckyMultiply")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerGuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            OwnerId = 1,
                            CreatedData = new DateTime(2020, 11, 18, 16, 7, 35, 834, DateTimeKind.Utc).AddTicks(412),
                            DeadlineHourAM = 11,
                            DeadlineHourPM = 4,
                            DeadlineMinutesAM = 45,
                            DeadlineMinutesPM = 0,
                            DefaultMaxAmmountToPlay = 1000000,
                            IsActive = true,
                            LuckyMultiply = 80,
                            Mobile = "099192939495",
                            OwnerGuid = "11dcfc53-0333-4a63-8654-cbc5f954a02a",
                            Password = "lM+LLEuQMvM0J10MCEh5h+1EZdBoXPTz0oj3iA1fZMY=",
                            UpdatedDate = new DateTime(2020, 11, 18, 16, 7, 35, 834, DateTimeKind.Utc).AddTicks(881),
                            UserName = "adminakt"
                        });
                });

            modelBuilder.Entity("DigitManager.ModelLibrary.OwnerRefreshToken", b =>
                {
                    b.Property<int>("OwnerRefreshTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerRefreshTokenId");

                    b.HasIndex("OwnerId");

                    b.ToTable("OwnerRefreshTokens");
                });

            modelBuilder.Entity("DigitManager.ModelLibrary.SubDigit", b =>
                {
                    b.Property<int>("SubDigitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ammount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MainDigitId")
                        .HasColumnType("int");

                    b.Property<string>("TwoNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SubDigitId");

                    b.HasIndex("MainDigitId");

                    b.ToTable("SubDigits");
                });

            modelBuilder.Entity("DigitManager.ModelLibrary.AgentRefreshToken", b =>
                {
                    b.HasOne("DigitManager.ModelLibrary.Agent", "Agent")
                        .WithMany("AgentRefreshTokens")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DigitManager.ModelLibrary.MainDigit", b =>
                {
                    b.HasOne("DigitManager.ModelLibrary.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DigitManager.ModelLibrary.OwnerRefreshToken", b =>
                {
                    b.HasOne("DigitManager.ModelLibrary.Owner", "Owner")
                        .WithMany("OwnerRefreshTokens")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DigitManager.ModelLibrary.SubDigit", b =>
                {
                    b.HasOne("DigitManager.ModelLibrary.MainDigit", "MainDigit")
                        .WithMany("SubDigits")
                        .HasForeignKey("MainDigitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
