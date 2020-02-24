namespace EVNETest.Core.Entities
{
    using System;
    using EVNETest.Core.Entities.Base;

    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? IconId { get; set; }
        public File Icon { get; set; }
        public bool IsAdmin { get; set; }
    }
}