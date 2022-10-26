using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Status
{
    public partial class UpdateStatus
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

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }

        protected async Task HandleValidSubmit()
        {
            await StatusService.Update(Status);
            NavigationManager.NavigateTo("StatusList");
        }

        protected async Task Delete_Click(Guid Id)
        {
            await StatusService.Delete(Id);
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("StatusList");
        }
    }
}
