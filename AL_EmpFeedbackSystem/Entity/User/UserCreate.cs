namespace AL_EmpFeedbackSystem.Entity.User
{
    public class UserCreate : BaseEntity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool ActiveStatus { get; set; }
        public string? LeadId { get; set; }
        public string? ManagerId { get; set; }
        public DateTime DataOfBirth { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string RoleId { get; set; }
    }
}
