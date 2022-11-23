using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindSystem.BLL;
using WestwindSystem.Entities;

namespace WestwindWebApp.Pages.Territories
{
    public class QueryModel : PageModel
    {
        private readonly RegionServices _regionServices;
        private readonly TerritoryServices _territoryServices;

        public QueryModel(RegionServices regionServices, TerritoryServices territoryServices)
        {
            _regionServices = regionServices;
            _territoryServices = territoryServices;

            Regions = _regionServices.GetAll();
        }

        public List<Region> Regions { get; private set; }

        [BindProperty]
        public int? SelectedRegionId { get; set; }

        public List<Territory> QueryResultList { get; private set; }

        public string? FeedbackMessage { get; set; }

        [BindProperty]
        public string TerritoryQuery { get; set; }

        public void OnGet()
        {
        }

        public void OnPostFilterByTerritory()
        {
            if (TerritoryQuery != null)
            {
                QueryResultList = _territoryServices.FindByPartialName(TerritoryQuery);
            }
            else
            {
                FeedbackMessage = "You need to enter a territory first.";
            }
        }

        public void OnPostFilterByRegion()
        {
            // Check if a valid region was selected
            if (SelectedRegionId.HasValue)
            {
                QueryResultList = _territoryServices.FindByRegionId(SelectedRegionId.Value);
            }
            else
            {
                FeedbackMessage = "You must select a region first.";
            }
        }
    }
}
