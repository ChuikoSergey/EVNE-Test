namespace EVNETest.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using EVNETest.Core.Entities.Base;

    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organization { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Link { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<ProjectAttachment> Attachments { get; set; }
    }
}