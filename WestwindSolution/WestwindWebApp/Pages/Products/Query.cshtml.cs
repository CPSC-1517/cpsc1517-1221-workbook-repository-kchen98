using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public List<Category>? CategoryList { get; private set; }

        [BindProperty]
        public int SelectedCategoryId { get; set; }

        public SelectList? CategorySelectionList { get; private set; }
        #endregion

        public string? FeedbackMessage { get; private set; }
        public void OnGet(int? currentSelectedCategoryId)
        {
            // Fetch for the system (CategoryServices) a list of Category
            CategoryList = _categoryServices.List();
            CategorySelectionList = new SelectList(_categoryServices.List(), "Id", "CategoryName", SelectedCategoryId);

            if (currentSelectedCategoryId.HasValue && currentSelectedCategoryId.Value > 0)
            {
                SelectedCategoryId = currentSelectedCategoryId.Value;
            }
        }

        public IActionResult OnPostSearchByCategory()
        {
            FeedbackMessage = "You clicked on Search By Category";
            return RedirectToPage(new {currentSelectedCategoryId = SelectedCategoryId});
        }

        public IActionResult OnPostSearchByProductName()
        {
            FeedbackMessage = "You clicked on Search By Product Name";
            return RedirectToPage();
        }

        public IActionResult OnPostClearForm()
        {
            FeedbackMessage = "You clicked on Clear Form";
            return RedirectToPage();
        }
    }
}
