using Microsoft.AspNetCore.Mvc;
using WebAppDepartment.BL;

namespace WebAppDepartment.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        public readonly IDepertmentManager _depertmentManager;
        public DepartmentController(IDepertmentManager depertmentManager)
        {
            _depertmentManager = depertmentManager;
        }
        [HttpGet]
        public ActionResult<List<DepartmentReadDto>> GetAll()
        {
            return _depertmentManager.GetAll();
        }
        [HttpPut]

        public ActionResult Update(DeprtmentUpdateDto dto)
        {
            bool isFound = _depertmentManager.Update(dto);
            if (!isFound) { return NotFound(); }
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            bool isFound = _depertmentManager.Delete(id);
            if (!isFound)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpGet]
        [Route("WithEmployee/{id}")]
        public ActionResult<DepertmentWithEmployeeReadDto> GetWithEmployees(int id)
        {
            DepertmentWithEmployeeReadDto?depertment = _depertmentManager.GetWithEmployees(id);
            if (depertment is null)
                return NotFound();
            return depertment;
        }

    }
}