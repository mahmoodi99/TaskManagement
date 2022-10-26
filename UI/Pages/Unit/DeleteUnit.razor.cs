using Microsoft.AspNetCore.Components;
using Share.Dto;
using UI.ServiceHttp;

namespace UI.Pages.Unit
{
    public partial class DeleteUnit
    {
        public UnitDto Unit { get; set; }

        [Inject]
        public IUnitHttpService UnitService { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Unit = await UnitService.GetById(Id);
        }
        protected async Task Delete(Guid Id)
        {
            await UnitService.Delete(Id);
            NavigationManager.NavigateTo("UnitList");
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("UnitList");
        }
    }
}
