using CRUDOPERATIONAPIYOUTUBE1.Interface;
using CRUDOPERATIONAPIYOUTUBE1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOPERATIONAPIYOUTUBE1.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class StudentController : ControllerBase
    {
        //Instance variable-->
        private readonly IStudentRepository _IStudentRepository;
      
        //Cunstructor 
        public StudentController(IStudentRepository IStudent)
        {
            _IStudentRepository = IStudent;
        }

        //Action Method To Create Student--->

        [Route("CreateStudent"), HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudent request)
        {
            var result = await _IStudentRepository.CreateStudent(request);
            return Ok(result);
        }

        //Action Method To delete Student--->

        [Route("DeleteStudent/{ID}"), HttpPost]
        public async Task<IActionResult> DeleteStudent(int? ID)
        {
            var result = await _IStudentRepository.DeleteStudent(ID);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        //Select Single Student by id
        [Route("GetStudent/{ID}"), HttpPost]
        public async Task<IActionResult> GetStudent(int? ID)
        {
            var result = await _IStudentRepository.GetStudent(ID);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [Route("SelectStudents"), HttpPost]
        public async Task<IActionResult> SelectStudents()
        {
            var response = await _IStudentRepository.SelectStudents();
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [Route("UpdateStudent"), HttpPost]
        public async Task<IActionResult> UpdateStudents(CreateStudent request)
        {
            var response = await _IStudentRepository.UpdateStudent(request);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

    } 
}
