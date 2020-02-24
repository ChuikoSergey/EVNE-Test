namespace EVNETest.Data.Context
{
    using System.IO;
    using EVNETest.Core.Entities;
    using EVNETest.Data.Context.Configurations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class DataContext : DbContext
    {
        #region Sets

        public DbSet<Core.Entities.File> Files { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAttachment> ProjectAttachments { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region DbContext base

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .AddEnvironmentVariables()
                                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultDatabase"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectAttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
            
        #endregion
    }
}