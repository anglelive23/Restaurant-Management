using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Abstractions
{
    public interface IAddonsRepository : IAsyncRepository<Addons>
    {
        #region POST
        Task<Addons?> AddAddonsAsync(Addons addons);
        #endregion

        #region PUT
        Task<Addons?> UpdateAddonsAsync(int id, Addons addons);
        #endregion
    }
}
