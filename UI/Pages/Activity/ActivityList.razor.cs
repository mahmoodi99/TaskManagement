using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Share.Dto;
using UI.ServiceHttp;


namespace UI.Pages.Activity
{
    public partial class ActivityList
    {
        public List<ActivityGetDto> Activity { get; set; } = new List<ActivityGetDto>();

        private ActivityGetDto activity = new ActivityGetDto();

        private FilterDto filter = new FilterDto();

        [Inject]
        public IActivityHttpService ActivityService { get; set; }

        [Inject]
        public IFilterHttpService FilterParametr { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Activity = await ActivityService.GetActivity();           
        }

        protected async  Task Delete_Click(Guid Id)
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", $"آیا از حذف وظیفه {activity.Title}  مطمعن هستید");

            if (confirmed)
            {
                await ActivityService.Delete(Id);
            }

            else
            {
                await JsRuntime.InvokeVoidAsync("showAlert", "Cancel");
            }
        }

        private async Task SearchChanged(string searchTerm)
       {
            if (string.IsNullOrEmpty(searchTerm) || string.IsNullOrWhiteSpace(searchTerm))
            {
                Activity = await ActivityService.GetActivity();
            }

            //Console.WriteLine(searchTerm);
            //filter.PageNumber = 1;
            //filter.SearchTerm = searchTerm;
            //    Activity = await ActivityService.GetActivity();
            else
               Activity = await FilterParametr.GetByfilter(searchTerm);
        }
    }
}
