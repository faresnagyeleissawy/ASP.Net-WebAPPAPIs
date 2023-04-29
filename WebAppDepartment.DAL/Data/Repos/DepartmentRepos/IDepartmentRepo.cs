using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppDepartment.DAL.Data.Repos.Generic;

namespace WebAppDepartment.DAL.Data.Repos
{
    public interface IDepartmentRepo : IRepo<Department>
    {
        public Department? GeTByIDWithEmployees(int id);
    }

    
}
