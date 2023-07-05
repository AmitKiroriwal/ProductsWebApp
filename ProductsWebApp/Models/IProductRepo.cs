
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductsWebApp.Models;

public interface IProductRepo
{
    public List<Products> GetProducts();
    public Task<Products> AddProduct(Products product);
    public Task<Products> UpdateProduct(Products product);
    public Products GetProductById(int id);
    public Products DeleteProduct(int id);

    public Task<IEnumerable<SelectListItem>> CategoryList();
    public Task<IEnumerable<SelectListItem>> SubCategoryList();
    
}
