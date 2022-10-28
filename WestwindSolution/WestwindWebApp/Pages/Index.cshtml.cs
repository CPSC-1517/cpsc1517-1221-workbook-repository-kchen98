using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region custom namespaces
using WestwindSystem.BLL;
using WestwindSystem.Entities;
#endregion

namespace WestwindWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly BuildVersionServices _buildVersionServices;

        // Ilogger is pre-generated we don't exactly need it unless we log something
        public IndexModel(ILogger<IndexModel> logger, BuildVersionServices buildVersionServices)
        {
            _logger = logger;
            _buildVersionServices = buildVersionServices;
        }

        public BuildVersion CurrentBuildVersion { get; set; } = null!;

        public void OnGet()
        {
            CurrentBuildVersion = _buildVersionServices.GetBuildVersion();
        }
    }
}