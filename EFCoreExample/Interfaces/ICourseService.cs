using EFCoreExample.Entities;

namespace EFCoreExample.Interfaces
{
    public interface ICourseService
    {
        Task AddCourse(Course course);
        Task<List<Course>> GetAllCourse();
        Task<Course> GetCourseById(Guid id);
    }
}
