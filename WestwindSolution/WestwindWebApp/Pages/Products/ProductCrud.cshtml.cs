using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WestwindSystem.BLL;
using WestwindSystem.Entities;

namespace WestwindWebApp.Pages.Products
{
    public class ProductCrudModel : PageModel
    {
        #region internal fields
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        #endregion

        #region data properties for page
        [BindProperty(SupportsGet = true)]
        public int? EditProductId { get; set; }
        #endregion

        #region constructor with dependencies
       
        #endregion

        #region page handlers
        public void OnGet()
        {
        }
        #endregion
    }
}
