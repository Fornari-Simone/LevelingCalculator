using LevelingCalculator.Repository.Model;
using Microsoft.EntityFrameworkCore;


namespace LevelingCalculator.Repository
{
    public class LevelingCalculatorDbContext : DbContext 
    {
        public LevelingCalculatorDbContext(DbContextOptions<LevelingCalculatorDbContext> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging();
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chiave primaria
            modelBuilder.Entity<Character>().HasKey(x => x.ID);
            modelBuilder.Entity<Resource>().HasKey(x => x.ID);
            modelBuilder.Entity<CharRes>().HasKey(x => x.ID);
            //base.OnModelCreating(modelBuilder);

            // Foreign key
            modelBuilder.Entity<Character>().HasMany(x => x.char_ass).WithOne(x => x.character).HasForeignKey(x => x.IDChar);
            modelBuilder.Entity<Resource>().HasMany(x => x.res_ass).WithOne(x => x.resource).HasForeignKey(x => x.IDRes1);
            modelBuilder.Entity<Resource>().HasMany(x => x.res_ass).WithOne(x => x.resource).HasForeignKey(x => x.IDRes2);
            modelBuilder.Entity<Resource>().HasMany(x => x.res_ass).WithOne(x => x.resource).HasForeignKey(x => x.IDRes3);

            // Auto-increment
            modelBuilder.Entity<CharRes>().Property(x => x.ID).ValueGeneratedOnAdd();
        }

        public DbSet<Resource> Resource { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<CharRes> CharRes { get; set; }
    }
}
