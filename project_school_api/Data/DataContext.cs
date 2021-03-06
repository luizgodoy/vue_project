namespace project_school_api.Data
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using project_school_api.Models;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base ( options) {}

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Professor>()
                .HasData(
                    new List<Professor>() {
                        new Professor() {
                            Id = 1,
                            Nome = "Samira",
                            Sobrenome = "Abila"
                        },
                        new Professor() {
                            Id = 2,
                            Nome = "Rosa",
                            Sobrenome = "Arildo"
                        },
                        new Professor() {
                            Id = 3,
                            Nome = "Rosa",
                            Sobrenome = "Cestari"
                        },
                        new Professor() {
                            Id = 4,
                            Nome = "Heloisa",
                            Sobrenome = "Pasquini"
                        }
                    }
                );

                builder.Entity<Aluno>()
                .HasData(
                    new List<Aluno>() {
                        new Aluno() {
                            Id = 1,
                            Nome = "Heitor",
                            Sobrenome = "Godoy",
                            DataNascimento = "28/04/2015",
                            ProfessorId = 4
                        },
                        new Aluno() {
                            Id = 2,
                            Nome = "Gustavo",
                            Sobrenome = "Godoy",
                            DataNascimento = "29/05/2015",
                            ProfessorId = 3
                        },
                        new Aluno() {
                            Id = 3,
                            Nome = "Gislaine",
                            Sobrenome = "Fonseca",
                            DataNascimento = "02/09/1996",
                            ProfessorId = 2
                        },
                        new Aluno() {
                            Id = 4,
                            Nome = "Luiz",
                            Sobrenome = "Godoy",
                            DataNascimento = "23/02/1994",
                            ProfessorId = 1
                        }
                    }
                );
        }
    }
}