using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LogUploader.Provider
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
            //try
            //{
            //    var savedToken = await _localStorage.GetItemAsync<string>("authToken");
            //    if (string.IsNullOrWhiteSpace(savedToken))
            //    {
            //        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            //    }
            //    var tokenContent = _tokenHandler.ReadJwtToken(savedToken);
            //    var expiry = tokenContent.ValidTo;
            //    if (expiry < DateTime.Now)
            //    {
            //        await _localStorage.RemoveItemAsync("authToken");
            //        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            //    }

            //    //Get Claims from token and Build auth user object
            //    var claims = ParseClaims(tokenContent);
            //    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            //    //return authenticted person
            //    return new AuthenticationState(user);
            //}
            //catch (Exception)
            //{
            //    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            //}
        }

        public async Task LoggedIn()
        {
            //var savedToken = await _localStorage.GetItemAsync<string>("authToken");
            //var tokenContent = _tokenHandler.ReadJwtToken(savedToken);
            //var claims = ParseClaims(tokenContent);
            //var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            //var authState = Task.FromResult(new AuthenticationState(user));
            //NotifyAuthenticationStateChanged(authState);
        }

        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
