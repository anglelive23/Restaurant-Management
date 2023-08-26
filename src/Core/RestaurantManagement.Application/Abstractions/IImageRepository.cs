using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Abstractions
{
    public interface IImageRepository : IAsyncRepository<Image>
    {
        #region POST
        Task<Image> AddImageAsync(Image image);
        #endregion

        #region PUT
        Task<Image?> UpdateImageAsync(int id, Image image);
        #endregion

        #region DELETE
        Task<bool> RemoveImageAsync(int id);
        #endregion
    }
}
