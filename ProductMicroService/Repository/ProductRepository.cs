using Microsoft.EntityFrameworkCore;
using ProductMicroService.Data;
using ProductMicroService.Models;

namespace ProductMicroService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void DeleteProduct(int productId)
        {
            var prodcut = _context.products.Find(productId);
            _context.products.Remove(prodcut);
            Save();
        }

        public Product GetProductById(int product)
        {
            return _context.products.Find(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _context.products.Add(product);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
