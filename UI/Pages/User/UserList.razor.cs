using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.User
{
    public partial class UserList
    {
        [CascadingParameter]
        public List<UserDto> User { get; set; } = new List<UserDto>();

        [Inject]
        public IUserHttpService UserService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            User = await UserService.GetUser();
        }
    }
}
