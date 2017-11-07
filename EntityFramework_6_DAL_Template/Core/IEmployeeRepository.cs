using System.Collections.Generic;
using EntityFramework_6_DAL_Template.Models;

namespace EntityFramework_6_DAL_Template.Core
{
    /// <summary>
    ///  Employee Repository Specified methods 
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
        IEnumerable<Employee> GetMostRecentHires();
    }
}
