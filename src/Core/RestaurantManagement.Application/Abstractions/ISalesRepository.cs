using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Abstractions
{
    public interface ISalesRepository : IAsyncRepository<SalesHeader>
    {
        #region POST
        Task<SalesHeader?> AddSalesHeaderAsync(SalesHeader salesHeader);
        #endregion

        #region PUT
        Task<SalesHeader?> UpdateSalesHeaderAsync(int id, SalesHeader salesHeader);
        #endregion
    }
}
