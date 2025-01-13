﻿// <auto-generated />
using LanguageInstall.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LanguageInstall.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250113171608_seed")]
    partial class seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LanguageInstall.Data.Model.MainTable", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("EnglishText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MainTables");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EnglishText = "First Name"
                        },
                        new
                        {
                            ID = 2,
                            EnglishText = "Last Name"
                        },
                        new
                        {
                            ID = 3,
                            EnglishText = "Submit"
                        },
                        new
                        {
                            ID = 4,
                            EnglishText = "Home"
                        },
                        new
                        {
                            ID = 5,
                            EnglishText = "Human Resource Management"
                        },
                        new
                        {
                            ID = 6,
                            EnglishText = "Leave Management"
                        },
                        new
                        {
                            ID = 7,
                            EnglishText = "Operation"
                        },
                        new
                        {
                            ID = 8,
                            EnglishText = "Leave Application Entry"
                        },
                        new
                        {
                            ID = 9,
                            EnglishText = "Company"
                        },
                        new
                        {
                            ID = 10,
                            EnglishText = "Employee ID"
                        },
                        new
                        {
                            ID = 11,
                            EnglishText = "Employee Name"
                        },
                        new
                        {
                            ID = 12,
                            EnglishText = "Designation"
                        },
                        new
                        {
                            ID = 13,
                            EnglishText = "Department"
                        },
                        new
                        {
                            ID = 14,
                            EnglishText = "Immediate Supervisor"
                        },
                        new
                        {
                            ID = 15,
                            EnglishText = "Head of Department"
                        },
                        new
                        {
                            ID = 16,
                            EnglishText = "Apply Leave Format"
                        },
                        new
                        {
                            ID = 17,
                            EnglishText = "Leave Type"
                        },
                        new
                        {
                            ID = 18,
                            EnglishText = "From"
                        },
                        new
                        {
                            ID = 19,
                            EnglishText = "Day(s)"
                        },
                        new
                        {
                            ID = 20,
                            EnglishText = "To"
                        },
                        new
                        {
                            ID = 21,
                            EnglishText = "Half Day"
                        },
                        new
                        {
                            ID = 22,
                            EnglishText = "First Half"
                        },
                        new
                        {
                            ID = 23,
                            EnglishText = "Second Half"
                        },
                        new
                        {
                            ID = 24,
                            EnglishText = "File Attachment"
                        },
                        new
                        {
                            ID = 25,
                            EnglishText = "Reason"
                        },
                        new
                        {
                            ID = 26,
                            EnglishText = "Leave Apply"
                        },
                        new
                        {
                            ID = 27,
                            EnglishText = "Select Dropdown Options"
                        },
                        new
                        {
                            ID = 28,
                            EnglishText = "--Select--"
                        },
                        new
                        {
                            ID = 29,
                            EnglishText = "--Select Apply Leave Format--"
                        },
                        new
                        {
                            ID = 30,
                            EnglishText = "Half Day Leave"
                        },
                        new
                        {
                            ID = 31,
                            EnglishText = "Full Day Leave"
                        },
                        new
                        {
                            ID = 32,
                            EnglishText = "Short Leave"
                        },
                        new
                        {
                            ID = 33,
                            EnglishText = "--Select--"
                        },
                        new
                        {
                            ID = 34,
                            EnglishText = "Button and Action Text"
                        },
                        new
                        {
                            ID = 35,
                            EnglishText = "Leave Apply"
                        },
                        new
                        {
                            ID = 36,
                            EnglishText = "Half Day"
                        },
                        new
                        {
                            ID = 37,
                            EnglishText = "Full Day"
                        },
                        new
                        {
                            ID = 38,
                            EnglishText = "Short Leave"
                        },
                        new
                        {
                            ID = 39,
                            EnglishText = "Leave Duration"
                        },
                        new
                        {
                            ID = 40,
                            EnglishText = "Select Employee"
                        },
                        new
                        {
                            ID = 41,
                            EnglishText = "Select Leave Format"
                        },
                        new
                        {
                            ID = 42,
                            EnglishText = "Select Leave Type"
                        },
                        new
                        {
                            ID = 43,
                            EnglishText = "Sick Leave"
                        },
                        new
                        {
                            ID = 44,
                            EnglishText = "Casual Leave"
                        },
                        new
                        {
                            ID = 45,
                            EnglishText = "Select Leave Type"
                        },
                        new
                        {
                            ID = 46,
                            EnglishText = "Enter Reason"
                        },
                        new
                        {
                            ID = 47,
                            EnglishText = "Cancel"
                        },
                        new
                        {
                            ID = 48,
                            EnglishText = "Entry ID"
                        },
                        new
                        {
                            ID = 49,
                            EnglishText = "--Select Employee--"
                        },
                        new
                        {
                            ID = 50,
                            EnglishText = "Additional Information"
                        });
                });

            modelBuilder.Entity("LanguageInstall.Data.Model.Translation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainTableID")
                        .HasColumnType("int");

                    b.Property<string>("TranslatedText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MainTableID");

                    b.ToTable("Translation");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            LanguageCode = "bn",
                            MainTableID = 1,
                            TranslatedText = "প্রথম নাম"
                        },
                        new
                        {
                            ID = 2,
                            LanguageCode = "bn",
                            MainTableID = 2,
                            TranslatedText = "শেষ নাম"
                        },
                        new
                        {
                            ID = 3,
                            LanguageCode = "bn",
                            MainTableID = 3,
                            TranslatedText = "জমা দিন"
                        },
                        new
                        {
                            ID = 4,
                            LanguageCode = "bn",
                            MainTableID = 4,
                            TranslatedText = "বাড়ি"
                        },
                        new
                        {
                            ID = 5,
                            LanguageCode = "bn",
                            MainTableID = 5,
                            TranslatedText = "মানবসম্পদ পরিচালনা"
                        },
                        new
                        {
                            ID = 6,
                            LanguageCode = "bn",
                            MainTableID = 6,
                            TranslatedText = "ব্যবস্থাপনা ছেড়ে দিন"
                        },
                        new
                        {
                            ID = 7,
                            LanguageCode = "bn",
                            MainTableID = 7,
                            TranslatedText = "অপারেশন"
                        },
                        new
                        {
                            ID = 8,
                            LanguageCode = "bn",
                            MainTableID = 8,
                            TranslatedText = "অ্যাপ্লিকেশন এন্ট্রি ছেড়ে দিন"
                        },
                        new
                        {
                            ID = 9,
                            LanguageCode = "bn",
                            MainTableID = 9,
                            TranslatedText = "সংস্থা"
                        },
                        new
                        {
                            ID = 10,
                            LanguageCode = "bn",
                            MainTableID = 10,
                            TranslatedText = "কর্মচারী আইডি"
                        },
                        new
                        {
                            ID = 11,
                            LanguageCode = "bn",
                            MainTableID = 11,
                            TranslatedText = "কর্মচারীর নাম"
                        },
                        new
                        {
                            ID = 12,
                            LanguageCode = "bn",
                            MainTableID = 12,
                            TranslatedText = "উপাধি"
                        },
                        new
                        {
                            ID = 13,
                            LanguageCode = "bn",
                            MainTableID = 13,
                            TranslatedText = "বিভাগ"
                        },
                        new
                        {
                            ID = 14,
                            LanguageCode = "bn",
                            MainTableID = 14,
                            TranslatedText = "তাত্ক্ষণিক সুপারভাইজার"
                        },
                        new
                        {
                            ID = 15,
                            LanguageCode = "bn",
                            MainTableID = 15,
                            TranslatedText = "বিভাগের প্রধান"
                        },
                        new
                        {
                            ID = 16,
                            LanguageCode = "bn",
                            MainTableID = 16,
                            TranslatedText = "ছুটি ফর্ম্যাট প্রয়োগ করুন"
                        },
                        new
                        {
                            ID = 17,
                            LanguageCode = "bn",
                            MainTableID = 17,
                            TranslatedText = "ছেড়ে দিন"
                        },
                        new
                        {
                            ID = 18,
                            LanguageCode = "bn",
                            MainTableID = 18,
                            TranslatedText = "থেকে"
                        },
                        new
                        {
                            ID = 19,
                            LanguageCode = "bn",
                            MainTableID = 19,
                            TranslatedText = "দিন (গুলি)"
                        },
                        new
                        {
                            ID = 20,
                            LanguageCode = "bn",
                            MainTableID = 20,
                            TranslatedText = "থেকে"
                        },
                        new
                        {
                            ID = 21,
                            LanguageCode = "bn",
                            MainTableID = 21,
                            TranslatedText = "অর্ধ দিন"
                        },
                        new
                        {
                            ID = 22,
                            LanguageCode = "bn",
                            MainTableID = 22,
                            TranslatedText = "প্রথমার্ধ"
                        },
                        new
                        {
                            ID = 23,
                            LanguageCode = "bn",
                            MainTableID = 23,
                            TranslatedText = "দ্বিতীয়ার্ধ"
                        },
                        new
                        {
                            ID = 24,
                            LanguageCode = "bn",
                            MainTableID = 24,
                            TranslatedText = "ফাইল সংযুক্তি"
                        },
                        new
                        {
                            ID = 25,
                            LanguageCode = "bn",
                            MainTableID = 25,
                            TranslatedText = "কারণ"
                        },
                        new
                        {
                            ID = 26,
                            LanguageCode = "bn",
                            MainTableID = 26,
                            TranslatedText = "আবেদন করুন"
                        },
                        new
                        {
                            ID = 27,
                            LanguageCode = "bn",
                            MainTableID = 27,
                            TranslatedText = "ড্রপডাউন বিকল্পগুলি নির্বাচন করুন"
                        },
                        new
                        {
                            ID = 28,
                            LanguageCode = "bn",
                            MainTableID = 28,
                            TranslatedText = "-নির্বাচন-"
                        },
                        new
                        {
                            ID = 29,
                            LanguageCode = "bn",
                            MainTableID = 29,
                            TranslatedText = "-নির্বাচন করুন ছুটির ফর্ম্যাট প্রয়োগ করুন-"
                        },
                        new
                        {
                            ID = 30,
                            LanguageCode = "bn",
                            MainTableID = 30,
                            TranslatedText = "অর্ধ দিনের ছুটি"
                        },
                        new
                        {
                            ID = 31,
                            LanguageCode = "bn",
                            MainTableID = 31,
                            TranslatedText = "পুরো দিন ছুটি"
                        },
                        new
                        {
                            ID = 32,
                            LanguageCode = "bn",
                            MainTableID = 32,
                            TranslatedText = "সংক্ষিপ্ত ছুটি"
                        },
                        new
                        {
                            ID = 33,
                            LanguageCode = "bn",
                            MainTableID = 33,
                            TranslatedText = "-নির্বাচন-"
                        },
                        new
                        {
                            ID = 34,
                            LanguageCode = "bn",
                            MainTableID = 34,
                            TranslatedText = "বোতাম এবং ক্রিয়া পাঠ্য"
                        },
                        new
                        {
                            ID = 35,
                            LanguageCode = "bn",
                            MainTableID = 35,
                            TranslatedText = "আবেদন করুন"
                        },
                        new
                        {
                            ID = 36,
                            LanguageCode = "bn",
                            MainTableID = 36,
                            TranslatedText = "অর্ধ দিন"
                        },
                        new
                        {
                            ID = 37,
                            LanguageCode = "bn",
                            MainTableID = 37,
                            TranslatedText = "পুরো দিন"
                        },
                        new
                        {
                            ID = 38,
                            LanguageCode = "bn",
                            MainTableID = 38,
                            TranslatedText = "সংক্ষিপ্ত ছুটি"
                        },
                        new
                        {
                            ID = 39,
                            LanguageCode = "bn",
                            MainTableID = 39,
                            TranslatedText = "সময়কাল"
                        },
                        new
                        {
                            ID = 40,
                            LanguageCode = "bn",
                            MainTableID = 40,
                            TranslatedText = "কর্মচারী নির্বাচন করুন"
                        },
                        new
                        {
                            ID = 41,
                            LanguageCode = "bn",
                            MainTableID = 41,
                            TranslatedText = "ছুটি ফর্ম্যাট নির্বাচন করুন"
                        },
                        new
                        {
                            ID = 42,
                            LanguageCode = "bn",
                            MainTableID = 42,
                            TranslatedText = "ছুটি প্রকার নির্বাচন করুন"
                        },
                        new
                        {
                            ID = 43,
                            LanguageCode = "bn",
                            MainTableID = 43,
                            TranslatedText = "অসুস্থ ছুটি"
                        },
                        new
                        {
                            ID = 44,
                            LanguageCode = "bn",
                            MainTableID = 44,
                            TranslatedText = "নৈমিত্তিক ছুটি"
                        },
                        new
                        {
                            ID = 45,
                            LanguageCode = "bn",
                            MainTableID = 45,
                            TranslatedText = "ছুটি প্রকার নির্বাচন করুন"
                        },
                        new
                        {
                            ID = 46,
                            LanguageCode = "bn",
                            MainTableID = 46,
                            TranslatedText = "কারণ লিখুন"
                        },
                        new
                        {
                            ID = 47,
                            LanguageCode = "bn",
                            MainTableID = 47,
                            TranslatedText = "বাতিল"
                        },
                        new
                        {
                            ID = 48,
                            LanguageCode = "bn",
                            MainTableID = 48,
                            TranslatedText = "এন্ট্রি আইডি"
                        },
                        new
                        {
                            ID = 49,
                            LanguageCode = "bn",
                            MainTableID = 49,
                            TranslatedText = "-- কর্মচারী নির্বাচন করুন --"
                        },
                        new
                        {
                            ID = 50,
                            LanguageCode = "bn",
                            MainTableID = 50,
                            TranslatedText = "অতিরিক্ত তথ্য"
                        });
                });

            modelBuilder.Entity("LanguageInstall.Data.Model.Translation", b =>
                {
                    b.HasOne("LanguageInstall.Data.Model.MainTable", "MainTable")
                        .WithMany("Translations")
                        .HasForeignKey("MainTableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainTable");
                });

            modelBuilder.Entity("LanguageInstall.Data.Model.MainTable", b =>
                {
                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}