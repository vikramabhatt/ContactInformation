using System;

namespace ContactInformation.Business.Model
{
    public sealed class ContactModel
    {
        public int Id { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public short Status { get; internal set; }
        public int LastActionBy { get; set; }
        public DateTime LastActionOn { get; internal set; }
    }
}
