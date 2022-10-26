using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.User
{
    public partial class UpdateUser
    {
        public UserDto User { get; set; }
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
            User = await UserService.GetById(Id);
            Roles = (await RoleHttpService.GetRole()).ToList();
        }

        protected async Task HandleValidSubmit()
        {
            await UserService.Update(User);
            NavigationManager.NavigateTo("UserList");
        }

        protected async Task Delete_Click(Guid Id)
        {
            await UserService.Delete(Id);
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("UserList");
        }
    }
}

