﻿// <auto-generated />
using System;
using IOL.GreatOffice.Api.Models;
using IOL.GreatOffice.Api.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    [DbContext(typeof(MainAppDatabase))]
    [Migration("20220530174741_Tenants")]
    partial class Tenants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.ApiAccessToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("AllowCreate")
                        .HasColumnType("boolean")
                        .HasColumnName("allow_create");

                    b.Property<bool>("AllowDelete")
                        .HasColumnType("boolean")
                        .HasColumnName("allow_delete");

                    b.Property<bool>("AllowRead")
                        .HasColumnType("boolean")
                        .HasColumnName("allow_read");

                    b.Property<bool>("AllowUpdate")
                        .HasColumnType("boolean")
                        .HasColumnName("allow_update");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiry_date");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_api_access_tokens");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_api_access_tokens_user_id");

                    b.ToTable("api_access_tokens", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.ForgotPasswordRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_forgot_password_requests");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_forgot_password_requests_user_id");

                    b.ToTable("forgot_password_requests", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.GithubUserMapping", b =>
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

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("text")
                        .HasColumnName("contact_email");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by_id");

                    b.Property<Guid>("DeletedById")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("MasterUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("master_user_id");

                    b.Property<string>("MasterUserPassword")
                        .HasColumnType("text")
                        .HasColumnName("master_user_password");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uuid")
                        .HasColumnName("modified_by_id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.Property<Guid?>("TenantId1")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id1");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_tenants");

                    b.HasIndex("CreatedById")
                        .HasDatabaseName("ix_tenants_created_by_id");

                    b.HasIndex("DeletedById")
                        .HasDatabaseName("ix_tenants_deleted_by_id");

                    b.HasIndex("ModifiedById")
                        .HasDatabaseName("ix_tenants_modified_by_id");

                    b.HasIndex("TenantId1")
                        .HasDatabaseName("ix_tenants_tenant_id1");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_tenants_user_id");

                    b.ToTable("tenants", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.TimeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by_id");

                    b.Property<Guid>("DeletedById")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by_id");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uuid")
                        .HasColumnName("modified_by_id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_time_categories");

                    b.HasIndex("CreatedById")
                        .HasDatabaseName("ix_time_categories_created_by_id");

                    b.HasIndex("DeletedById")
                        .HasDatabaseName("ix_time_categories_deleted_by_id");

                    b.HasIndex("ModifiedById")
                        .HasDatabaseName("ix_time_categories_modified_by_id");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_time_categories_tenant_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_time_categories_user_id");

                    b.ToTable("time_categories", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.TimeEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by_id");

                    b.Property<Guid>("DeletedById")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uuid")
                        .HasColumnName("modified_by_id");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start");

                    b.Property<DateTime>("Stop")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("stop");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_time_entries");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_time_entries_category_id");

                    b.HasIndex("CreatedById")
                        .HasDatabaseName("ix_time_entries_created_by_id");

                    b.HasIndex("DeletedById")
                        .HasDatabaseName("ix_time_entries_deleted_by_id");

                    b.HasIndex("ModifiedById")
                        .HasDatabaseName("ix_time_entries_modified_by_id");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_time_entries_tenant_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_time_entries_user_id");

                    b.ToTable("time_entries", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.TimeLabel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by_id");

                    b.Property<Guid>("DeletedById")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by_id");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uuid")
                        .HasColumnName("modified_by_id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_time_labels");

                    b.HasIndex("CreatedById")
                        .HasDatabaseName("ix_time_labels_created_by_id");

                    b.HasIndex("DeletedById")
                        .HasDatabaseName("ix_time_labels_deleted_by_id");

                    b.HasIndex("ModifiedById")
                        .HasDatabaseName("ix_time_labels_modified_by_id");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_time_labels_tenant_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_time_labels_user_id");

                    b.ToTable("time_labels", (string)null);
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

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

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.ApiAccessToken", b =>
                {
                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_api_access_tokens_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.ForgotPasswordRequest", b =>
                {
                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_forgot_password_requests_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.GithubUserMapping", b =>
                {
                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_github_user_mappings_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.Tenant", b =>
                {
                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_users_created_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_users_deleted_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_users_modified_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId1")
                        .HasConstraintName("fk_tenants_tenants_tenant_id1");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_users_user_id");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.TimeCategory", b =>
                {
                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_categories_users_created_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_categories_users_deleted_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_categories_users_modified_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_categories_tenants_tenant_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_categories_users_user_id");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.TimeEntry", b =>
                {
                    b.HasOne("IOL.GreatOffice.Api.Data.Database.TimeCategory", "Category")
                        .WithMany("Entries")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_time_entries_time_categories_category_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_entries_users_created_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_entries_users_deleted_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_entries_users_modified_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_entries_tenants_tenant_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_entries_users_user_id");

                    b.Navigation("Category");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.TimeLabel", b =>
                {
                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_labels_users_created_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_labels_users_deleted_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_labels_users_modified_by_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_labels_tenants_tenant_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_labels_users_user_id");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TimeEntryTimeLabel", b =>
                {
                    b.HasOne("IOL.GreatOffice.Api.Data.Database.TimeEntry", null)
                        .WithMany()
                        .HasForeignKey("EntriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_entry_time_label_time_entries_entries_id");

                    b.HasOne("IOL.GreatOffice.Api.Data.Database.TimeLabel", null)
                        .WithMany()
                        .HasForeignKey("LabelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_entry_time_label_time_labels_labels_id");
                });

            modelBuilder.Entity("IOL.GreatOffice.Api.Data.Database.TimeCategory", b =>
                {
                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
