﻿// <auto-generated />
using System;
using BigGameSurvey.Api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BigGameSurvey.Api.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20200915031214_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BigGameSurvey.Api.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GenreId")
                        .HasColumnName("FK_GENRE")
                        .HasColumnType("integer");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnName("DS_PLATFORM")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("DS_TITLE")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("TB_GAME");
                });

            modelBuilder.Entity("BigGameSurvey.Api.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("DS_NAME")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TB_GENRE");
                });

            modelBuilder.Entity("BigGameSurvey.Api.Entities.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("GameId")
                        .HasColumnName("FK_GAME")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InsertedAt")
                        .HasColumnName("DT_INSERTEDAT")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("DS_NAME")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("TB_RECORD");
                });

            modelBuilder.Entity("BigGameSurvey.Api.Entities.Game", b =>
                {
                    b.HasOne("BigGameSurvey.Api.Entities.Genre", "Genre")
                        .WithMany("Games")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BigGameSurvey.Api.Entities.Record", b =>
                {
                    b.HasOne("BigGameSurvey.Api.Entities.Game", "Game")
                        .WithMany("Records")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
