using System;

namespace ContactInformation.Entity
{
    public abstract class PrimaryDetail
    {
        public int Id { get; set; }
        public short Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
