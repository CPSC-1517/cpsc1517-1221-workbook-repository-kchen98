﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.DAL;
using WestwindSystem.Entities;

namespace WestwindSystem.BLL
{
    public class ProductServices
    {
        private readonly WestwindContext _dbContext;

        internal ProductServices(WestwindContext context)
        {
            _dbContext = context;
        }

        public List<Product> FindProductsByCategoryID(int categoryId)
        {
            var query = _dbContext.Products.Where(item => item.Id == categoryId);
            return query.ToList();
        }
    }
}
