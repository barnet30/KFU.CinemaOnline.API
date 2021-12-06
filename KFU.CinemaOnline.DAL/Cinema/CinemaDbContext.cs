﻿using KFU.CinemaOnline.Core.Cinema;
using KFU.CinemaOnline.Core.Sql;
using Microsoft.EntityFrameworkCore;

namespace KFU.CinemaOnline.DAL.Cinema
{
    public class CinemaDbContext : EfDbContext
    {
        public DbSet<ActorEntity> Actors { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        
        public CinemaDbContext(DbContextOptions options) : base(options)
        {
        }
        
    }
}