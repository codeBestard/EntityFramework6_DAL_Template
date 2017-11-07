using System;
using System.Linq;
using EntityFramework_6_DAL_Template.Core;
using EntityFramework_6_DAL_Template.DBConfigurations;
using EntityFramework_6_DAL_Template.Models;
using EntityFramework_6_DAL_Template.Specifications;
using FluentAssertions;
using Xunit;

namespace EntityFramework_6_DAL_Template.IntegrationTests
{
    public class UnitOfWorkTest
    {
        [Fact]
        public void AddDepartmentTest( )
        {
            var guid = Guid.NewGuid();

            using (var unitOfWork = new UnitOfWork( new EFDbContext() ) )
            {
                var departmentRepository = unitOfWork.GetRepository<DepartmentRepository, Department, int>();
                departmentRepository.Add( new Department() { Name = "testDepartment"+ guid } );
                unitOfWork.Commit();
            }

            using( var unitOfWork = new UnitOfWork( new EFDbContext() ) )
            {
                var departmentRepository = unitOfWork.GetRepository<DepartmentRepository , Department , int>();
                var result               = departmentRepository.GetAll();
                result.Any( d => d.Name == "testDepartment"+ guid ).Should().BeTrue();
            }
        }


        [Fact( Skip = "demo only" )]
        //[Fact]
        public void GetDepartmentWithMostEmployeeTest( )
        {
            var guid = Guid.NewGuid();

            using( var unitOfWork = new UnitOfWork( new EFDbContext() ) )
            {
                var departmentRepository        = unitOfWork.GetRepository<DepartmentRepository , Department , int>();
                var departmentWithMostEmployees = departmentRepository.GetDepartmentsWithMostEmployees();
                var result                      = departmentWithMostEmployees.Count();
                result.Should().BeGreaterThan( 0 );
            }
 
        }

        [Fact( Skip = "demo only" )]
        //[Fact]
        public void GetDepartmentsWithEmployeesTest()
        {
            var guid = Guid.NewGuid();

            using( var unitOfWork = new UnitOfWork( new EFDbContext() ) )
            {
                var departmentRepository    = unitOfWork.GetRepository<DepartmentRepository , Department , int>();
                var departmentWithEmployees = departmentRepository.GetDepartmentsWithAllEmployees();
                var result                  = departmentWithEmployees.First().Employees.Count();
                result.Should().BeGreaterThan( 0 );
            }
        }

        [Fact]
        public void AddEmployeeTest( )
        {
            var guid       = Guid.NewGuid();
            var department = new Department { Name = "testDepartment" + guid };
            var employee   = new Employee
            {
                Department = department,
                Name       = "testEmployee" + guid,
                StartDate  = DateTime.Now
            };

            using( var unitOfWork = new UnitOfWork( new EFDbContext() ) )
            {
                var employeeRepository = unitOfWork.GetRepository<EmployeeRepository , Employee , int>();
                employeeRepository.Add( employee );
                unitOfWork.Commit();
            }

            using( var unitOfWork = new UnitOfWork( new EFDbContext() ) )
            {
                var departmentRepository = unitOfWork.GetRepository<DepartmentRepository , Department , int>();
                var departmentResult     = departmentRepository.GetAll();
                departmentResult.Any( d  => d.Name == "testDepartment" + guid ).Should().BeTrue();

                var employeeRepository   = unitOfWork.GetRepository<EmployeeRepository , Employee , int>();
                var employeeResult       = employeeRepository.GetAll();
                employeeResult.Any( e => e.Name == "testEmployee" + guid ).Should().BeTrue();
            }
        }
    }
}
