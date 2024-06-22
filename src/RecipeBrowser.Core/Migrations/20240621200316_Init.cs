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
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_CookingDifficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "CookingDifficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_CookingTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CookingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("0fab1bbb-1a68-42b1-8c19-a8afb2bb82f7"), "0fab1bbb-1a68-42b1-8c19-a8afb2bb82f7", "Admin", "ADMIN" },
                    { new Guid("24145a30-2ae3-403c-b8ad-9e8a77cef681"), "24145a30-2ae3-403c-b8ad-9e8a77cef681", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("27c9b183-5bf7-4994-b6e1-316200a5be15"), 0, "b09886d0-fda3-4faf-8212-a6269a273094", "user@recipes.daniil.page", true, "Ігор Куренко", false, null, "USER@RECIPES.DANIIL.PAGE", "USER@RECIPES.DANIIL.PAGE", "AQAAAAIAAYagAAAAEJGdrLDGUD2Q6sakOx4jukNIUCIzWySXu+MZP4IN+z0oSmABI8bWsiTNdraj4DWjWA==", null, false, "de5c715f-4728-4861-b63a-7be07e4e7be8", false, "user@recipes.daniil.page" },
                    { new Guid("849daba3-4df2-463f-a569-40ff9b153eab"), 0, "05e36589-d08c-492f-b843-ce597dc88687", "admin@recipes.daniil.page", true, "Даниїл Максимчук", false, null, "ADMIN@RECIPES.DANIIL.PAGE", "ADMIN@RECIPES.DANIIL.PAGE", "AQAAAAIAAYagAAAAEM8AIIDBDkkMfRCv5ZVr5Nbuw50Qnz7rh3fEz0zwuCyx/ximg08pTMgH8kwtqjbBYQ==", null, false, "79a8de0b-461d-4f83-940d-117810bde414", false, "admin@recipes.daniil.page" }
                });

            migrationBuilder.InsertData(
                table: "CookingDifficulties",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("4e798cb2-0525-481f-bc99-7879697ae4e6"), "Важко" },
                    { new Guid("b3df4de4-e14b-4c6a-9f43-ca9b7049546f"), "Нормально" },
                    { new Guid("f164daed-eb51-41af-9be2-97c6cbe303e8"), "Легко" }
                });

            migrationBuilder.InsertData(
                table: "CookingTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("04bad01c-fe40-429c-9273-8c2e40748d41"), "Страви в духовці" },
                    { new Guid("31ca0b8e-aa19-4ac3-a71a-8c35fce947fa"), "Страви без спеціальних пристосувань" },
                    { new Guid("4b38af40-2aac-410e-ac40-e0b9ffd9d7c5"), "Страви в пароварці" },
                    { new Guid("545688a7-b95a-489b-aba3-327dcb666a98"), "Страви в мультиварці" },
                    { new Guid("9b6d41d1-63c2-47ed-aaf2-273cbcf3b24b"), "Страви для грилю, барбекю, мангалу" },
                    { new Guid("cffae68f-1d50-4f82-8c7f-848832e22b7c"), "Страви на плиті" },
                    { new Guid("d339528f-48e6-4fed-b27d-ea8c44662da7"), "Стави в мікрохвильовці" }
                });

            migrationBuilder.InsertData(
                table: "Measures",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("39001dbc-9bbe-4514-ab30-89d2d553dcf8"), "кг." },
                    { new Guid("533dacc7-25c0-463a-a163-23625942273f"), "стол. л." },
                    { new Guid("84437f08-1b7a-4822-90e1-debe10c0ec5d"), "чай. л." },
                    { new Guid("9aeb1547-b29b-455b-92a8-a3fd0c48329a"), "штуки" },
                    { new Guid("b7232647-f78b-4d98-a12a-c37d6ebef199"), "гр." },
                    { new Guid("bd10f730-51ae-4ada-aa56-4ef53bef873d"), "мл." },
                    { new Guid("c71cfd22-ad07-4053-8191-796a29fc129d"), "л." }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1eec1638-caf1-4649-95b0-4431685cc83c"), "М'ясо" },
                    { new Guid("547aba09-7f60-4a37-928b-d8e798e89810"), "Фрукти" },
                    { new Guid("5b7cbc8e-649b-4752-9140-db0f87d88d3e"), "Морепродукти" },
                    { new Guid("800e323a-9c7d-44db-9eb7-df5961eeda03"), "Овочі" },
                    { new Guid("bad4a9ee-9d2c-4f6c-92e2-c86aecee7f8a"), "Спеції" },
                    { new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba"), "Інше" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("24145a30-2ae3-403c-b8ad-9e8a77cef681"), new Guid("27c9b183-5bf7-4994-b6e1-316200a5be15") },
                    { new Guid("0fab1bbb-1a68-42b1-8c19-a8afb2bb82f7"), new Guid("849daba3-4df2-463f-a569-40ff9b153eab") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "TypeId" },
                values: new object[,]
                {
                    { new Guid("01410476-a431-4ff8-8184-d95f2a371bb6"), "Філе лосося", new Guid("5b7cbc8e-649b-4752-9140-db0f87d88d3e") },
                    { new Guid("1f9d264c-2b3f-45b5-aed3-01819a58dd42"), "Банан", new Guid("547aba09-7f60-4a37-928b-d8e798e89810") },
                    { new Guid("2e7829e2-0532-4050-b508-f73429f7711d"), "Креветки", new Guid("5b7cbc8e-649b-4752-9140-db0f87d88d3e") },
                    { new Guid("3101037d-5593-42c6-b57a-7933c8b5af27"), "Молоко", new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba") },
                    { new Guid("3dbd9d2f-92c6-4d57-9297-1c3fcd4d3e8b"), "Бекон", new Guid("1eec1638-caf1-4649-95b0-4431685cc83c") },
                    { new Guid("4655e502-06f3-496d-b8c3-598a7f0c4d3f"), "Яйця", new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba") },
                    { new Guid("532a8663-0912-4dc7-b8b6-e8215c0a4a48"), "Борошно", new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba") },
                    { new Guid("55626a02-ca0f-4a81-bfae-ea2899411463"), "Свинина", new Guid("1eec1638-caf1-4649-95b0-4431685cc83c") },
                    { new Guid("55c3cd9b-b895-4b2a-9050-96f6e471829e"), "Огірок", new Guid("800e323a-9c7d-44db-9eb7-df5961eeda03") },
                    { new Guid("5976e4c3-80ce-4c77-9c72-dc20a4c859e1"), "Куряча грудка", new Guid("1eec1638-caf1-4649-95b0-4431685cc83c") },
                    { new Guid("692f0450-3212-427a-a7d3-8ca9cb8330bc"), "Сіль", new Guid("bad4a9ee-9d2c-4f6c-92e2-c86aecee7f8a") },
                    { new Guid("6e500bb5-2fd9-4a3c-a1e7-1ff2c86648ec"), "Чорний перець", new Guid("bad4a9ee-9d2c-4f6c-92e2-c86aecee7f8a") },
                    { new Guid("7176ffb5-d43f-4886-a715-f31fb9bfb28f"), "Масло", new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba") },
                    { new Guid("72995674-8eca-45d5-ac25-7c757653f3d6"), "Паприка", new Guid("bad4a9ee-9d2c-4f6c-92e2-c86aecee7f8a") },
                    { new Guid("89a84382-7efd-4718-adc5-bd5a0f1b2ca2"), "Морква", new Guid("800e323a-9c7d-44db-9eb7-df5961eeda03") },
                    { new Guid("8c717611-5097-4d55-b191-c73373278261"), "Сир", new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba") },
                    { new Guid("8cad01bc-7154-4cc1-9e49-f8ed41c36977"), "Часник", new Guid("800e323a-9c7d-44db-9eb7-df5961eeda03") },
                    { new Guid("8cc83a55-f0d2-47af-b9a0-0eeac6274593"), "Яблуко", new Guid("547aba09-7f60-4a37-928b-d8e798e89810") },
                    { new Guid("9e95e656-cb87-4ffe-9b50-c9940f58d78c"), "Яловичина", new Guid("1eec1638-caf1-4649-95b0-4431685cc83c") },
                    { new Guid("9f18c098-214b-4501-80f0-ab271ad13e3f"), "Тунець", new Guid("5b7cbc8e-649b-4752-9140-db0f87d88d3e") },
                    { new Guid("aa64f4d3-32ad-46e7-b28a-2c7a524dec40"), "Оливкова олія", new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba") },
                    { new Guid("ab473080-72c4-4d8c-b8f2-a094c75f523e"), "Сметана", new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba") },
                    { new Guid("afd3dc62-0de8-4ad4-86cd-10edbd8cbb2c"), "Цукор", new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba") },
                    { new Guid("b103f6e9-219c-4031-8405-506e0ced9b35"), "Помідор", new Guid("800e323a-9c7d-44db-9eb7-df5961eeda03") },
                    { new Guid("b397c686-e9c3-406b-b8ed-5c7f2922570d"), "Картопля", new Guid("800e323a-9c7d-44db-9eb7-df5961eeda03") },
                    { new Guid("d47b497b-c5bb-4493-917f-f4455d4caa76"), "Гриби", new Guid("800e323a-9c7d-44db-9eb7-df5961eeda03") },
                    { new Guid("e4e613dd-6203-4ce0-91f6-b31c34ec7112"), "Цибуля", new Guid("800e323a-9c7d-44db-9eb7-df5961eeda03") },
                    { new Guid("ecd43716-77f6-4274-b1de-f57a46b65b48"), "Хліб", new Guid("cdc837a0-06d7-4a7f-ba86-a539565892ba") },
                    { new Guid("f3c2427a-4bfc-4736-903c-e830e0cd6841"), "Апельсин", new Guid("547aba09-7f60-4a37-928b-d8e798e89810") }
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
