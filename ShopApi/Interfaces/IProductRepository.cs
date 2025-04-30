using ShopApi.Models;

namespace ShopApi.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<DtProduct>> GetProducts();
        public Task<DtProduct> GetProductById(int id);
        public Task<DtProduct> GetProductByName(string name);
        public Task<DtProduct> AddProduct(DtProduct data);
        public Task<DtProduct> UpdateProduct(int id, DtProduct data);
        public Task DeleteProduct(DtProduct data);
    }
}
