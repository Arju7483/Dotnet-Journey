using ControllerSection5.Models;
namespace ControllerSection5.Services
{
    public class TeacherDataService
    {
        List<Teacher> TeacherList = new List<Teacher>()
        {
            new Teacher(){Id = Guid.NewGuid(), Name = "Alice", Dept = "CSE", Salary = 100200},
            new Teacher(){Id = Guid.NewGuid(), Name = "Bob", Dept = "SWE", Salary = 100000},
        };
        public List<Teacher> getAll()
        {
            return TeacherList;
        }
        public Teacher getById(Guid id)
        {
            Teacher teacher = TeacherList.FirstOrDefault(t => t.Id == id);
            return teacher;
        }
    }
}
