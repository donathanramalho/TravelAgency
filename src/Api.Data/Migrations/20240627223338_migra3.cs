using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class migra3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UfEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Sigla = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UfEntity", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MunicipioOrigem = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UfIdOrigem = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MunicipioDestino = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UfIdDestino = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    UfEntityId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_UfEntity_UfEntityId",
                        column: x => x.UfEntityId,
                        principalTable: "UfEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Package_UfEntity_UfIdDestino",
                        column: x => x.UfIdDestino,
                        principalTable: "UfEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_UfEntity_UfIdOrigem",
                        column: x => x.UfIdOrigem,
                        principalTable: "UfEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserEntityId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PackageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BookingDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 10, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Package_Id",
                        column: x => x.Id,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_User_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BookingId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "UfEntity",
                columns: new[] { "Id", "CreateAt", "Nome", "Sigla", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("077287b0-98de-4726-9f10-12267712f8c4"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4747), "Pernambuco", "PE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("08fb1856-941c-4782-bb82-dd6fdd3a2179"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4711), "Ceará", "CE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("169058b5-7bb6-4222-a93a-5956ae09d6ea"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4762), "Rio Grande do Norte", "RN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c39f56e-fbe8-4190-b35f-3cce709874c8"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4759), "Rio de Janeiro", "RJ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3ea98204-4ed9-43cb-9cde-111485afe732"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4693), "Alagoas", "AL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44eedc4d-a27e-4401-ac9b-a27a667924cc"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4714), "Distrito Federal", "DF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("521c2477-9245-47ec-a917-6af162483adf"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4773), "Santa Catarina", "SC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("542b965a-5fe5-4e0d-8f17-23d668b26248"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4696), "Amazonas", "AM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("55879f97-068c-40e4-8f86-4ef874877b4f"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4720), "Goiás", "GO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c16e29a-ff39-4501-bed7-6e03c04e7fae"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4768), "Roraima", "RR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c7b3e08-9179-4bb6-bd21-1fc057268590"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4771), "Rio Grande do Sul", "RS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("774d005b-bf2d-4c73-b6c8-5e3b347d8fa1"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4782), "São Paulo", "SP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("77ca71b7-3de6-41a0-a48b-6ed355cedf03"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4738), "Mato Grosso", "MT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("85b39d38-ffdb-4289-aed9-7ed5ad09af92"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4756), "Paraná", "PR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8d69d13c-9f6e-472d-ad2a-0fd38d92a211"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4729), "Maranhão", "MA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2945332-5ee7-4029-aa3e-503a27ad52a0"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4765), "Rondônia", "RO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b565bfdc-2741-4e88-83b7-9c1d21fc148f"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4665), "Acre", "AC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf97ed9f-0147-4f1a-837b-5a12bd5c55a6"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4703), "Bahia", "BA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6d4e591-b20a-4d12-a581-ee72d0da759a"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4734), "Mato Grosso do Sul", "MS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d71320ad-783c-4474-b10f-48906caa64ee"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4744), "Paraíba", "PB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("de4f52c4-e25b-40ea-9eff-4990be81e8c4"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4717), "Espírito Santo", "ES", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e247cc51-087c-4058-82a8-37ed01cb1149"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4749), "Piauí", "PI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3776188-8951-449c-80c0-b35e69184a1f"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4785), "Tocantins", "TO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef8f0319-b44e-46c4-a35a-476c7426c4ec"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4741), "Pará", "PA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("efbf4f41-4133-404e-bde9-0516a91576d7"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4700), "Amapá", "AP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f0a23bcf-8752-4a02-9323-68ce83d0fd74"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4732), "Minas Gerais", "MG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f42777bf-25e1-441a-a6d3-61814a7944a6"), new DateTime(2024, 6, 27, 22, 33, 38, 280, DateTimeKind.Utc).AddTicks(4776), "Sergipe", "SE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserEntityId",
                table: "Booking",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_UfEntityId",
                table: "Package",
                column: "UfEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_UfIdDestino",
                table: "Package",
                column: "UfIdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Package_UfIdOrigem",
                table: "Package",
                column: "UfIdOrigem");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BookingId",
                table: "Payment",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UfEntity");
        }
    }
}
