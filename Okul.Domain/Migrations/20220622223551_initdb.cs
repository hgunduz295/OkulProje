using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Okul.Domain.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BransAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branslar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "user"),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siniflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniflar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gsm = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Maas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BransId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogretmenler_Branslar_BransId",
                        column: x => x.BransId,
                        principalTable: "Branslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gsm = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SinifId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogrenciler_Siniflar_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Siniflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SinifId = table.Column<int>(type: "int", nullable: false),
                    BransId = table.Column<int>(type: "int", nullable: false),
                    OgretmenId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planlar_Branslar_BransId",
                        column: x => x.BransId,
                        principalTable: "Branslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planlar_Ogretmenler_OgretmenId",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planlar_Siniflar_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Siniflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yoklamalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoklamalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yoklamalar_Ogrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yoklamalar_Planlar_PlanID",
                        column: x => x.PlanID,
                        principalTable: "Planlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Branslar",
                columns: new[] { "Id", "BransAdi", "CreateDate" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Fizik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Muzik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Tarih", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Kimya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Edebiyat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Siniflar",
                columns: new[] { "Id", "CreateDate", "Kapasite", "SinifAdi" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "11A" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "12A" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "13A" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "14A" }
                });

            migrationBuilder.InsertData(
                table: "Ogrenciler",
                columns: new[] { "Id", "Adi", "Cinsiyet", "CreateDate", "DogumTarihi", "Email", "Gsm", "SinifId", "Soyadi", "TcNo" },
                values: new object[] { 1, "Ali", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Veli", "12345678901" });

            migrationBuilder.InsertData(
                table: "Ogretmenler",
                columns: new[] { "Id", "Adi", "BransId", "Cinsiyet", "CreateDate", "DogumTarihi", "Email", "Gsm", "Maas", "Soyadi", "TcNo" },
                values: new object[] { 1, "Ayse", 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0m, "Yilmaz", "12345678901" });

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_SinifId",
                table: "Ogrenciler",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmenler_BransId",
                table: "Ogretmenler",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_Planlar_BransId",
                table: "Planlar",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_Planlar_OgretmenId",
                table: "Planlar",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_Planlar_SinifId",
                table: "Planlar",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_Yoklamalar_OgrenciId",
                table: "Yoklamalar",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_Yoklamalar_PlanID",
                table: "Yoklamalar",
                column: "PlanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Yoklamalar");

            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Planlar");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropTable(
                name: "Siniflar");

            migrationBuilder.DropTable(
                name: "Branslar");
        }
    }
}
