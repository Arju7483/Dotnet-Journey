using EFCoreExample.Entities;

namespace EFCoreExample.Interfaces
{
    public interface IInstructorRepository
    {
        Task AddInstructor(Instructor instructor);
        Task<List<Instructor>> GetAllInstructor();
        Task<Instructor> GetInstructorById(Guid id);
    }
}


