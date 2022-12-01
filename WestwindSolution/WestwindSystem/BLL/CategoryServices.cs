using Microsoft.EntityFrameworkCore;
using WestwindSystem.DAL;
using WestwindSystem.Entities;

namespace WestwindSystem.BLL
{
    public class CategoryServices
    {
        // Step 1: Define a readonly data field for the custom DbContext class

        private readonly WestwindContext _dbContext;

        // Step 2: Setup constructor for dependency injection for the custom DbContext type
        internal CategoryServices(WestwindContext context)
        {
            _dbContext = context;
        }

        // Step 3: Define methods to query and save instances of the entity
        public List<Category> List()
        {
            IEnumerable<Category> query = _dbContext
                .Categories
                .OrderBy(item => item.CategoryName);
            return query.ToList();
        }

        public Dictionary<int, string> DictionaryOfSelectItem()
        {
            var query = _dbContext
                .Categories
                .OrderBy(item => item.CategoryName)
                .Select(item => new { item.Id, item.CategoryName });
            return query.ToDictionary(item => item.Id, item => item.CategoryName);
        }

        public Category? GetById(int categoryId)
        {
            var query = _dbContext
                .Categories
                .Where(item => item.Id == categoryId);
            return query.FirstOrDefault();
        }

        public Category? FindByName(string categoryName)
        {
            var query = _dbContext
                .Categories
                .Where(item => item.CategoryName == categoryName);
            return query.FirstOrDefault();
        }

        public List<Category> FindByPartialDescription(string partialDescription)
        {
            var query = _dbContext
                .Categories
                .Where(item => item.Description!.Contains(partialDescription));
            return query.ToList();
        }

        public int AddCategory(Category newCategory)
        {
            // Enforce business rule where CategoryName must be unique
            bool exists = _dbContext.Categories.Any(c => c.CategoryName == newCategory.CategoryName);
            if (exists)
            {
                throw new ArgumentException($"The Category Name {newCategory.CategoryName} already exists!");
            }

            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
            return newCategory.Id;
        }

        public int UpdateCategory(Category existingCategory)
        {
            _dbContext.Categories.Attach(existingCategory).State = EntityState.Modified;
            int rowsUpdated = _dbContext.SaveChanges();
            return rowsUpdated;
        }

        public int DeleteCategory(int categoryID)
        {
            Category? existingCategory = _dbContext.Categories
                .Where(c => c.Id == categoryID)
                .Include(c => c.Products)
                .FirstOrDefault();

            if (existingCategory == null)
            {
                throw new ArgumentException($"CategoryID {categoryID} does not exists.");
            }
            int categoryProductCount = existingCategory.Products.Count();
            if (categoryProductCount > 0)
            {
                throw new Exception("This categories has products and cannot be deleted.");
            }

            _dbContext.Categories.Remove(existingCategory);
            int rowsDeleted = _dbContext.SaveChanges();
            return rowsDeleted;
        }
    }
}
