using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.Dto;
using UI.ServiceHttp;


namespace UI.Pages.Activity
{
    public partial class UpdateActivity
    {
        public ActivityGetDto Activity { get; set; }
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
        

        [Parameter] 
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        


        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async override Task OnInitializedAsync()
        {
            Saved = false;
            Activity = await ActivityService.GetById(Id);
            Statuses = (await statusHttpService.GetStatus()).ToList();
            Users = (await userHttpService.GetUser()).ToList();
            Units = (await unitHttpService.GetUnit()).ToList();         
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }

        protected async Task HandleValidSubmit()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", $"آیا از ویرایش وظیفه {Activity.Title}  مطمعن هستید");
            if (confirmed)
            {
               
                await ActivityService.Update(Activity);

                NavigationManager.NavigateTo("ActivityList");
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("showAlert", "Cancel");
            }
        }

        protected async Task Delete_Click(Guid Id)
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", $"آیا از حذف وظیفه {Activity.Title}  مطمعن هستید");

            if (confirmed)
            {
                await ActivityService.Delete(Id);
                StatusClass = "alert-success";
                Message = "حذف با موفقیت انجام شد.";
                Saved = true;
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("showAlert", "Cancel");
            }
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("ActivityList");
        }
    } 
}
