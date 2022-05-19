namespace SimpleRepo.Models
{
    public class EmployeeCV
    {
        public int EmployeeCvId { get; set; }
        public string Nationality { get; set; }
        public string Skills { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
