namespace AL_EmpFeedbackSystem.Entity.User
{
    public class User 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? LeadId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public int RoleId { get; set; }
        public int DesignationId { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime? ServiceEndDate { get; set; }
        public bool ActiveStatus { get; set; }
    }
}