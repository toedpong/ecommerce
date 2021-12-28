using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ecom.Models;

namespace ecom.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task<List<Product>> GetByName(string name);
    }
}
