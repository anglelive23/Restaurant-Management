using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Abstractions
{
    public interface IAddonsRepository : IAsyncRepository<Addon>
    {
        #region POST
        Task<Addon?> AddAddonsAsync(Addon addons);
        #endregion

        #region PUT
        Task<Addon?> UpdateAddonsAsync(int id, Addon addons);
        #endregion

        #region DELETE
        Task<bool> RemoveAddonAsync(int id);
        #endregion

        #region Helpers
        bool IsExistingAddon(string name);
        #endregion
    }
}
