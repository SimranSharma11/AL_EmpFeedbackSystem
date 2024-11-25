namespace AL_EmpFeedbackSystem.Entity.User
{
    public class GetUserDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? LeadName { get; set; }
        public string? ManagerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string Designation { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime? ServiceEndDate { get; set; }
        public bool ActiveStatus { get; set; }
        public string UserRole { get; set; }
    }
}
