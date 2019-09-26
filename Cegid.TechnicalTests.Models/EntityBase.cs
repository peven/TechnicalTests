using System;

namespace Cegid.TechnicalTests.Models
{
    public abstract class EntityBase<T>
        where T : IEquatable<T>
    {
        public T Id { get; set; }
        public DateTime Creation { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool IsEnabled { get; set; } = true;
    }

    public abstract class EntityBase : EntityBase<string>
    {
        public new string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
