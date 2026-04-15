namespace EFCoreExample.Entities
{
    public class Instructor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public virtual List<Course>? Courses { get; set; }

    }
}
