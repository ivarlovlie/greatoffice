using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class TodoAndOwnerNavigations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenant_user");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "time_labels",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "time_labels",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "time_labels",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "time_entries",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "time_entries",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "time_entries",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "time_categories",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "time_categories",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "time_categories",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "tenants",
                newName: "owning_tenant_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "tenants",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "tenants",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "projects",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "projects",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "projects",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "project_labels",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "project_labels",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "project_labels",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "customers",
                newName: "owner_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "customers",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "customers",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "customer_groups",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "customer_groups",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "customer_groups",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "customer_events",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "customer_events",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "customer_events",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "modified_by_id",
                table: "customer_contacts",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                table: "customer_contacts",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "customer_contacts",
                newName: "created_by");

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "created_by",
                table: "tenants",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "created_by",
                table: "customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "todo_collections",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    visibility = table.Column<int>(type: "integer", nullable: false),
                    project_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_todo_collections", x => x.id);
                    table.ForeignKey(
                        name: "fk_todo_collections_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todo_collections_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todo_collections_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "todo_collection_access_controls",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    collection_id = table.Column<Guid>(type: "uuid", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    can_browse = table.Column<bool>(type: "boolean", nullable: false),
                    can_submit = table.Column<bool>(type: "boolean", nullable: false),
                    can_comment = table.Column<bool>(type: "boolean", nullable: false),
                    can_edit = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_todo_collection_access_controls", x => x.id);
                    table.ForeignKey(
                        name: "fk_todo_collection_access_controls_todo_collections_collection",
                        column: x => x.collection_id,
                        principalTable: "todo_collections",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todo_collection_access_controls_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "todos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    public_id = table.Column<string>(type: "text", nullable: true),
                    assigned_to_id = table.Column<Guid>(type: "uuid", nullable: true),
                    closed_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    collection_id = table.Column<Guid>(type: "uuid", nullable: false),
                    closed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_todos", x => x.id);
                    table.ForeignKey(
                        name: "fk_todos_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todos_todo_projects_collection_id",
                        column: x => x.collection_id,
                        principalTable: "todo_collections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_todos_users_assigned_to_id",
                        column: x => x.assigned_to_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todos_users_closed_by_id",
                        column: x => x.closed_by_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todos_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "todo_comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true),
                    todo_id = table.Column<Guid>(type: "uuid", nullable: true),
                    closing_statement = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_todo_comments", x => x.id);
                    table.ForeignKey(
                        name: "fk_todo_comments_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todo_comments_todos_todo_id",
                        column: x => x.todo_id,
                        principalTable: "todos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todo_comments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "todo_labels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true),
                    todo_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_todo_labels", x => x.id);
                    table.ForeignKey(
                        name: "fk_todo_labels_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todo_labels_todos_todo_id",
                        column: x => x.todo_id,
                        principalTable: "todos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_todo_labels_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_tenant_id",
                table: "users",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_tenant_id",
                table: "time_labels",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_user_id",
                table: "time_labels",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_tenant_id",
                table: "time_entries",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_user_id",
                table: "time_entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_categories_tenant_id",
                table: "time_categories",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_categories_user_id",
                table: "time_categories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_owning_tenant_id",
                table: "tenants",
                column: "owning_tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_user_id",
                table: "tenants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_projects_tenant_id",
                table: "projects",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_projects_user_id",
                table: "projects",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_project_labels_tenant_id",
                table: "project_labels",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_project_labels_user_id",
                table: "project_labels",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_customers_owner_id",
                table: "customers",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_customers_tenant_id",
                table: "customers",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_groups_tenant_id",
                table: "customer_groups",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_groups_user_id",
                table: "customer_groups",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_events_tenant_id",
                table: "customer_events",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_events_user_id",
                table: "customer_events",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_contacts_tenant_id",
                table: "customer_contacts",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_contacts_user_id",
                table: "customer_contacts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_collection_access_controls_collection_id",
                table: "todo_collection_access_controls",
                column: "collection_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_collection_access_controls_user_id",
                table: "todo_collection_access_controls",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_collections_project_id",
                table: "todo_collections",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_collections_tenant_id",
                table: "todo_collections",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_collections_user_id",
                table: "todo_collections",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_comments_tenant_id",
                table: "todo_comments",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_comments_todo_id",
                table: "todo_comments",
                column: "todo_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_comments_user_id",
                table: "todo_comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_labels_tenant_id",
                table: "todo_labels",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_labels_todo_id",
                table: "todo_labels",
                column: "todo_id");

            migrationBuilder.CreateIndex(
                name: "ix_todo_labels_user_id",
                table: "todo_labels",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_todos_assigned_to_id",
                table: "todos",
                column: "assigned_to_id");

            migrationBuilder.CreateIndex(
                name: "ix_todos_closed_by_id",
                table: "todos",
                column: "closed_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_todos_collection_id",
                table: "todos",
                column: "collection_id");

            migrationBuilder.CreateIndex(
                name: "ix_todos_tenant_id",
                table: "todos",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_todos_user_id",
                table: "todos",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_contacts_tenants_tenant_id",
                table: "customer_contacts",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_contacts_users_user_id",
                table: "customer_contacts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_events_tenants_tenant_id",
                table: "customer_events",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_events_users_user_id",
                table: "customer_events",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_groups_tenants_tenant_id",
                table: "customer_groups",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_customer_groups_users_user_id",
                table: "customer_groups",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_customers_tenants_tenant_id",
                table: "customers",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_customers_users_owner_id",
                table: "customers",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_labels_tenants_tenant_id",
                table: "project_labels",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_labels_users_user_id",
                table: "project_labels",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_projects_tenants_tenant_id",
                table: "projects",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_projects_users_user_id",
                table: "projects",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_tenants_owning_tenant_id",
                table: "tenants",
                column: "owning_tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_users_user_id",
                table: "tenants",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_tenants_tenant_id",
                table: "time_categories",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_users_user_id",
                table: "time_categories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_tenants_tenant_id",
                table: "time_entries",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_users_user_id",
                table: "time_entries",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_tenants_tenant_id",
                table: "time_labels",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_users_user_id",
                table: "time_labels",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_tenants_tenant_id",
                table: "users",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer_contacts_tenants_tenant_id",
                table: "customer_contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_customer_contacts_users_user_id",
                table: "customer_contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_customer_events_tenants_tenant_id",
                table: "customer_events");

            migrationBuilder.DropForeignKey(
                name: "fk_customer_events_users_user_id",
                table: "customer_events");

            migrationBuilder.DropForeignKey(
                name: "fk_customer_groups_tenants_tenant_id",
                table: "customer_groups");

            migrationBuilder.DropForeignKey(
                name: "fk_customer_groups_users_user_id",
                table: "customer_groups");

            migrationBuilder.DropForeignKey(
                name: "fk_customers_tenants_tenant_id",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "fk_customers_users_owner_id",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "fk_project_labels_tenants_tenant_id",
                table: "project_labels");

            migrationBuilder.DropForeignKey(
                name: "fk_project_labels_users_user_id",
                table: "project_labels");

            migrationBuilder.DropForeignKey(
                name: "fk_projects_tenants_tenant_id",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "fk_projects_users_user_id",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "fk_tenants_tenants_owning_tenant_id",
                table: "tenants");

            migrationBuilder.DropForeignKey(
                name: "fk_tenants_users_user_id",
                table: "tenants");

            migrationBuilder.DropForeignKey(
                name: "fk_time_categories_tenants_tenant_id",
                table: "time_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_time_categories_users_user_id",
                table: "time_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entries_tenants_tenant_id",
                table: "time_entries");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entries_users_user_id",
                table: "time_entries");

            migrationBuilder.DropForeignKey(
                name: "fk_time_labels_tenants_tenant_id",
                table: "time_labels");

            migrationBuilder.DropForeignKey(
                name: "fk_time_labels_users_user_id",
                table: "time_labels");

            migrationBuilder.DropForeignKey(
                name: "fk_users_tenants_tenant_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "todo_collection_access_controls");

            migrationBuilder.DropTable(
                name: "todo_comments");

            migrationBuilder.DropTable(
                name: "todo_labels");

            migrationBuilder.DropTable(
                name: "todos");

            migrationBuilder.DropTable(
                name: "todo_collections");

            migrationBuilder.DropIndex(
                name: "ix_users_tenant_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_time_labels_tenant_id",
                table: "time_labels");

            migrationBuilder.DropIndex(
                name: "ix_time_labels_user_id",
                table: "time_labels");

            migrationBuilder.DropIndex(
                name: "ix_time_entries_tenant_id",
                table: "time_entries");

            migrationBuilder.DropIndex(
                name: "ix_time_entries_user_id",
                table: "time_entries");

            migrationBuilder.DropIndex(
                name: "ix_time_categories_tenant_id",
                table: "time_categories");

            migrationBuilder.DropIndex(
                name: "ix_time_categories_user_id",
                table: "time_categories");

            migrationBuilder.DropIndex(
                name: "ix_tenants_owning_tenant_id",
                table: "tenants");

            migrationBuilder.DropIndex(
                name: "ix_tenants_user_id",
                table: "tenants");

            migrationBuilder.DropIndex(
                name: "ix_projects_tenant_id",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "ix_projects_user_id",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "ix_project_labels_tenant_id",
                table: "project_labels");

            migrationBuilder.DropIndex(
                name: "ix_project_labels_user_id",
                table: "project_labels");

            migrationBuilder.DropIndex(
                name: "ix_customers_owner_id",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "ix_customers_tenant_id",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "ix_customer_groups_tenant_id",
                table: "customer_groups");

            migrationBuilder.DropIndex(
                name: "ix_customer_groups_user_id",
                table: "customer_groups");

            migrationBuilder.DropIndex(
                name: "ix_customer_events_tenant_id",
                table: "customer_events");

            migrationBuilder.DropIndex(
                name: "ix_customer_events_user_id",
                table: "customer_events");

            migrationBuilder.DropIndex(
                name: "ix_customer_contacts_tenant_id",
                table: "customer_contacts");

            migrationBuilder.DropIndex(
                name: "ix_customer_contacts_user_id",
                table: "customer_contacts");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "customers");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "time_labels",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "time_labels",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "time_labels",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "time_entries",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "time_entries",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "time_entries",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "time_categories",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "time_categories",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "time_categories",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "owning_tenant_id",
                table: "tenants",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "tenants",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "tenants",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "projects",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "projects",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "projects",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "project_labels",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "project_labels",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "project_labels",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "customers",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "customers",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "customers",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "customer_groups",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "customer_groups",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "customer_groups",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "customer_events",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "customer_events",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "customer_events",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "customer_contacts",
                newName: "modified_by_id");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "customer_contacts",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "customer_contacts",
                newName: "created_by_id");

            migrationBuilder.CreateTable(
                name: "tenant_user",
                columns: table => new
                {
                    tenants_id = table.Column<Guid>(type: "uuid", nullable: false),
                    users_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_user", x => new { x.tenants_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_tenant_user_tenants_tenants_id",
                        column: x => x.tenants_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_user_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tenant_user_users_id",
                table: "tenant_user",
                column: "users_id");
        }
    }
}
