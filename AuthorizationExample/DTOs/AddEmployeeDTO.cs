namespace AuthorizationExample.DTOs
{
    public class AddEmployeeDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
