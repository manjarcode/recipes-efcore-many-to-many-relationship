using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManyToMany
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostImagesEntity>().HasKey(pi => new { pi.PostId, pi.ImageId });
        }

        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<ImageEntity> Images { get; set; }

        public DbSet<PostImagesEntity> PostImages { get; set; }
    }
}
