namespace SimpleRepo.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeCV EmployeeCV { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
