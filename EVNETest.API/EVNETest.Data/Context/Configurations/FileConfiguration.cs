namespace EVNETest.Data.Context.Configurations
{
    using EVNETest.Core.Entities;
    using EVNETest.Data.Context.Configurations.Base;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FileConfiguration : BaseEntityConfiguration<File>
    {
        public override void Configure(EntityTypeBuilder<File> builder)
        {
            builder.Property(f => f.Name)
                .IsRequired();

            builder.Property(f => f.Path)
                .IsRequired();

            builder.Property(f => f.MimeType)
                .IsRequired();
                
            base.Configure(builder);
        }
    }
}