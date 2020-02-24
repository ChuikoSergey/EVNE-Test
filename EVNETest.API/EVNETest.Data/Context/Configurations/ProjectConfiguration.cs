namespace EVNETest.Data.Context.Configurations
{
    using EVNETest.Core.Entities;
    using EVNETest.Data.Context.Configurations.Base;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjectConfiguration : BaseEntityConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder) 
        {
            builder.HasIndex(p => p.Title)
                .IsUnique();

            builder.Property(p => p.Title)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2000);
            
            builder.HasMany(p => p.Attachments)
                .WithOne(pa => pa.Project)
                .HasForeignKey(pa => pa.ProjectId);

            base.Configure(builder);
        }
    }
}