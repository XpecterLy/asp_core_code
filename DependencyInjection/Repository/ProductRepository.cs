using Microsoft.EntityFrameworkCore;
using ShopApi.Interfaces;
using ShopApi.Models;

namespace ShopApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextShoopDb _context;

        public ProductRepository(DbContextShoopDb context)
        {
            _context = context;
        }

        public async Task<DtProduct> AddProduct(DtProduct data)
        {
            _context.DtProducts.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task DeleteProduct(DtProduct data)
        {
            _context.DtProducts.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<DtProduct> GetProductById(int id)
        {
            return await _context.DtProducts.FindAsync(id);
        }

        public async Task<DtProduct> GetProductByName(string name)
        {
            return await _context.DtProducts.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<DtProduct>> GetProducts()
        {
            return await _context.DtProducts.ToListAsync();
        }

        public async Task<DtProduct> UpdateProduct(int id, DtProduct data)
        {
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
