﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Context.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.GameTransactions", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("MatchId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("gametransactions", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Match", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal>("Bid")
                        .HasColumnType("numeric");

                    b.Property<string>("Player1Id")
                        .HasColumnType("text");

                    b.Property<string>("Player2Id")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.ToTable("matches", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.MatchHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("LosserId")
                        .HasColumnType("text");

                    b.Property<string>("TransactionsId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WinnerId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LosserId");

                    b.HasIndex("TransactionsId");

                    b.HasIndex("WinnerId");

                    b.ToTable("matcheshistories", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal>("Ammount")
                        .HasColumnType("numeric");

                    b.Property<string>("GameTransactionsId")
                        .HasColumnType("text");

                    b.Property<string>("RecivierId")
                        .HasColumnType("text");

                    b.Property<string>("SenderId")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeOfTransation")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GameTransactionsId");

                    b.HasIndex("RecivierId");

                    b.HasIndex("SenderId");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.GameTransactions", b =>
                {
                    b.HasOne("DataAccess.Entities.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("DataAccess.Entities.Match", b =>
                {
                    b.HasOne("DataAccess.Entities.User", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id");

                    b.HasOne("DataAccess.Entities.User", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id");

                    b.Navigation("Player1");

                    b.Navigation("Player2");
                });

            modelBuilder.Entity("DataAccess.Entities.MatchHistory", b =>
                {
                    b.HasOne("DataAccess.Entities.User", "Losser")
                        .WithMany()
                        .HasForeignKey("LosserId");

                    b.HasOne("DataAccess.Entities.GameTransactions", "Transactions")
                        .WithMany()
                        .HasForeignKey("TransactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.User", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Losser");

                    b.Navigation("Transactions");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("DataAccess.Entities.Transaction", b =>
                {
                    b.HasOne("DataAccess.Entities.GameTransactions", null)
                        .WithMany("Transactions")
                        .HasForeignKey("GameTransactionsId");

                    b.HasOne("DataAccess.Entities.User", "Recivier")
                        .WithMany()
                        .HasForeignKey("RecivierId");

                    b.HasOne("DataAccess.Entities.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Recivier");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DataAccess.Entities.GameTransactions", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
