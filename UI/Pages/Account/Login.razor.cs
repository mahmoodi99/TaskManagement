using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Account
{
    public partial class Login
    {
        private LoginUserDto model = new LoginUserDto();
        public LoginUserDto loginuser { get; set; }

        [Inject]
        public ILoginUserService LoginUserService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private bool loading;
        private string error;

        protected override void OnInitialized()
        {           
            if (LoginUserService.User != null)
            {
                NavigationManager.NavigateTo("");
            }
        }

        private async void HandleValidSubmit()
        {
            loading = true;
            try
            {
                await LoginUserService.login(model);
                await LocalStorageService.SetItem("isauthenticated", "true");
                //NavigationManager.NavigateTo("");
                NavigationManager.NavigateTo("/", true);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                loading = false;
                StateHasChanged();
            }

        }
    }
}







