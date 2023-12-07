using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RestApp.Services.Contract;
using RestApp.Web;
using RestApp.Web.Infrastructure;
using RestApp.Web.Pages;
using RestApp.Web.Requests;
using System.Security.AccessControl;
using System.Security.Claims;
using MudBlazor.Services;
namespace BlazorAuthentification1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            
            
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7209")
            }
            );

            builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
            builder.Services.AddScoped<IUserService, ApiUserService>();


            builder.Services.AddMudServices();

            await builder.Build().RunAsync();

        }
    }

    internal class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public TokenAuthenticationStateProvider(ILocalStorageService localStorageService) {
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        { 
            AuthenticationState CreateAnonymous()
            {
                var anonymousIdentity = new ClaimsIdentity();
                var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
                return new AuthenticationState(anonymousPrincipal);
            }

            var token = await _localStorageService.GetAsync<SecurityToken>(nameof(SecurityToken));

            if (token == null)
            {
                return CreateAnonymous();
            }

            if (string.IsNullOrEmpty(token.AccessToken) || token.ExpiredAt < DateTime.UtcNow) 
            {
                return CreateAnonymous();
            }

            // Create real user 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Country,"Belarus"),
                new Claim(ClaimTypes.Name, token.Email),
                new Claim(ClaimTypes.Expired, token.ExpiredAt.ToLongDateString()),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.Role, "Manager"),
                new Claim("Blazor1", "Eshkere")
            };
            
            var identity = new ClaimsIdentity(claims, "Token");
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);

        }

        public void MakeUserAnonymous()
        {
            _localStorageService.RemoveAsync(nameof(SecurityToken));

            var anonymousIdentity = new ClaimsIdentity();
            var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
            var authState = Task.FromResult(new AuthenticationState(anonymousPrincipal));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}