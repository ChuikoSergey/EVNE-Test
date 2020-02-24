namespace EVNETest.Data.Context.Configurations
{
    using EVNETest.Core.Entities;
    using EVNETest.Data.Context.Configurations.Base;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.Property(u => u.Email)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.HasOne(u => u.Icon)
                .WithMany(f => f.Users)
                .HasForeignKey(u => u.IconId)
                .IsRequired(false);

            base.Configure(builder);
        }
    }
}