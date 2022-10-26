using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Role
{
    public partial class UpdateRole
    {
        public RoleDto Role { get; set; }


        [Inject]
        public IRoleHttpService RoleService { get; set; }



        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
      

        protected async override Task OnInitializedAsync()
        {
            Role = await RoleService.GetById(Id);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }

        protected async Task HandleValidSubmit()
        {
            await RoleService.Update(Role);
            NavigationManager.NavigateTo("RoleList");
        }

        protected async Task Delete_Click(Guid Id)
        {
            await RoleService.Delete(Id);
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("RoleList");
        }
    }
}
