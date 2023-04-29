using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppDepartment.DAL;
using WebAppDepartment.DAL.Data.Context;
using WebAppDepartment.DAL.Data.Repos;

namespace WebAppDepartment.BL
{
    public class DepartmentManager : IDepertmentManager
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentManager(IDepartmentRepo departmentRepo)
        {
            _departmentRepo= departmentRepo;
        }


        int IDepertmentManager.Add(DepartmentAddDto departmentDto)
        {
            Department departmentToDb = new Department
            {
                Name = departmentDto.Name,
                Budget = departmentDto.Budget,

            };
            _departmentRepo.Add(departmentToDb);
            _departmentRepo.SaveChanges();
            return(departmentToDb.Id);
        }

        bool IDepertmentManager.Delete(int id)
        {
            Department? departmentFromDB = _departmentRepo.GetById(id);
            if (departmentFromDB is null)
                return false;
             _departmentRepo.Delete(departmentFromDB);
            _departmentRepo.SaveChanges();
            return true;

        }

        List<DepartmentReadDto> IDepertmentManager.GetAll()
        {
            var departmentFromDb = _departmentRepo.GetAll();

            return departmentFromDb.Select(d => new DepartmentReadDto
            {
                Id = d.Id,
                Name = d.Name,
        
            }).ToList();
        }

        DepartmentReadDto? IDepertmentManager.GetById(int id)
        {
            Department? departmentFromDB =_departmentRepo.GetById(id);
            if (departmentFromDB is null)
                return null;
            return new DepartmentReadDto
            {
                Id = departmentFromDB.Id,
                Name = departmentFromDB.Name,
                Evaluation = departmentFromDB.Evaluation,   
                
            };
            
        }

        DepertmentWithEmployeeReadDto? IDepertmentManager.GetWithEmployees(int id)
        {
            Department? departmentFromDb = _departmentRepo.GeTByIDWithEmployees(id);
            if(departmentFromDb is null)
            {
                return null;
            }
            return new DepertmentWithEmployeeReadDto
            {
                Name = departmentFromDb.Name,
                Evaluation = departmentFromDb.Evaluation,
                Id = departmentFromDb.Id,
            
                Employees = departmentFromDb.Employees
                .Select(p => new EmployeeChildReadDto
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList()
            };
         
        }
        

       

        bool IDepertmentManager.Update(DeprtmentUpdateDto departmentDto)
        {
            Department? departmentFromDb = _departmentRepo.GetById(departmentDto.Id);
            if (departmentFromDb is null) { return false; }
            departmentFromDb.Name = departmentDto.Name;
            departmentFromDb.Budget = departmentDto.Budget;
            _departmentRepo.Update(departmentFromDb);
            _departmentRepo.SaveChanges();
            return true;
        }
    }
}
