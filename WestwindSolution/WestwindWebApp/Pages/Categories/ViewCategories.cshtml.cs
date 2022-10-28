using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindSystem.BLL;
using WestwindSystem.Entities;

namespace WestwindWebApp.Pages.Categories
{
    public class ViewCategoriesModel : PageModel
    {
        private readonly CategoryServices _categoryServices;

        public ViewCategoriesModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public List<Category> Categories { get; private set; } = new List<Category>();
        public void OnGet()
        {
            Categories = _categoryServices.List();
        }
    }
}
