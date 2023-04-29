using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WebAppDepartment.DAL.Data.Repos.Generic
{
    public interface IRepo <TEnitiy>  where TEnitiy : class
    {
        IEnumerable<TEnitiy> GetAll();
        TEnitiy? GetById(int id);
        int Add(TEnitiy entity);
        void Update(TEnitiy entity);
        void Delete(TEnitiy entity);
        int SaveChanges();

    }
}
