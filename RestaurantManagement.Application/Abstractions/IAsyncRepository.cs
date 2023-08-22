using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Abstractions
{
    public interface IAsyncRepository<T> where T : class
    {
        #region GET
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(int id);
        #endregion

        #region DELETE
        Task<bool> RemoveAsync(int id);
        #endregion
    }
}
