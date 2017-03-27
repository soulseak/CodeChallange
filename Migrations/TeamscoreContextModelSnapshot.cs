using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CodeChallange.Models;

namespace CodeChallange.Migrations
{
    [DbContext(typeof(TeamscoreContext))]
    partial class TeamscoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeChallange.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ScoreTeam1");

                    b.Property<int>("ScoreTeam2");

                    b.Property<int?>("Team1IdTeamId");

                    b.Property<int?>("Team2IdTeamId");

                    b.HasKey("MatchId");

                    b.HasIndex("Team1IdTeamId");

                    b.HasIndex("Team2IdTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("CodeChallange.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CodeChallange.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MemberId");

                    b.Property<string>("Name");

                    b.HasKey("TeamId");

                    b.HasIndex("MemberId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("CodeChallange.Models.Match", b =>
                {
                    b.HasOne("CodeChallange.Models.Team", "Team1Id")
                        .WithMany()
                        .HasForeignKey("Team1IdTeamId");

                    b.HasOne("CodeChallange.Models.Team", "Team2Id")
                        .WithMany()
                        .HasForeignKey("Team2IdTeamId");
                });

            modelBuilder.Entity("CodeChallange.Models.Team", b =>
                {
                    b.HasOne("CodeChallange.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");
                });
        }
    }
}
