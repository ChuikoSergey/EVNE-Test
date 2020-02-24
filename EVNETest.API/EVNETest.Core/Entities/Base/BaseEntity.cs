namespace EVNETest.Core.Entities.Base
{
    using System;

    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}