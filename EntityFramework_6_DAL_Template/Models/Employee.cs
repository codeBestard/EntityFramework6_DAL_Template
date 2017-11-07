using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_6_DAL_Template.Models
{
    public class Employee
    {
        public int Id                        { get; set; }
        public String Name                   { get; set; }

        public DateTime StartDate            { get; set; }

        public int DepartmentId              { get; set; }
        public virtual Department Department { get; set; }
    }
}
