
using Microsoft.EntityFrameworkCore;


namespace WebAppDepartment.DAL.Data.Context
{
    public class DepartmentContext : DbContext
    {
        public DbSet<Department> DepartmentSet { get; set; }
        public DbSet<Employee> EmployeeSet { get; set; }

        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seeding depts

            var departments = new List<Department>
                {
                  new Department {
                    Id= 1,
                    Name= "Prodction",
                    Budget= 27064,
                    Evaluation= 4,
                  },
                  new Department {
                    Id= 2,
                    Name= "R&D",
                    Budget= 2706400,
                    Evaluation= 5,
                  },
                  new Department {Id = 3, Name = "Prodction", Budget = 270600, Evaluation = 3},
                };

            #endregion
            #region Employee
            var employees = new List<Employee> {
            new Employee {Id=1,Name="ali",DepartmentId=1},
            new Employee {Id=2,Name="mo",DepartmentId=1},
            new Employee {Id=3,Name="fo",DepartmentId=2},
            new Employee {Id=4,Name="to",DepartmentId=2},
            new Employee {Id=5,Name="do",DepartmentId=3},
            new Employee {Id=6,Name="lo",DepartmentId=3},
            new Employee {Id=7,Name="po",DepartmentId=3},
            new Employee {Id=8,Name="al",DepartmentId=1},

            };


            #endregion

            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Employee>().HasData(employees);

        }


    }
}
