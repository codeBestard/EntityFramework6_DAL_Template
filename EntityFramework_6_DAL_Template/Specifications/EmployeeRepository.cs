using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework_6_DAL_Template.Core;
using EntityFramework_6_DAL_Template.Models;

namespace EntityFramework_6_DAL_Template.Specifications
{
    public sealed class EmployeeRepository : RepositoryBase<Employee , int>, IEmployeeRepository
    {
        private readonly DbSet<Employee> _employees;
        public EmployeeRepository( IDbContext dbContext )
            : base( dbContext )
        {
            this._employees = this.DbContext.Set<Employee>();
        }


        /* Override Generic Repository methods 
         =============================================================*/
        public override Employee SingleOrDefault( Expression<Func<Employee , bool>> predicate )
        {
            if( ReferenceEquals( predicate , null ) ) throw new ArgumentNullException( nameof( predicate ) );
            var result = base.SingleOrDefault( predicate );
            return ReferenceEquals( result , null ) ? EmptyModels.EmptyEmployee : result;
        }


        public override Employee Get( int key )
        {
            if( key < 1 )
            {
                return EmptyModels.EmptyEmployee;
            }

            var result = _employees.Find( key );
            return ReferenceEquals( result , null ) ? EmptyModels.EmptyEmployee : result;
        }


        /* Employee Repository Specified methods 
           =============================================================*/
        public IEnumerable<Employee> GetMostRecentHires( )
        {
            var groups = this._employees.GroupBy(e => e.StartDate)
                                        .OrderByDescending(g => g.Key).ToArray();

            var result = groups.Any() ? groups.First() : Enumerable.Empty<Employee>();
            return result;
        }

    }
}
