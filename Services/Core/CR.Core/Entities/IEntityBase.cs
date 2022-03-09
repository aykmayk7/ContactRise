using System;

namespace CR.Core.Entities
{
    public interface IEntityBase
    {
        DateTime? CreatedDate { get; }
        int? CreatedBy { get; }
        DateTime? UpdatedDate { get; }
        int? UpdatedBy { get; }
        public bool IsDelete { get; set; }
    }
}
