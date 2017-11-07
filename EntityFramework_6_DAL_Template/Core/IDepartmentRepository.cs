using System.Collections.Generic;
using EntityFramework_6_DAL_Template.Models;

namespace EntityFramework_6_DAL_Template.Core
{
    /// <summary>
    ///  Department Repository Specified methods 
    /// </summary>
    public interface IDepartmentRepository : IRepository<Department, int>
    {
        IEnumerable<Department> GetDepartmentsWithMostEmployees();
        IEnumerable<Department> GetDepartmentsWithAllEmployees();
    }
}
