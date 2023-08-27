﻿namespace RestaurantManagement.API.Controllers
{
    [Route("api/odata")]
    public class ContactsController : ODataController
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public ContactsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region GET
        [HttpGet("contacts")]
        [OutputCache(PolicyName = "Contacts")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(200, Type = typeof(IQueryable<Contact>))]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                Log.Information("Starting controller Contacts action GetAllContacts.");
                var contacts = await _mediator
                    .Send(new GetContactsListQuery());
                Log.Information("Returning all Contacts to the caller.");
                return Ok(contacts);
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("contacts({key})")]
        [OutputCache(PolicyName = "Contact")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(200, Type = typeof(Contact))]
        public async Task<IActionResult> GetContactById(int key)
        {
            try
            {
                Log.Information("Starting controller Contacts action GetContactById.");
                var contact = await _mediator
                    .Send(new GetContactDetailsQuery
                    {
                        Id = key
                    });

                Log.Information("Returning Contacts data to the caller.");
                return Ok(SingleResult.Create(contact));
            }
            catch (FluentValidation.ValidationException vex)
            {
                StringBuilder message = new StringBuilder();
                foreach (var error in vex.Errors)
                {
                    message.AppendLine(error.ErrorMessage);
                }
                Log.Error($"{message}");
                return StatusCode(500, $"An error occurred: {message}");
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region POST
        [HttpPost("contacts")]
        [ProducesResponseType(201, Type = typeof(Contact))]
        public async Task<IActionResult> AddContact([FromBody] CreateContactDto contactDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Contacts action AddContact.");
                var contact = await _mediator
                    .Send(new CreateContactCommand
                    {
                        ContactDto = contactDto
                    });

                await cache.EvictByTagAsync("Contacts", cancellationToken);

                Log.Information("Contact has been added.");
                return Created(contact);
            }
            catch (FluentValidation.ValidationException vex)
            {
                StringBuilder message = new StringBuilder();
                foreach (var error in vex.Errors)
                {
                    message.AppendLine(error.ErrorMessage);
                }
                Log.Error($"{message}");
                return StatusCode(500, $"An error occurred: {message}");
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region PUT
        [HttpPut("contacts({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateContact(int key, [FromBody] UpdateContactDto updateContactDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Contacts action UpdateContact.");
                var currentContact = await _mediator
                    .Send(new UpdateContactCommand
                    {
                        Id = key,
                        ContactDto = updateContactDto
                    });

                if (currentContact is null)
                    return NotFound("Contact not found!");

                await cache.EvictByTagAsync("Contacts", cancellationToken);

                Log.Information($"Contact with id: {key} has been updated.");
                return NoContent();
            }
            catch (FluentValidation.ValidationException vex)
            {
                StringBuilder message = new StringBuilder();
                foreach (var error in vex.Errors)
                {
                    message.AppendLine(error.ErrorMessage);
                }
                Log.Error($"{message}");
                return StatusCode(500, $"An error occurred: {message}");
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("contacts({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveContact(int key, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Contacts action RemoveContact.");

                var currentContact = await _mediator
                    .Send(new DeleteContactCommand
                    {
                        Id = key
                    });

                if (currentContact is false)
                    return NotFound("Contact not found!");

                await cache.EvictByTagAsync("Contacts", cancellationToken);

                Log.Information($"Contact with id: {key} has been marked as deleted.");
                return NoContent();
            }
            catch (FluentValidation.ValidationException vex)
            {
                StringBuilder message = new StringBuilder();
                foreach (var error in vex.Errors)
                {
                    message.AppendLine(error.ErrorMessage);
                }
                Log.Error($"{message}");
                return StatusCode(500, $"An error occurred: {message}");
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
