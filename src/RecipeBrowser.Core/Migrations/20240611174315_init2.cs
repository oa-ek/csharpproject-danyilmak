using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeBrowser.Core.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Recipes_RecipeId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "CollectionRecipe");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("37f02e99-2ac9-4fec-b807-0d1783e24255"), new Guid("8b5830ec-7a22-4b6e-95fe-66157fb56fab") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e028a871-f98b-426d-97c5-5a945567d743"), new Guid("8b5830ec-7a22-4b6e-95fe-66157fb56fab") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1231b02-c53a-4222-a4d7-3930390410ce"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("37f02e99-2ac9-4fec-b807-0d1783e24255"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e028a871-f98b-426d-97c5-5a945567d743"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8b5830ec-7a22-4b6e-95fe-66157fb56fab"));

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Reviews",
                newName: "Desc");

            migrationBuilder.AddColumn<Guid>(
                name: "CollectionId",
                table: "Recipes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("63324957-3702-40bf-9595-fb5471f6bcb0"), "63324957-3702-40bf-9595-fb5471f6bcb0", "Admin", "ADMIN" },
                    { new Guid("ee0b7f24-a4bc-4c35-bfe5-32ac5b4daa9f"), "ee0b7f24-a4bc-4c35-bfe5-32ac5b4daa9f", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("17e70be7-b3cb-4ecd-b749-4dc8ea1a7fc9"), 0, "52f3fec8-51e7-4a42-aee2-729fd06df3ed", "admin@recipes.daniil.page", true, "Даниїл Максимчук", false, null, "ADMIN@RECIPES.DANIIL.PAGE", "ADMIN@RECIPES.DANIIL.PAGE", "AQAAAAIAAYagAAAAEHv4VsWWhRViZqu5ITXhWdpUQ3bFXOX5nW+ggYxobAmI3LRg6dDqLxL29n+0m+jxvA==", null, false, "fd5859f9-39bb-4222-8f78-b01bba8865af", false, "admin@recipes.daniil.page" },
                    { new Guid("fe0e1aab-ccac-4263-a6af-a6b3a5c39c84"), 0, "20ab6896-430d-4118-ac97-ca3186c6b9e5", "user@recipes.daniil.page", true, "Ігор Куренко", false, null, "USER@RECIPES.DANIIL.PAGE", "USER@RECIPES.DANIIL.PAGE", "AQAAAAIAAYagAAAAEK0esb/wlAJInjBFxz+KQX16G/NczcMDZQ3ssNrgcngXrgG2eZUvWRBma6qM316GuA==", null, false, "5d941871-fa4a-4908-ab42-f415625bc4ec", false, "user@recipes.daniil.page" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("63324957-3702-40bf-9595-fb5471f6bcb0"), new Guid("17e70be7-b3cb-4ecd-b749-4dc8ea1a7fc9") },
                    { new Guid("ee0b7f24-a4bc-4c35-bfe5-32ac5b4daa9f"), new Guid("17e70be7-b3cb-4ecd-b749-4dc8ea1a7fc9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CollectionId",
                table: "Recipes",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Collections_CollectionId",
                table: "Recipes",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Collections_CollectionId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CollectionId",
                table: "Recipes");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("63324957-3702-40bf-9595-fb5471f6bcb0"), new Guid("17e70be7-b3cb-4ecd-b749-4dc8ea1a7fc9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ee0b7f24-a4bc-4c35-bfe5-32ac5b4daa9f"), new Guid("17e70be7-b3cb-4ecd-b749-4dc8ea1a7fc9") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fe0e1aab-ccac-4263-a6af-a6b3a5c39c84"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("63324957-3702-40bf-9595-fb5471f6bcb0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ee0b7f24-a4bc-4c35-bfe5-32ac5b4daa9f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("17e70be7-b3cb-4ecd-b749-4dc8ea1a7fc9"));

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Reviews",
                newName: "Title");

            migrationBuilder.CreateTable(
                name: "CollectionRecipe",
                columns: table => new
                {
                    CollectionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionRecipe", x => new { x.CollectionsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_CollectionRecipe_Collections_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("37f02e99-2ac9-4fec-b807-0d1783e24255"), "37f02e99-2ac9-4fec-b807-0d1783e24255", "User", "USER" },
                    { new Guid("e028a871-f98b-426d-97c5-5a945567d743"), "e028a871-f98b-426d-97c5-5a945567d743", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("8b5830ec-7a22-4b6e-95fe-66157fb56fab"), 0, "a0f4a5bc-adfd-42ff-a1ff-12d5a370fc8c", "admin@recipes.daniil.page", true, "Даниїл Максимчук", false, null, "ADMIN@RECIPES.DANIIL.PAGE", "ADMIN@RECIPES.DANIIL.PAGE", "AQAAAAIAAYagAAAAECibdX+BFwvCsW7Ta6dYfH+uBKGZAk/mOE/6cz/80Yxt+XqqdTYH4durYorSJk6Z7g==", null, false, "c287daf6-b526-42a5-a4fc-22a509432f64", false, "admin@recipes.daniil.page" },
                    { new Guid("a1231b02-c53a-4222-a4d7-3930390410ce"), 0, "e9e6209a-b098-4f3a-9f07-37fa3baab9b0", "user@recipes.daniil.page", true, "Ігор Куренко", false, null, "USER@RECIPES.DANIIL.PAGE", "USER@RECIPES.DANIIL.PAGE", "AQAAAAIAAYagAAAAEIFR5cItLXz053EfRfEi7tlurW1nt2ziGVT4dlpxQHvycRaUOW/bp03BwJZexDKplg==", null, false, "220c4d13-306d-4579-9a3f-442cb9a71f28", false, "user@recipes.daniil.page" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("37f02e99-2ac9-4fec-b807-0d1783e24255"), new Guid("8b5830ec-7a22-4b6e-95fe-66157fb56fab") },
                    { new Guid("e028a871-f98b-426d-97c5-5a945567d743"), new Guid("8b5830ec-7a22-4b6e-95fe-66157fb56fab") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionRecipe_RecipesId",
                table: "CollectionRecipe",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Recipes_RecipeId",
                table: "Reviews",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
