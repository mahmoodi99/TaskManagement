using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.User
{
    public partial class AddUser
    {
        public UserDto User { get; set; } = new UserDto();          
        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();       
        public string RoleId { get; set; }


        [Inject]
        public IUserHttpService UserService { get; set; }

        [Inject]
        public IRoleHttpService RoleHttpService { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {

            Roles = (await RoleHttpService.GetRole()).ToList();
        }


        protected async Task Save()
        {
            await UserService.Insert(User);
            NavigationManager.NavigateTo("UserList");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("UserList");
        }
    }
}
