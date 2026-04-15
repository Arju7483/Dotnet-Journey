using EFCoreExample.Entities;
using EFCoreExample.Interfaces;

namespace EFCoreExample.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly ILogger<InstructorService> _logger;
        public InstructorService(IInstructorRepository instructorRepository, ILogger<InstructorService> logger)
        {
            _instructorRepository = instructorRepository;
            _logger = logger;

        }

        public async Task AddInstructor(Instructor instructor)
        {
            await _instructorRepository.AddInstructor(instructor);
        }

        public async Task<List<Instructor>> GetAllInstructor()
        {
            return await _instructorRepository.GetAllInstructor();
        }

        public async Task<Instructor> GetInstructorById(Guid id)
        {
            var result = await _instructorRepository.GetInstructorById(id);
            if(result == null)
            {
                _logger.LogWarning($"Instructor not found with id {id}");
            }
            return result;
        }
    }
}

