using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Role
{
    public partial class RoleList
    {
        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();

        [Inject]
        public IRoleHttpService RoleService { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Roles = await RoleService.GetRole();
        }
    }
}
