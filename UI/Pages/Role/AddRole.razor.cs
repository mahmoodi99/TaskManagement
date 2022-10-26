using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Role
{
    public partial class AddRole
    {
        public RoleDto Role { get; set; } = new RoleDto();

        [Inject]
        public IRoleHttpService RoleService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected async Task Save()
        {
            await RoleService.Insert(Role);
            NavigationManager.NavigateTo("RoleList");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("RoleList");
        }
    }
}
