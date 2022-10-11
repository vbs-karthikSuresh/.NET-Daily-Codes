using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository prep;

        public StudentController(IStudentRepository prep)
        {
            this.prep = prep;
        }
        [HttpGet]

        public async Task<IActionResult> GetStudents()
        {
            try
            {
                return Ok(await prep.GetStudents());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error in the server while executing code");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var res = await prep.GetStudent(id);
            if (res == null)
            {
                return NotFound($"product with id:{id} is not found in the database ");
            }
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student p)
        {
            if (p.ID != 0)
            {
                return BadRequest($"can't insert data to identity column given id={p.ID}");
            }
            var obj = await prep.AddStudent(p);
            return CreatedAtAction("GetProduct", new { id = obj.ID }, obj);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditStudent(int id, Student p)
        {
            if (id != p.ID)
            {
                return BadRequest("can't update a identtity column id as gave different Id");
            }
            var obj = await prep.GetStudent(id);
            if (obj == null)
            {
                return NotFound($"row with id={id} not found in the database");
            }
            return Ok(await prep.UpdateStudent(id, p));
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var obj = await prep.GetStudent(id);
            if (obj == null)
            {
                return NotFound($"row with id={id} not found in the database");
            }
            return Ok(await prep.DeleteStudent(id));
        }
    }
}
