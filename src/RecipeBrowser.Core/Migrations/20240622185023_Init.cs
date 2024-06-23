using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeBrowser.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CookingDifficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingDifficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CookingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipesCollections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipesCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipesCollections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookDuration = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifficultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_CookingDifficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "CookingDifficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_CookingTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CookingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeRecipeCollection",
                columns: table => new
                {
                    RecipeCollectionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRecipeCollection", x => new { x.RecipeCollectionsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_RecipeRecipeCollection_RecipesCollections_RecipeCollectionsId",
                        column: x => x.RecipeCollectionsId,
                        principalTable: "RecipesCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeRecipeCollection_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    MeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientRecipe",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientRecipe", x => new { x.IngredientsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Recipes_RecipesId",
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
                    { new Guid("19ff4917-4965-4bf7-9928-f191d90312ef"), "19ff4917-4965-4bf7-9928-f191d90312ef", "User", "USER" },
                    { new Guid("a2cbf6bf-a2d4-4ff3-8675-e4a0824de58c"), "a2cbf6bf-a2d4-4ff3-8675-e4a0824de58c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("4eb1e8b4-2338-4ede-8a2f-c68f4c8446e0"), 0, "5028db07-7946-41c7-a139-2bc3e04fcfbd", "admin@recipes.daniil.page", true, "Даниїл Максимчук", false, null, "ADMIN@RECIPES.DANIIL.PAGE", "ADMIN@RECIPES.DANIIL.PAGE", "AQAAAAIAAYagAAAAEDjN9+eH8s+ZjmoXQp3qkXyBN6YbH2yS3nVO738H7D6eHEtZTKQVjhlYpAaap2caeQ==", null, false, "687f7167-55c2-467d-9d6a-2f0845bc46e0", false, "admin@recipes.daniil.page" },
                    { new Guid("f9d6e91e-9f29-469f-8b33-b76cbd5a58dd"), 0, "68094007-3364-4cfe-96a2-0be9da0e4534", "user@recipes.daniil.page", true, "Ігор Куренко", false, null, "USER@RECIPES.DANIIL.PAGE", "USER@RECIPES.DANIIL.PAGE", "AQAAAAIAAYagAAAAEJYCHH5J11tg+vc9Ei5aGojFFFzvVsxk4U99gjw2RED0Dk53rGZaK1knDuCnxK+/IA==", null, false, "1c9fa65c-08b2-4625-b0c4-1b0b47260338", false, "user@recipes.daniil.page" }
                });

            migrationBuilder.InsertData(
                table: "CookingDifficulties",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("39ebc702-d2c9-4891-8091-b1bc9fc077d5"), "Легко" },
                    { new Guid("a281e0da-85fe-487e-9038-bf6eb9452a41"), "Нормально" },
                    { new Guid("e185f352-1858-40d5-80a4-d3aa2a370e9d"), "Важко" }
                });

            migrationBuilder.InsertData(
                table: "CookingTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("5637f96d-e698-4e14-9082-e79456cf0b08"), "Страви в мультиварці" },
                    { new Guid("6e6f391d-fe51-4b7b-97d9-09c04fcff2ef"), "Страви на плиті" },
                    { new Guid("6f4b8ddc-5151-4d2a-8a94-4f9a577faa4f"), "Страви в духовці" },
                    { new Guid("8272f94d-11b4-4989-afea-7a59bf381fd6"), "Стави в мікрохвильовці" },
                    { new Guid("b7267971-7380-477f-b66a-3c3ee020736b"), "Страви в пароварці" },
                    { new Guid("cb29269d-2e84-4d80-846d-1e7a349a14b9"), "Страви для грилю, барбекю, мангалу" },
                    { new Guid("da95aa37-1151-4230-b6f1-a248059fc29e"), "Страви без спеціальних пристосувань" }
                });

            migrationBuilder.InsertData(
                table: "Measures",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("46fe0cbb-25b0-4b4c-aaaf-7d8b72feff86"), "кг." },
                    { new Guid("472f3f67-13f9-459c-a0b7-58fda0ebd880"), "гр." },
                    { new Guid("59adbbec-05cc-491e-9e7d-4e72c550cf3b"), "л." },
                    { new Guid("75d31e01-b7f8-437a-b05e-3cd6d877f40a"), "штуки" },
                    { new Guid("b2a3d627-01ce-488f-8a32-ce0b81216734"), "стол. л." },
                    { new Guid("b4d40926-f149-4d45-82a2-c4a7b96aefec"), "мл." },
                    { new Guid("be5f4627-dad5-43cb-8250-11a4f71c10a3"), "чай. л." }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("3f947467-e012-4c89-b16f-e3d7c0e7d1f2"), "Овочі" },
                    { new Guid("53b62db2-48ca-4610-b4c5-72e1751e05c3"), "Морепродукти" },
                    { new Guid("a0042c07-dc00-4ae3-960a-d6a77eb71d71"), "Фрукти" },
                    { new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe"), "Інше" },
                    { new Guid("e430f677-4599-4072-92b5-0da47d960ddf"), "Спеції" },
                    { new Guid("e9339016-3639-44d8-b2d4-6adcc5c177b5"), "М'ясо" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a2cbf6bf-a2d4-4ff3-8675-e4a0824de58c"), new Guid("4eb1e8b4-2338-4ede-8a2f-c68f4c8446e0") },
                    { new Guid("19ff4917-4965-4bf7-9928-f191d90312ef"), new Guid("f9d6e91e-9f29-469f-8b33-b76cbd5a58dd") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "TypeId" },
                values: new object[,]
                {
                    { new Guid("0ca06b98-7e33-41f6-907d-6e26b58e6510"), "Паприка", new Guid("e430f677-4599-4072-92b5-0da47d960ddf") },
                    { new Guid("1b3ee351-e451-4c6e-a58b-cea36bc05f4c"), "Борошно", new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe") },
                    { new Guid("2c0b2a08-77d6-4d39-9be7-b5cd782314e2"), "Сир", new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe") },
                    { new Guid("3470c711-befd-4791-a60d-675416faf0d5"), "Яловичина", new Guid("e9339016-3639-44d8-b2d4-6adcc5c177b5") },
                    { new Guid("419b52ce-81f6-49b3-b584-59483c2d40b8"), "Цибуля", new Guid("3f947467-e012-4c89-b16f-e3d7c0e7d1f2") },
                    { new Guid("45a9a187-9956-4212-9a3a-5b1312075378"), "Помідор", new Guid("3f947467-e012-4c89-b16f-e3d7c0e7d1f2") },
                    { new Guid("54085a94-3f0b-41b8-9341-4603e144b236"), "Банан", new Guid("a0042c07-dc00-4ae3-960a-d6a77eb71d71") },
                    { new Guid("58b0cdc8-cad6-40d9-857a-9a8a51b5dff3"), "Свинина", new Guid("e9339016-3639-44d8-b2d4-6adcc5c177b5") },
                    { new Guid("60d8a783-c6fe-4c0e-aa48-4f115cb751f0"), "Огірок", new Guid("3f947467-e012-4c89-b16f-e3d7c0e7d1f2") },
                    { new Guid("634a0747-c87b-41fa-a663-815840d7a859"), "Філе лосося", new Guid("53b62db2-48ca-4610-b4c5-72e1751e05c3") },
                    { new Guid("72e7db96-063f-44d5-a893-c6ac5210b000"), "Морква", new Guid("3f947467-e012-4c89-b16f-e3d7c0e7d1f2") },
                    { new Guid("7905eb78-bbb5-4a69-bbce-a6b9a7748f76"), "Гриби", new Guid("3f947467-e012-4c89-b16f-e3d7c0e7d1f2") },
                    { new Guid("7c0d62d5-47f4-44d6-b030-baf73e04120a"), "Цукор", new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe") },
                    { new Guid("9b0c4795-6f93-4f21-8159-19d303aa2a76"), "Часник", new Guid("3f947467-e012-4c89-b16f-e3d7c0e7d1f2") },
                    { new Guid("aa631eb5-7245-48e6-85b5-a8ffdb0c246f"), "Масло", new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe") },
                    { new Guid("b31e448e-41db-4ab6-912c-9685fdeee279"), "Куряча грудка", new Guid("e9339016-3639-44d8-b2d4-6adcc5c177b5") },
                    { new Guid("b392b8be-3cb3-4ebe-b726-0c08a0f9433f"), "Чорний перець", new Guid("e430f677-4599-4072-92b5-0da47d960ddf") },
                    { new Guid("b577d403-235a-41be-a257-9a671a4c6f92"), "Сіль", new Guid("e430f677-4599-4072-92b5-0da47d960ddf") },
                    { new Guid("b94d438f-97bf-4232-a9b0-336187ce0c28"), "Яйця", new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe") },
                    { new Guid("bc3354d8-0e4c-450d-b7d1-37ddd5a2772b"), "Креветки", new Guid("53b62db2-48ca-4610-b4c5-72e1751e05c3") },
                    { new Guid("c20c7b03-fe0f-4d4f-bef4-377aa758d429"), "Тунець", new Guid("53b62db2-48ca-4610-b4c5-72e1751e05c3") },
                    { new Guid("c4ae9c39-1802-4514-85c8-1acc9aab62ae"), "Молоко", new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe") },
                    { new Guid("c91eec73-4c50-4173-9501-1b1f5f5c9b36"), "Бекон", new Guid("e9339016-3639-44d8-b2d4-6adcc5c177b5") },
                    { new Guid("d8585cf2-4666-45b2-9147-9eff953c3d65"), "Апельсин", new Guid("a0042c07-dc00-4ae3-960a-d6a77eb71d71") },
                    { new Guid("dc0a2c15-32e5-4e5d-9c05-905226dc5e1e"), "Яблуко", new Guid("a0042c07-dc00-4ae3-960a-d6a77eb71d71") },
                    { new Guid("e553faf1-3587-4893-a929-d063ba4b58c7"), "Хліб", new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe") },
                    { new Guid("eff9fa2f-d3f3-48d6-8226-c134795d6a9a"), "Оливкова олія", new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe") },
                    { new Guid("f1464541-9b0a-4403-82b5-bf21db9933fc"), "Сметана", new Guid("e26ae6d9-8883-4edd-abde-7ec1adae58fe") },
                    { new Guid("fc9597f1-2dc7-47b9-8419-7bbef6182380"), "Картопля", new Guid("3f947467-e012-4c89-b16f-e3d7c0e7d1f2") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientRecipe_RecipesId",
                table: "IngredientRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MeasureId",
                table: "Ingredients",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ProductId",
                table: "Ingredients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeCollection_RecipesId",
                table: "RecipeRecipeCollection",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatorId",
                table: "Recipes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DifficultyId",
                table: "Recipes",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_TypeId",
                table: "Recipes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipesCollections_UserId",
                table: "RecipesCollections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "IngredientRecipe");

            migrationBuilder.DropTable(
                name: "RecipeRecipeCollection");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "RecipesCollections");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CookingDifficulties");

            migrationBuilder.DropTable(
                name: "CookingTypes");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
