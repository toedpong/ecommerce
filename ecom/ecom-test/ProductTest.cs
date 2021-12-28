using System;
using System.Collections.Generic;
using ecom.Models;
using Xunit;

namespace ecom_test
{
    public class ProductTest
    {
        public ProductTest()
        {
        }
        [Fact]
        public List<Product> GetAll()
        {
            var p = new List<Product>() {
                new Product { Id = 1, Name = "Product 1", Description = "Desc Product 1", Price = 100, Image = "image1.png" },
                new Product { Id = 2, Name = "Product 2", Description = "Desc Product 2", Price = 100, Image = "image2.png" }
                };
            return p;
        }
    }
}
