using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.DAL;
using WestwindSystem.Entities;

namespace WestwindSystem.BLL
{
    public class SupplierServices
    {
        private readonly WestwindContext _dbContext;

        internal SupplierServices(WestwindContext context)
        {
            _dbContext = context;
        }

        public List<Supplier> List()
        {
            var query = _dbContext
                .Suppliers
                .OrderBy(currentSupplier => currentSupplier.CompanyName)
                .ThenBy(currentSupplier => currentSupplier.ContactName);
            return query.ToList();
        }
    }
}
