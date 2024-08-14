using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace library_managment_system.Models
{
    public class Context :DbContext
    {
        public Context() : base()
        { }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=.;Initial Catalog=LibraryDb;Integrated Security=True;Encrypt=False");
            
        }
    }
}
