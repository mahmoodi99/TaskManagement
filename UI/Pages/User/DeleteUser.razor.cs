using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.User
{
    public partial class DeleteUser
    {
        public UserDto User { get; set; }

        [Inject]
        public IUserHttpService UserService { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            User = await UserService.GetById(Id);
        }
        protected async Task Delete(Guid? Id)
        {
            await UserService.Delete(Id.Value);
            NavigationManager.NavigateTo("UserList");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("UserList");
        }
    }
}
