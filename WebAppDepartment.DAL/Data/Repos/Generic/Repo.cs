

using System.Numerics;
using System.Xml.Linq;
using WebAppDepartment.DAL.Data.Context;

namespace WebAppDepartment.DAL.Data.Repos.Generic
{
    public class Repo<IEntity> : IRepo<IEntity> where IEntity : class
    {
        private readonly DepartmentContext _context;

        public Repo(DepartmentContext context) {
            _context = context;
        }
       public int Add (IEntity entity)
        {
            _context.Add(entity);
           int id =_context.SaveChanges();
            return (id);
        }

        public void Delete(IEntity entity)
        {
            _context.Set<IEntity>().Remove(entity);


        }

        public IEnumerable<IEntity> GetAll()
        {
            return _context.Set<IEntity>();
        }

        public IEntity? GetById(int id)
        {
           return _context.Set<IEntity>().Find(id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(IEntity entity)
        {
         _context.Set<IEntity>().Update(entity);
      
        }
    }
    
}
