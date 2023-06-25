using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Soa.Models;

namespace Soa.Data
{
    public class SoaContext : DbContext
    {
        public SoaContext(DbContextOptions<SoaContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            ///Book titles
            new Book() { Id = 1, Name = "lord of the rings"};
            new Book() { Id = 2, Name = "harry potter"};
            new Book() { Id = 3, Name = "game of thrones"};
            new Book() { Id = 4, Name = "Bridget jones diary"};
            new Book() { Id = 5, Name = "it" };

            modelBuilder.Entity<Book>().HasData(new Book
            {
                // Description with the book titles and the id that goes with the book title
                Id = 1,
                Name = "lord of the rings",
                Description = "The Lord of the Rings is the saga of a group of sometimes reluctant heroes who set forth to save their world from consummate evil.",
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 2,
                Name = " harry potter",
                Description = "Harry Potter is a series of seven fantasy novels written by British author J. K. Rowling.",
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 3,
                Name = "game of thrones",
                Description = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin.",
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 4,
                Name = " bridget jones diary",
                Description = "Bridget Jones, a thirty-something single working woman living in London. She writes about her career, self-image, vices, family, friends, and romantic relationships.",
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 5,
                Name = "1t",
                Description = "The story follows the experiences of seven children as they are terrorized by an evil entity that exploits the fears of its victims to disguise itself while hunting its prey",
            });
        }
       
    }
}


