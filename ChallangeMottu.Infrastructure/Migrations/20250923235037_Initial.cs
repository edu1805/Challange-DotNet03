﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallangeMottu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_MOTOS-MOTTU",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false, defaultValueSql: "SYS_GUID()"),
                    PLACA = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Posicao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    STATUS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ULTIMA_ATUALIZACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MOTOS-MOTTU", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_LOCALIZACAO_ATUAL-MOTTU",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false, defaultValueSql: "SYS_GUID()"),
                    MotoId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CoordenadaX = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CoordenadaY = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DataHoraAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOCALIZACAO_ATUAL-MOTTU", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_LOCALIZACAO_ATUAL-MOTTU_T_MOTOS-MOTTU_MotoId",
                        column: x => x.MotoId,
                        principalTable: "T_MOTOS-MOTTU",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_LOCALIZACAO_ATUAL-MOTTU_MotoId",
                table: "T_LOCALIZACAO_ATUAL-MOTTU",
                column: "MotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_LOCALIZACAO_ATUAL-MOTTU");

            migrationBuilder.DropTable(
                name: "T_MOTOS-MOTTU");
        }
    }
}
