using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LanguageInstall.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MainTables",
                columns: new[] { "ID", "EnglishText" },
                values: new object[,]
                {
                    { 1, "First Name" },
                    { 2, "Last Name" },
                    { 3, "Submit" },
                    { 4, "Home" },
                    { 5, "Human Resource Management" },
                    { 6, "Leave Management" },
                    { 7, "Operation" },
                    { 8, "Leave Application Entry" },
                    { 9, "Company" },
                    { 10, "Employee ID" },
                    { 11, "Employee Name" },
                    { 12, "Designation" },
                    { 13, "Department" },
                    { 14, "Immediate Supervisor" },
                    { 15, "Head of Department" },
                    { 16, "Apply Leave Format" },
                    { 17, "Leave Type" },
                    { 18, "From" },
                    { 19, "Day(s)" },
                    { 20, "To" },
                    { 21, "Half Day" },
                    { 22, "First Half" },
                    { 23, "Second Half" },
                    { 24, "File Attachment" },
                    { 25, "Reason" },
                    { 26, "Leave Apply" },
                    { 27, "Select Dropdown Options" },
                    { 28, "--Select--" },
                    { 29, "--Select Apply Leave Format--" },
                    { 30, "Half Day Leave" },
                    { 31, "Full Day Leave" },
                    { 32, "Short Leave" },
                    { 33, "--Select--" },
                    { 34, "Button and Action Text" },
                    { 35, "Leave Apply" },
                    { 36, "Half Day" },
                    { 37, "Full Day" },
                    { 38, "Short Leave" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MainTables",
                keyColumn: "ID",
                keyValue: 38);
        }
    }
}
