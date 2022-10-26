using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Unit
{
    public partial class UpdateUnit
    {
        public UnitDto Unit { get; set; }       
        

        [Inject]
        public IUnitHttpService UnitService { get; set; }

       

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Unit = await UnitService.GetById(Id);            
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }

        protected async Task HandleValidSubmit()
        {           
                await UnitService.Update(Unit);
                NavigationManager.NavigateTo("UnitList");           
        }

        protected async Task Delete_Click(Guid Id)
        {           
                await UnitService.Delete(Id);              
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("UnitList");
        }
    }
}
