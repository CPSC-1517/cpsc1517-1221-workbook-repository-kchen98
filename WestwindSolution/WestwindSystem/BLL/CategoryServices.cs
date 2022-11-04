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
    }
}
