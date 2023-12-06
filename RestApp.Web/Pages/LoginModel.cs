using Microsoft.AspNetCore.Components;
using RestApp.Web.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace RestApp.Web.Pages
{
    public class LoginModel : ComponentBase
    {
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        public LoginModel() 
        {
            LoginData = new LoginViewModel();
        }
        public LoginViewModel LoginData { get; set; }

        protected async Task LoginAsync()
        {
            var token = new SecurityToken
            {
                AccessToken = LoginData.Password,
                Email = LoginData.Email,
                ExpiredAt = DateTime.UtcNow.AddDays(1)
            };
            await LocalStorageService.SetAsync(nameof(SecurityToken), token);

            NavigationManager.NavigateTo("/", true);
        }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }

    public class SecurityToken
    {
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
