﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PreferenceManagement.API.Infrastructure.Database;

namespace PreferenceManagement.API.Migrations
{
    [DbContext(typeof(PreferenceContext))]
    [Migration("20220327105042_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PreferenceManagement.API.Domain.Entities.Preference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Key")
                        .HasColumnType("text")
                        .HasColumnName("key");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("level");

                    b.Property<string>("Solution")
                        .HasColumnType("text")
                        .HasColumnName("solution");

                    b.HasKey("Id")
                        .HasName("pk_preferences");

                    b.HasIndex("Key", "Solution")
                        .IsUnique()
                        .HasDatabaseName("ix_preferences_key_solution");

                    b.ToTable("preferences");

                    b.HasData(
                        new
                        {
                            Id = new Guid("042fc127-6690-4bbe-b6c7-7ad077f5c75f"),
                            Key = "DARK_MODE",
                            Level = "Solution",
                            Solution = "ExampleSolution"
                        },
                        new
                        {
                            Id = new Guid("40e5b4b2-19f4-4415-a9e2-509f39539e04"),
                            Key = "EMAIL_NOTIFICATIONS",
                            Level = "Solution",
                            Solution = "ExampleSolution"
                        },
                        new
                        {
                            Id = new Guid("2790c73d-3e15-4696-884d-c77e4e8d5d82"),
                            Key = "ANALYTICS_CONSENT",
                            Level = "Universal"
                        });
                });

            modelBuilder.Entity("PreferenceManagement.API.Domain.Entities.UserPreference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("PreferenceId")
                        .HasColumnType("uuid")
                        .HasColumnName("preference_id");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_user_preferences");

                    b.HasIndex("PreferenceId")
                        .HasDatabaseName("ix_user_preferences_preference_id");

                    b.HasIndex("UserId", "PreferenceId")
                        .IsUnique()
                        .HasDatabaseName("ix_user_preferences_user_id_preference_id");

                    b.ToTable("user_preferences");
                });

            modelBuilder.Entity("PreferenceManagement.API.Domain.Entities.UserPreference", b =>
                {
                    b.HasOne("PreferenceManagement.API.Domain.Entities.Preference", "Preference")
                        .WithMany()
                        .HasForeignKey("PreferenceId")
                        .HasConstraintName("fk_user_preferences_preferences_preference_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Preference");
                });
#pragma warning restore 612, 618
        }
    }
}