using Microsoft.EntityFrameworkCore;
using System;

namespace DotNetCore_RestApi_Sqlite
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<SubItem> SubItems { get; set; }

        // Seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Author = "Author1",
                    Content = "Content1",
                    Title = "Title1"
                },
                new
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    Author = "Author2",
                    Content = "Content2",
                    Title = "Title2"
                }
            );

            modelBuilder.Entity<SubItem>().HasData(
                new
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Author = "SubAuthor1",
                    SubContent = "SubContent1",
                    SubTitle = "SubTitle1",
                    ItemId = 1
                },
                new
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    Author = "SubAuthor2",
                    SubContent = "SubContent2",
                    SubTitle = "SubTitle2",
                    ItemId = 2
                }
            );
        }
    }
}