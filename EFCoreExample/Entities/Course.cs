namespace EFCoreExample.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
