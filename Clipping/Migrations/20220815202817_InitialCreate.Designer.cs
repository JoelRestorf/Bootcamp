﻿// <auto-generated />
using System;
using Clipping.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clipping.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220815202817_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clipping.Models.Noticia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autor")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("DateTime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Fonte")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ImagemURL")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Negativa")
                        .HasColumnType("bit");

                    b.Property<bool>("Neutra")
                        .HasColumnType("bit");

                    b.Property<bool>("Positiva")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Noticias");
                });
#pragma warning restore 612, 618
        }
    }
}
