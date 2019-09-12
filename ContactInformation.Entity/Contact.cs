namespace ContactInformation.Entity
{
    public sealed class Contact : PrimaryDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }        
    }
}
