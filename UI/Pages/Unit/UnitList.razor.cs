using Microsoft.AspNetCore.Components;
using Share.Dto;
using System.Diagnostics;
using UI.ServiceHttp;

namespace UI.Pages.Unit
{
    public partial class UnitList
    {
        public List<UnitDto> Units { get; set; } = new List<UnitDto>();

        [Inject]
        public IUnitHttpService UnitService { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Units = await UnitService.GetUnit();
        }
    }
}
