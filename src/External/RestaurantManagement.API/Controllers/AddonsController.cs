﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OutputCaching;
using RestaurantManagement.Application.Exceptions;
using RestaurantManagement.Application.Features.Addons.Queries.GetAddonsListQuery;
using Serilog;

namespace RestaurantManagement.API.Controllers
{
    [Route("api/odata")]
    public class AddonsController : ODataController
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public AddonsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region GET
        [HttpGet("addons")]
        [OutputCache(PolicyName = "Addons")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        public async Task<IActionResult> GetAllAddons()
        {
            try
            {
                Log.Information("Starting controller Addons action GetAllAddons.");
                var addons = await _mediator.Send(new GetAddonsListQuery());
                Log.Information("Returning all Addons to the caller.");
                return Ok(addons);
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
