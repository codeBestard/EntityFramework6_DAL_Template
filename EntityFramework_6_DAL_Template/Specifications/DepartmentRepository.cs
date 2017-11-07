using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework_6_DAL_Template.Core;
using EntityFramework_6_DAL_Template.Models;

namespace EntityFramework_6_DAL_Template.Specifications
{
    public sealed class DepartmentRepository : RepositoryBase<Department , int>, IDepartmentRepository
    {
        private readonly DbSet<Department> _departments;
        public DepartmentRepository( IDbContext dbContext ) 
            : base( dbContext )
        {
            if( ReferenceEquals( dbContext , null ) ) throw new ArgumentNullException( nameof( dbContext ) );
            this._departments = this.DbContext.Set<Department>();
        }


        /* Override Generic Repository methods 
         =============================================================*/
        public override Department SingleOrDefault( Expression<Func<Department , bool>> predicate )
        {
            if( ReferenceEquals( predicate , null ) ) throw new ArgumentNullException( nameof( predicate ) );
            var result = base.SingleOrDefault( predicate );
            return ReferenceEquals( result , null ) ? EmptyModels.EmptyDepartment : result;
        }

        public override Department Get( int key )
        {
            if( key < 1 )
            {
                return EmptyModels.EmptyDepartment;
            }

            var result = _departments.Find( key );
            return ReferenceEquals( result , null ) ? EmptyModels.EmptyDepartment : result;
        }


        /* Department Repository Specified methods 
           =============================================================*/
        public IEnumerable<Department> GetDepartmentsWithAllEmployees( )
        {
            return this._departments.Include("Employees").ToList();
        }

        public IEnumerable<Department> GetDepartmentsWithMostEmployees( )
        {
            var group = this._departments.GroupBy(d => d.Employees.Count)
                                         .OrderByDescending(g => g.Key).ToArray();

            var result = group.Any() ? group.First() : Enumerable.Empty<Department>();
            return result;
        }


    }
}
