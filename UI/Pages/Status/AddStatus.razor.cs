using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Status
{
    public partial  class AddStatus
    {
        public StatusDto Status { get; set; } = new StatusDto();

        [Inject]
        public IStatusHttpService StatusService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected async Task Save()
        {
            await StatusService.Insert(Status);
            NavigationManager.NavigateTo("StatusList");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("StatusList");
        }
    }
}
