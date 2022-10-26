using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Unit
{
    public partial class AddUnit
    {
        public UnitDto Unit { get; set; } = new UnitDto();
       
        [Inject]
        public IUnitHttpService UnitService { get; set; }       

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected async Task Save()
        {
            await UnitService.Insert(Unit);
            NavigationManager.NavigateTo("UnitList");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("UnitList");
        }
    }
}
