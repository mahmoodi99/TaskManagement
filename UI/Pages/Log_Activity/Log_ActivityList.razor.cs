using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Log_Activity
{
    public partial class Log_ActivityList
    {
        public List<Log_ActivityGetDto> LogActivity { get; set; } = new List<Log_ActivityGetDto>();

        private Log_ActivityGetDto logactivity = new Log_ActivityGetDto();

        [Inject]
        public ILogHttp_ActivityService LogActivityService { get; set; }


        protected async override Task OnInitializedAsync()
        {
            LogActivity = await LogActivityService.GetLog();
        }

    }
}

