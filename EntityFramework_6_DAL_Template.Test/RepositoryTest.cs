using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework_6_DAL_Template.Models;
using EntityFramework_6_DAL_Template.Specifications;
using EntityFramework_6_DAL_Template.TestingClasses;
using FluentAssertions;
using Xunit;

namespace EntityFramework_6_DAL_Template.Test
{
    
    public class RepositoryTest
    {
        private Dictionary<Type, object> _testDbSets;
        private List<Department>         _departments;
        private List<Employee>           _employees;

        public RepositoryTest()
        {
            this._testDbSets = new Dictionary<Type, object>
            {
                [typeof(Employee)]   = new TestDbSet<Employee>(),
                [typeof(Department)] = new TestDbSet<Department>()
            };

            this._departments = new List<Department>
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
                }
            };
            this._employees = new List<Employee>
            {
                new Employee()
                {
                    Id = 1,
                    Name = "Marry",
                    StartDate = new DateTime(1999, 1, 1),
                    Department = this._departments[0]
                },
                new Employee()
                {
                    Id = 2,
                    Name = "John",
                    StartDate = new DateTime(2006, 7, 1),
                    Department = this._departments[1]
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Barry",
                    StartDate = new DateTime(2009, 3, 1),
                    Department = this._departments[1]
                },
            };
        }

    


        [Fact]
        public void DepartmentTest()
        {
            var testDbContext        = new TestDbContext(this._testDbSets);
            var departmentRepository = new DepartmentRepository( testDbContext);

            departmentRepository.Add(this._departments[0]);

            var result               = departmentRepository.Find( d => d.Id == 1 );
            var expectedResult       = this._departments[0];

            result.Should().ShouldBeEquivalentTo( expectedResult );

        }

        [Fact]
        public void EmplyeeTest()
        {
            var testDbContext = new TestDbContext(this._testDbSets);

            var employeesRepository = new EmployeeRepository(testDbContext);
            employeesRepository.AddRange(this._employees);

            employeesRepository.Delete(this._employees[0]);
            
            var expectedResult = employeesRepository.GetAll().Count();

            expectedResult.Should().Be(2);
        }
    }
}
