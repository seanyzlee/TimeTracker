﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Client 1" },
                    { 2L, "Client 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "HourRate", "Name" },
                values: new object[,]
                {
                    { 1L, 25m, "John Doe" },
                    { 2L, 30m, "Joan Doe" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClientId", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "Project 1" },
                    { 2L, 1L, "Project 2" },
                    { 3L, 2L, "Project 3" }
                });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Description", "EntryDate", "HourRate", "Hours", "ProjectId", "UserId" },
                values: new object[,]
                {
                    { 1L, "Time entry description 1", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 5, 1L, 1L },
                    { 2L, "Time entry description 2", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 2, 2L, 1L },
                    { 3L, "Time entry description 3", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1, 3L, 1L },
                    { 4L, "Time entry description 4", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, 8, 3L, 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
