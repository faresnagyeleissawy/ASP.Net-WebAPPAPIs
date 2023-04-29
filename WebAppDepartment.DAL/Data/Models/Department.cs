
namespace WebAppDepartment.DAL
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Evaluation { get; set; }
        public double Budget { get; set; }

        public ICollection<Employee> Employees{ get; set; } = new HashSet<Employee>();
    }
}
