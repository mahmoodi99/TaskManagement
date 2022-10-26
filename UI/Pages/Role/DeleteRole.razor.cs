using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Role
{
    public partial class DeleteRole
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
        protected async Task Delete(Guid Id)
        {
            await RoleService.Delete(Id);
            NavigationManager.NavigateTo("RoleList");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("RoleList");
        }
    }
}
