using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAppDepartment.DAL.Data.Context;
using WebAppDepartment.DAL.Data.Repos.Generic;

namespace WebAppDepartment.DAL.Data.Repos.DepartmentRepos
{
    public class DepartmentRepo : Repo<Department> , IDepartmentRepo 
    {

        private readonly DepartmentContext _context;
        public DepartmentRepo(DepartmentContext context) : base(context)
        {
            _context = context;
        }
         public Department? GeTByIDWithEmployees(int id)
        {
            return _context.Set<Department>().Include(d => d.Employees)
                .FirstOrDefault(d => d.Id == id);
        }
       
    }
}
