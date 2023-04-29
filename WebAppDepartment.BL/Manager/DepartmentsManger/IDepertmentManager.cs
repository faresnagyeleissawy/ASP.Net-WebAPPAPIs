using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppDepartment.BL;

namespace WebAppDepartment.BL
{
    public interface  IDepertmentManager
    {
        List<DepartmentReadDto> GetAll();
        DepartmentReadDto? GetById(int id);
        int Add(DepartmentAddDto doctorDto);
        bool Update(DeprtmentUpdateDto doctorDto);
        bool Delete(int id);
   
      DepertmentWithEmployeeReadDto? GetWithEmployees(int id);
    }
}
