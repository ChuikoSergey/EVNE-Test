namespace EVNETest.Core.Entities
{
    using System;
    using EVNETest.Core.Entities.Base;

    public class ProjectAttachment : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}