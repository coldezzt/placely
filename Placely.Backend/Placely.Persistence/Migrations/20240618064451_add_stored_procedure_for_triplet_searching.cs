using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class add_stored_procedure_for_triplet_searching : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                create or replace function reservations_by_tenant_landlord_property_ids(
                    tenantId bigint, landlordId bigint, propertyId bigint)
                    returns setof reservations
                language plpgsql
                as $$
                    begin
                        return query 
                            select distinct on (r.id)
                            r.id, r.property_id, r.status_type, r.duration, r.entry_date, r.guests_amount,
                            r.creation_date_time, r.decline_reason, r.payment_amount, r.payment_frequency
                        from (select ru.reservations_id
                              from (select r.id as reservation_id 
                                    from reservations as r
                                    where r.property_id = propertyId) as ir
                                  join reservation_user as ru on ru.reservations_id = ir.reservation_id
                              where (ru.participants_id = tenantId or ru.participants_id = landlordId)
                                  and ru.reservations_id = ir.reservation_id
                              group by reservations_id
                              ) as fru
                                  join reservations as r on fru.reservations_id = r.id;
                    end;
                    $$;
                """
                );
            
            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 16, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 17, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 12, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 6, 17, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 5, 19, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 4, 19, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 29, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1090), new DateTime(2024, 6, 11, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1092) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 15, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1097), new DateTime(2024, 6, 18, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1098) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 15, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1100), new DateTime(2024, 6, 16, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 18, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1102), new DateTime(2024, 6, 22, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1103) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 8, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1109), new DateTime(2024, 6, 22, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 8, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1112), new DateTime(2024, 6, 22, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1113) });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 18, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 18, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 18, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateTime(2024, 6, 18, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateTime(2024, 6, 18, 6, 44, 50, 651, DateTimeKind.Utc).AddTicks(1146));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                drop function reservations_by_tenant_landlord_property_ids;
                """
                );
            
            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 16, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 17, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 12, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 6, 17, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 5, 19, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 4, 19, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 29, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7011), new DateTime(2024, 6, 11, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 15, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7026), new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 15, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7029), new DateTime(2024, 6, 16, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7032), new DateTime(2024, 6, 22, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7033) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 8, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7039), new DateTime(2024, 6, 22, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7039) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 8, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7042), new DateTime(2024, 6, 22, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7043) });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7079));
        }
    }
}
