using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WestwindSystem.BLL;
using WestwindSystem.Entities;

namespace WestwindWebApp.Pages.Products
{
    public class ProductCategoryModel : PageModel
    {
        #region internal fields
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;
        #endregion

        #region data properties for page
        // Data source for category select element 
        public SelectList CategorySelectList { get; private set; }

        // Bind property for value selected from select element
        [BindProperty]
        public int? SelectedCategoryId { get; set; }

        public SelectList SupplierSelectList { get; private set; }

        // Query result property
        public List<Product>? QueryProductResultList { get; private set; }

        // Feedback Message properties
        public string? InfoMessage { get; set; }
        public string? ErrorMessage { get; set; }
        #endregion

        #region constructor with dependencies
        public ProductCategoryModel(CategoryServices categoryServices, ProductServices productServices, SupplierServices supplierServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;
            _supplierServices = supplierServices;

            // Fetch list of categories
            List<Category> categories = _categoryServices.List();
            CategorySelectList = new SelectList(categories, "Id", "CategoryName");

            // Fetch list of suppliers
            List<Supplier> suppliers = _supplierServices.List();
            SupplierSelectList = new SelectList(suppliers, "SupplierId", "ListItemText");
        }
        #endregion

        #region page handlers
        public void OnGet()
        {
        }

        public IActionResult OnPostFetchProducts()
        {
            IActionResult nextPage = Page();

            // Verify that a valid category was selected
            if (SelectedCategoryId.HasValue && SelectedCategoryId.Value > 0)
            {
                int categoryId = SelectedCategoryId.Value;
                QueryProductResultList = _productServices.FindProductsByCategoryID(categoryId);
                InfoMessage = $"Query returned {QueryProductResultList.Count} record(s).";
            }
            else
            {
                ErrorMessage = "A valid category must be selected";
            }
            return nextPage;
        }

        public IActionResult OnPostClear()
        {
            IActionResult nextPage = Page();
            SelectedCategoryId = null;
            QueryProductResultList = null;
            ModelState.Clear();
            return nextPage;
        }

        public IActionResult OnPostNewProduct()
        {
            IActionResult nextPage = RedirectToPage("/Products/ProductCrud");
            return nextPage;
        }
        #endregion

    }
}
