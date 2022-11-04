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
        private readonly ProductServices _productServices;

        public QueryModel(CategoryServices categoryServices, ProductServices productServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;

            // Fetch for the system (CategoryServices) a list of Category
            CategoryList = _categoryServices.List();
            CategorySelectionList = new SelectList(_categoryServices.List(), "Id", "CategoryName", SelectedCategoryId);
        }
        #endregion

        #region Properties to populate select element and track it's selected value
        public List<Category>? CategoryList { get; private set; }

        [BindProperty]
        public int SelectedCategoryId { get; set; }

        public SelectList? CategorySelectionList { get; private set; }
        #endregion

        [BindProperty]
        public string? QueryProductName { get; set; }

        [TempData]
        public string? FeedbackMessage { get; set; }

        public List<Product>? QueryResultList { get; private set; }

        public void OnPostSearchByCategory()
        {
            FeedbackMessage = "You clicked on Search By Category";
            QueryResultList = _productServices.FindProductsByCategoryID(SelectedCategoryId);
        }

        public void OnPostSearchByProductName()
        {
            FeedbackMessage = "You clicked on Search By Product Name";
            QueryResultList = _productServices.FindProductsByProductName(QueryProductName!);
        }

        public IActionResult OnPostClearForm()
        {
            FeedbackMessage = "You clicked on Clear Form";
            return RedirectToPage();
        }

        public void OnGet()
        {

        }
    }
}
