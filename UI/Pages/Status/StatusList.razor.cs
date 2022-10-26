using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Status
{
    public partial class StatusList
    {
        public List<StatusDto> Statuses { get; set; } = new List<StatusDto>();

        [Inject]
        public IStatusHttpService StatusService { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Statuses = await StatusService.GetStatus();
        }
    }
}
