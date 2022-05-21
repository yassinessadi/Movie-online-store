using Microsoft.EntityFrameworkCore;
using Movie_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_app.Data
{
    public class AppDbConetext:DbContext
    {
        public AppDbConetext(DbContextOptions<AppDbConetext> options) :base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(k => new
            {
                k.ActorId,
                k.MovieId
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(ky => ky.Movie).WithMany(k => k.Actor_Movies).HasForeignKey(kys => kys.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(ky => ky.Actor).WithMany(k => k.Actor_Movies).HasForeignKey(kys => kys.ActorId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cenima> Cenimas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }

    }
}
