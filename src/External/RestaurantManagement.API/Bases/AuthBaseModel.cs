namespace RestaurantManagement.API.Bases
{
    public class AuthBaseModel : ControllerBase
    {
        #region Cookie
        [ApiExplorerSettings(IgnoreApi = true)]
        protected void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Expires = expires.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None,
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
        #endregion

        #region Maybe --> Add refreshToken in Response Header
        [ApiExplorerSettings(IgnoreApi = true)]
        protected void SetRefreshTokenInResponseHeaders(string refreshToken)
        {
            Response.Headers.Append("refreshToken", refreshToken);
        }
        #endregion
    }
}
