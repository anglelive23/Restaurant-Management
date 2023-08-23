using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Addons.Commands.DeleteAddon
{
    public class DeleteAddonCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
