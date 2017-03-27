using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeChallange.Models
{
    public class TeamscoreContext : DbContext
    {
        public TeamscoreContext(DbContextOptions<TeamscoreContext> options)
            : base(options)
        { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Member> Members { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Member>().ToTable("Member");
        }*/
    }
}



