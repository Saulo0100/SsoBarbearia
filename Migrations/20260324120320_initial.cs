using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SsoBarbearia.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DominioAutorizado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dominio = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DominioAutorizado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoSite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DominioId = table.Column<int>(type: "integer", nullable: false),
                    NomeSite = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<byte[]>(type: "bytea", nullable: true),
                    CorPrimaria = table.Column<string>(type: "text", nullable: false),
                    CorSecundaria = table.Column<string>(type: "text", nullable: false),
                    CorFundo = table.Column<string>(type: "text", nullable: false),
                    CorTexto = table.Column<string>(type: "text", nullable: false),
                    CorAcento = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoSite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoSite_DominioAutorizado_DominioId",
                        column: x => x.DominioId,
                        principalTable: "DominioAutorizado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoSite_DominioId",
                table: "ConfiguracaoSite",
                column: "DominioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracaoSite");

            migrationBuilder.DropTable(
                name: "DominioAutorizado");
        }
    }
}
