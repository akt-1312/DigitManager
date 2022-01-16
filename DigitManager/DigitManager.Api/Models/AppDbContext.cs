using DigitManager.Api.Extensions;
using DigitManager.ModelLibrary;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<MainDigit> MainDigits { get; set; }
        public virtual DbSet<SubDigit> SubDigits { get; set; }
        public virtual DbSet<OwnerRefreshToken> OwnerRefreshTokens { get; set; }
        public virtual DbSet<AgentRefreshToken> AgentRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MainDigit>().Property(p => p.TotalAmmount).HasColumnType("decimal(18,2)");

            modelBuilder.SeedDefaultOwner();

            foreach (var foreighKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreighKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
