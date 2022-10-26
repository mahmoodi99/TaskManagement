using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Status
{
    public partial class DeleteStatus
    {
        public StatusDto Status { get; set; }

        [Inject]
        public IStatusHttpService StatusService { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Status = await StatusService.GetById(Id);
        }
        protected async Task Delete(Guid Id)
        {
            await StatusService.Delete(Id);
            NavigationManager.NavigateTo("StatusList");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("StatusList");
        }
    }
}
