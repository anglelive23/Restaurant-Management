namespace RestaurantManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AuthBaseModel
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public AuthController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region Authentication Endpoints
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                Log.Information("Starting controller Auth action Register.");

                var result = await _mediator.Send(new RegisterCommand
                {
                    Email = model.Email,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName
                });

                if (!result.IsAuthenticated)
                    return StatusCode(StatusCodes.Status400BadRequest, $"{result.Message}");

                #region RefreshToken
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
                #endregion

                Log.Information("returning register result to the caller.");
                return Ok(result);
            }
            catch (Exception ex) when (ex is ValidationException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                Log.Information("Statring controller Auth action Login.");

                var result = await _mediator.Send(new LoginCommand { Email = model.Email, Password = model.Password });

                if (!result.IsAuthenticated)
                    return StatusCode(StatusCodes.Status400BadRequest, $"{result.Message}");

                #region RefreshToken
                if (!string.IsNullOrEmpty(result.Token))
                    SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
                #endregion

                Log.Information("returning login result to the caller.");
                return Ok(result);
            }
            catch (Exception ex) when (ex is ValidationException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
