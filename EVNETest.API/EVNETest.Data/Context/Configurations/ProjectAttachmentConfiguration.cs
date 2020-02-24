namespace EVNETest.Data.Context.Configurations
{
    using EVNETest.Core.Entities;
    using EVNETest.Data.Context.Configurations.Base;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjectAttachmentConfiguration : BaseEntityConfiguration<ProjectAttachment>
    {
        public override void Configure(EntityTypeBuilder<ProjectAttachment> builder)
        {
            builder.HasOne(pa => pa.Project)
                .WithMany(p => p.Attachments)
                .HasForeignKey(pa => pa.ProjectId);

            builder.HasOne(pa => pa.File)
                .WithMany(f => f.ProjectAttachments)
                .HasForeignKey(pa => pa.FileId);

            base.Configure(builder);
        }
    }
}