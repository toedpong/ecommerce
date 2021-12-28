using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecom.Models;
using ecom.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ecom.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
           
        }
        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
           return await _productRepository.GetAll();
        }

        // GET api/products/Product 1
        [HttpGet("{name}")]
        public async Task<ActionResult<List<Product>>> Get(string name)
        {
            return await _productRepository.GetByName(name);
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
