using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Activity
{
    public partial class DeleteActivity
    {
        public ActivityGetDto Activity { get; set; }

        [Inject]
        public IActivityHttpService ActivityService { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Activity = await ActivityService.GetById(Id);
        }
        protected async Task Delete(Guid Id)
        {
            await ActivityService.Delete(Id);
            NavigationManager.NavigateTo("ActivityList");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("ActivityList");
        }
    }
}
