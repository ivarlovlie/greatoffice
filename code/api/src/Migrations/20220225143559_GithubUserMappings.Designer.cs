﻿// <auto-generated />


#nullable disable

using System;
using IOL.GreatOffice.Api.Data;
using IOL.GreatOffice.Api.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
namespace IOL.GreatOffice.Api.Migrations
{
    [DbContext(typeof(MainAppDatabase))]
    [Migration("20220225143559_GithubUserMappings")]
    partial class GithubUserMappings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IOL.GreatOffice.Data.Database.ForgotPasswordRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_forgot_password_requests");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_forgot_password_requests_user_id");

                    b.ToTable("forgot_password_requests", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Data.Database.GithubUserMapping", b =>
                {
                    b.Property<string>("GithubId")
                        .HasColumnType("text")
                        .HasColumnName("github_id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text")
                        .HasColumnName("refresh_token");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("GithubId")
                        .HasName("pk_github_user_mappings");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_github_user_mappings_user_id");

                    b.ToTable("github_user_mappings", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Data.Database.TimeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_time_categories");

                    b.ToTable("time_categories", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Data.Database.TimeEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start");

                    b.Property<DateTime>("Stop")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("stop");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_time_entries");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_time_entries_category_id");

                    b.ToTable("time_entries", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Data.Database.TimeLabel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_time_labels");

                    b.ToTable("time_labels", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Data.Database.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("TimeEntryTimeLabel", b =>
                {
                    b.Property<Guid>("EntriesId")
                        .HasColumnType("uuid")
                        .HasColumnName("entries_id");

                    b.Property<Guid>("LabelsId")
                        .HasColumnType("uuid")
                        .HasColumnName("labels_id");

                    b.HasKey("EntriesId", "LabelsId")
                        .HasName("pk_time_entry_time_label");

                    b.HasIndex("LabelsId")
                        .HasDatabaseName("ix_time_entry_time_label_labels_id");

                    b.ToTable("time_entry_time_label", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Data.Database.ForgotPasswordRequest", b =>
                {
                    b.HasOne("IOL.GreatOffice.Data.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_forgot_password_requests_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOL.GreatOffice.Data.Database.GithubUserMapping", b =>
                {
                    b.HasOne("IOL.GreatOffice.Data.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_github_user_mappings_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOL.GreatOffice.Data.Database.TimeEntry", b =>
                {
                    b.HasOne("IOL.GreatOffice.Data.Database.TimeCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_time_entries_time_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TimeEntryTimeLabel", b =>
                {
                    b.HasOne("IOL.GreatOffice.Data.Database.TimeEntry", null)
                        .WithMany()
                        .HasForeignKey("EntriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_entry_time_label_time_entries_entries_id");

                    b.HasOne("IOL.GreatOffice.Data.Database.TimeLabel", null)
                        .WithMany()
                        .HasForeignKey("LabelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_entry_time_label_time_labels_labels_id");
                });
#pragma warning restore 612, 618
        }
    }
}
