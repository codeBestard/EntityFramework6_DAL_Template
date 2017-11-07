using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EntityFramework_6_DAL_Template.Core;
using EntityFramework_6_DAL_Template.Models;

namespace EntityFramework_6_DAL_Template.DBConfigurations
{
    public class EFDbContext : DbContext, IDbContext
    {
        public EFDbContext( )
            : base("name=EFContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees     { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}