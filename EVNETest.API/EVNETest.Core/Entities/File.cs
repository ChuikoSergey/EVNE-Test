namespace EVNETest.Core.Entities
{
    using System.Collections.Generic;
    using EVNETest.Core.Entities.Base;

    public class File : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }
        public string MimeType { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<ProjectAttachment> ProjectAttachments { get; set; }
    }
}