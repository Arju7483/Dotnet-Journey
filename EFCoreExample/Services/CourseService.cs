using EFCoreExample.Entities;
using EFCoreExample.Interfaces;

namespace EFCoreExample.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task AddCourse(Course course)
        {
            await _courseRepository.AddCourse(course);
        }

        public async Task<List<Course>> GetAllCourse()
        {
            return await _courseRepository.GetAllCourse();
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _courseRepository.GetCourseById(id);
        }
    }
}
