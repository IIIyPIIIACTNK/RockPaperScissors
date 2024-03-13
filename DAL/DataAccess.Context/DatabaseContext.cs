using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Матчи
        /// </summary>
        public DbSet<Match> Matches { get; set; }
        /// <summary>
        /// Транзакции
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }
        /// <summary>
        /// Транзакции матче
        /// </summary>
        public DbSet<GameTransactions> GameTransactions { get; set; }
        /// <summary>
        /// Результаты матчей
        /// </summary>
        public DbSet<MatchHistory> MatchHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .ToTable("users");
            modelBuilder.Entity<Match>()
                .ToTable("matches");
            modelBuilder.Entity<Transaction>()
                .ToTable("transactions");
            modelBuilder.Entity<GameTransactions>()
                .ToTable("gametransactions");
            modelBuilder.Entity<MatchHistory>()
                .ToTable("matcheshistories");
        }
    }
}

