using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using EntityFramework_6_DAL_Template.Models;

namespace EntityFramework_6_DAL_Template.DBConfigurations
{
    public sealed class Configuration : DbMigrationsConfiguration<EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }
        protected override void Seed(EFContext context)
        {
            #region Add Department
            var departments = new List<Department>
            {
                new Department
                {
                    Id = 1,
                    Name = "Accounting"
                },
                new Department
                {
                    Id = 2,
                    Name = "Human Resource"
                },
                new Department
                {
                    Id = 3,
                    Name = "IT"
                }
            };

            foreach (var department in departments)
                context.Departments.AddOrUpdate(d => d.Id, department);
            #endregion
            


            #region Add Employees
            var employees = new List<Employee>
            {
                new Employee()
                {
                    Id = 1,
                    Name = "Marry",
                    StartDate = new DateTime(1999, 1, 1),
                    Department = departments[0]
                },
                new Employee()
                {
                    Id = 2,
                    Name = "John",
                    StartDate = new DateTime(2006, 7, 1),
                    Department = departments[1]
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Barry",
                    StartDate = new DateTime(2009, 3, 1),
                    Department = departments[1]
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Kate",
                    StartDate = new DateTime(2009, 3, 1),
                    Department = departments[2]
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Tom",
                    StartDate = new DateTime(2005, 8, 1),
                    Department = departments[2]
                },
                new Employee()
                {
                    Id = 6,
                    Name = "Gary",
                    StartDate = new DateTime(2015, 12, 1),
                    Department = departments[2]
                }

            };

            foreach (var employee in employees)
                context.Employees.AddOrUpdate(e => e.Id, employee);
            #endregion

        }
    }
}
