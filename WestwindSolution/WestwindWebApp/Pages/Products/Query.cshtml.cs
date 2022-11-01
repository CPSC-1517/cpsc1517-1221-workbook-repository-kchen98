using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region namespaces for BLL and Entities
using WestwindSystem.BLL;
using WestwindSystem.Entities;
#endregion

namespace WestwindWebApp.Pages.Products
{
    public class QueryModel : PageModel
    {
        #region Setup constructor DI for BLL
        private readonly CategoryServices _categoryServices;

        public QueryModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        #endregion

        #region Properties to populate select element and track it's selected value
        public List<Category> CategoryList { get; private set; }

        [BindProperty]
        public int SelectedCategoryId { get; set; }
        #endregion
        public void OnGet()
        {
            // Fetch for the system (CategoryServices) a list of Category
            CategoryList = _categoryServices.List();
        }
    }
}
