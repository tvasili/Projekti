using Microsoft.AspNetCore.Mvc;
using MyUniversity.Data.Services;
using MyUniversity.Data.ViewModels;

namespace MyUniversity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly UniversitiesService _universitiesService;

        public UniversitiesController(UniversitiesService universitiesService)
        {
            _universitiesService = universitiesService;
        }

        [HttpGet]
        public IActionResult GetAllUniversities()
        {
            var allUniversities = _universitiesService.GetAllUniversities();
            return Ok(allUniversities);
        }

        [HttpGet("{id}")]
        public IActionResult GetUniversityById(int id)
        {
            var university = _universitiesService.GetUniversityByid(id);
            if (university == null)
            {
                return NotFound($"University with id = {id} not found");
            }
            return Ok(university);
        }

        [HttpPost]
        public IActionResult AddUniversity([FromBody] UniversityVM university)
        {
            _universitiesService.AddUniversity(university);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateUniversityById(int Id, [FromBody] UniversityVM uni1)
        {
            var updateduni = _universitiesService.UpdateUniversityById(Id, uni1);
            if (updateduni == null)
            {
                return NotFound($"University with id = {Id} not found");
            }
            return Ok(updateduni);
        }

        [HttpDelete("delete-university-by-id/{Id}")]
        public IActionResult DeleteUniversityById(int Id)
        {
            _universitiesService.DeleteUniversityById(Id);
            return Ok();
        }
    }
}
