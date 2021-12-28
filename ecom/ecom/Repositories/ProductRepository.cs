using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecom.Models;
using ecom.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ecom.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _cache;
        public ProductRepository(ApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            this._dbContext = dbContext;
            this._cache = memoryCache;
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> productCollection = null;
            // If found in cache, return cached data
            if (_cache.TryGetValue("GetAllProduct", out productCollection))
            {
                return productCollection;
            }

            // If not found, then calculate response
            productCollection = await _dbContext.Products.ToListAsync();

            // Set cache options
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30));

            // Set object in cache
            _cache.Set("GetAllProduct", productCollection, cacheOptions);

            return productCollection;
        }

        public async Task<List<Product>> GetByName(string name)
        {
            /*
             Implement In-Memory Cache
                1.Declare products collection variable and defined cache key of collection.
                2.Make condition If found in cache, return cached data.
                3.Make condition If not found, then retrive data from db and collected to the cache.
             */

            return await _dbContext.Products.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        
    }
}
