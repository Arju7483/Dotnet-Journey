using ControllerSection5.Models;
using ControllerSection5.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSection5.Controllers
{
    [Controller]
    [Route("/")]
    public class TeacherController: Controller
    {
        private readonly TeacherDataService teacherDataService;
        public TeacherController(TeacherDataService teacherDataService)
        {
            this.teacherDataService = teacherDataService;
        }

        [Route("all")]
        public List<Teacher> GetAllTeacher()
        {
            
            return teacherDataService.getAll();
            
        }
        //returning json result
        [Route("{id}")]
        public JsonResult GetById(Guid id)
        {
            var temp =  teacherDataService.getById(id);
            return Json(temp);
        }
    }
}
