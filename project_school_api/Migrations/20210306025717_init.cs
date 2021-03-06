using Microsoft.EntityFrameworkCore.Migrations;

namespace project_school_api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<string>(type: "TEXT", nullable: true),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 1, "Samira", "Abila" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 2, "Rosa", "Arildo" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 3, "Rosa", "Cestari" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 4, "Heloisa", "Pasquini" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNascimento", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 4, "23/02/1994", "Luiz", 1, "Godoy" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNascimento", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 3, "02/09/1996", "Gislaine", 2, "Fonseca" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNascimento", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 2, "29/05/2015", "Gustavo", 3, "Godoy" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNascimento", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 1, "28/04/2015", "Heitor", 4, "Godoy" });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProfessorId",
                table: "Alunos",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
