using System.Data.Entity.ModelConfiguration;
using EntityFramework_6_DAL_Template.Models;

namespace EntityFramework_6_DAL_Template.DBConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasRequired(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(false);
            
        }
    }
}
