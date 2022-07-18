using Microsoft.AspNetCore.Mvc;
using MW_Students_ASP_NET_CORE_WEB_API___WEB.Interfaces;
using MW_Students_ASP_NET_CORE_WEB_API___WEB.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MW_Students_ASP_NET_CORE_WEB_API___WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _students;
        public StudentsController(IStudentsService students)
        {
            this._students = students;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._students.GetAllStudents());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await this._students.GetStudent(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student value)
        {
            return Ok(await this._students.AddStudent(value));
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Student student)
        {
            return Ok(await this._students.EditStudent(student));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await this._students.DeleteStudent(id));
        }
    }
}
