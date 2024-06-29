using Microsoft.EntityFrameworkCore;

namespace FinalWebAPI.Models
{
    public class CategoryDBContext : DbContext
    {
        public CategoryDBContext(DbContextOptions<CategoryDBContext> options):base(options)
        { 
        
        }

        public virtual DbSet<Category> Category { get; set; }
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<sp_StudentDetails> StudentDetails { get; set; }
        public DbSet<StudentNamesModel> StudentNames { get; set; }
        public DbSet<TempModel> TempModels { get; set; }
        public DbSet<TotalModel> TotalModels { get; set; }
        public DbSet<Student> Student { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(e => e.CategoryId);
            modelBuilder.Entity<sp_StudentDetails>().HasNoKey();
            modelBuilder.Entity<StudentNamesModel>().HasNoKey();
            modelBuilder.Entity<TempModel>().HasNoKey();
            modelBuilder.Entity<TotalModel>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
