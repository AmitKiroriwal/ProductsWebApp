
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductsWebApp.Models
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext appDbContext;

        public ProductRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Products> AddProduct(Products product)
        {
           appDbContext.Products.Add(product);
            appDbContext.SaveChanges();
            return product;
        }

        public Task<IEnumerable<SelectListItem>> CategoryList()
        {
            throw new NotImplementedException();
        }

        

        public Products DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Products GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> SubCategoryList()
        {
            throw new NotImplementedException();
        }

        public Task<Products> UpdateProduct(Products product)
        {
            throw new NotImplementedException();
        }
    }
}
