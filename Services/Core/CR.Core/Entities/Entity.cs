using System;

namespace CR.Core.Entities
{
    public abstract class Entity : IEntityBase
    {
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsDelete { get; set; }

        public Entity Clone()
        {
            return (Entity)this.MemberwiseClone();
        }
    }
}
