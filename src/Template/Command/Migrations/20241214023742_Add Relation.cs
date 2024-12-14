using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.Command.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressHistorys_Address_AddressId",
                table: "AddressHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryConsultations_Consultations_ConsultationId",
                table: "HistoryConsultations");

            migrationBuilder.DropColumn(
                name: "IdConsult",
                table: "HistoryConsultations");

            migrationBuilder.DropColumn(
                name: "IdAddres",
                table: "AddressHistorys");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsultationId",
                table: "HistoryConsultations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "AddressHistorys",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressHistorys_Address_AddressId",
                table: "AddressHistorys",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryConsultations_Consultations_ConsultationId",
                table: "HistoryConsultations",
                column: "ConsultationId",
                principalTable: "Consultations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressHistorys_Address_AddressId",
                table: "AddressHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryConsultations_Consultations_ConsultationId",
                table: "HistoryConsultations");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsultationId",
                table: "HistoryConsultations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "IdConsult",
                table: "HistoryConsultations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "AddressHistorys",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "IdAddres",
                table: "AddressHistorys",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_AddressHistorys_Address_AddressId",
                table: "AddressHistorys",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryConsultations_Consultations_ConsultationId",
                table: "HistoryConsultations",
                column: "ConsultationId",
                principalTable: "Consultations",
                principalColumn: "Id");
        }
    }
}
