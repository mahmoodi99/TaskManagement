using Microsoft.AspNetCore.Components.Authorization;
using Share.Dto;
using System.Security.Claims;

namespace UI.ServiceHttp
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return new AuthenticationState(claimsPrincipal);
        }

        public void SetAuthInfo(UserDto userProfile)
        {
            var identity = new ClaimsIdentity(new[]{
        new Claim(ClaimTypes.MobilePhone, userProfile.Mobile),
        new Claim(ClaimTypes.Name, $"{userProfile.FirstName} {userProfile.LastName}"),
        new Claim("UserId", userProfile.ToString())
    }, "AuthCookie");

            claimsPrincipal = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void ClearAuthInfo()
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
