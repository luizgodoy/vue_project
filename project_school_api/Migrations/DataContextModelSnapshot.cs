﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project_school_api.Data;

namespace project_school_api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("project_school_api.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNascimento = "28/04/2015",
                            Nome = "Heitor",
                            ProfessorId = 4,
                            Sobrenome = "Godoy"
                        },
                        new
                        {
                            Id = 2,
                            DataNascimento = "29/05/2015",
                            Nome = "Gustavo",
                            ProfessorId = 3,
                            Sobrenome = "Godoy"
                        },
                        new
                        {
                            Id = 3,
                            DataNascimento = "02/09/1996",
                            Nome = "Gislaine",
                            ProfessorId = 2,
                            Sobrenome = "Fonseca"
                        },
                        new
                        {
                            Id = 4,
                            DataNascimento = "23/02/1994",
                            Nome = "Luiz",
                            ProfessorId = 1,
                            Sobrenome = "Godoy"
                        });
                });

            modelBuilder.Entity("project_school_api.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Samira",
                            Sobrenome = "Abila"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Rosa",
                            Sobrenome = "Arildo"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Rosa",
                            Sobrenome = "Cestari"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Heloisa",
                            Sobrenome = "Pasquini"
                        });
                });

            modelBuilder.Entity("project_school_api.Models.Aluno", b =>
                {
                    b.HasOne("project_school_api.Models.Professor", null)
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("project_school_api.Models.Professor", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}