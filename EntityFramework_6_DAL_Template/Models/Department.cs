using System.Collections.Generic;


namespace EntityFramework_6_DAL_Template.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id                                  { get; set; }
        public string Name                             { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
