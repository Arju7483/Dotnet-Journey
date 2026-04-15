using EFCoreExample.Entities;

namespace EFCoreExample.Interfaces
{
    public interface ICourseRepository
    {
        Task AddCourse(Course course);
        Task<List<Course>> GetAllCourse();
        Task<Course> GetCourseById(Guid id);
    }
}

