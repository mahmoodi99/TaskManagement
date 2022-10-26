using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Activity
{
    public partial class AddActivity
    {
        public ActivityGetDto Activity { get; set; } = new ActivityGetDto();
        public List<StatusDto> Statuses { get; set; } = new List<StatusDto>();
        public List<UserDto> Users { get; set; } = new List<UserDto>();
        public List<UnitDto> Units { get; set; } = new List<UnitDto>();
        public string UnitId { get; set; }
        public string UserId { get; set; }
        public string StatusId { get; set; }


        [Inject]
        public IActivityHttpService ActivityService { get; set; }

        [Inject]
        public IStatusHttpService statusHttpService { get; set; }

        [Inject]
        public IUserHttpService userHttpService { get; set; }

        [Inject]
        public IUnitHttpService unitHttpService { get; set; }        

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }


        protected async override Task OnInitializedAsync()
        {         
            Statuses = (await statusHttpService.GetStatus()).ToList();
            Users = (await userHttpService.GetUser()).ToList();
            Units = (await unitHttpService.GetUnit()).ToList();
        }


        protected async Task Save()
        {
            await ActivityService.Insert(Activity);
            NavigationManager.NavigateTo("ActivityList");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("ActivityList");
        }
    }
}
