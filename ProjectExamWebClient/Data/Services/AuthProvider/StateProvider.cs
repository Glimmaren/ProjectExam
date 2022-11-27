using System.Security.Claims;
using Blazored.SessionStorage;
using Costumer.Models;
using DotNetOpenAuth.InfoCard;
using Microsoft.AspNetCore.Components.Authorization;
using ProjectExamWebClient.FirebaseAuth;

namespace ProjectExamWebClient.Data.Services.AuthProvider
{
    public class StateProvider : AuthenticationStateProvider
    {

        private ISessionStorageService _sessionStorageService;

        public StateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorageService = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var email = await _sessionStorageService.GetItemAsync<string>("email");
            var identity = new ClaimsIdentity();
            if (email != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "Daniel"),
                    //new Claim(ClaimTypes.Role, person.Role.Name)
                }, "apiauth_type"); 
            }
  

            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public async void MarkUserAsAuthenticated(Person person)
        {
            var identity = new ClaimsIdentity();

            if (true)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, person.FirstName),
                    new Claim(ClaimTypes.Role, person.Role.Name),
                }, "apiauth_type");
            }
            
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLogedOut()
        {
            await _sessionStorageService.RemoveItemAsync("email");
            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
