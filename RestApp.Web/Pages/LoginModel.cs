using Microsoft.AspNetCore.Components;
using RestApp.Web.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace RestApp.Web.Pages
{
    public class LoginModel : ComponentBase
    {
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected async Task LoginAsync(string Password, string Email)
        {
            var token = new SecurityToken
            {
                AccessToken = Password,
                Email = Email,
                ExpiredAt = DateTime.UtcNow.AddDays(1)
            };
            await LocalStorageService.SetAsync(nameof(SecurityToken), token);

            NavigationManager.NavigateTo("/", true);
        }
    }

    public class SecurityToken
    {
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}