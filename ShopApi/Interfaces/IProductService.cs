using ShopApi.Models;
using ShopApi.ViewModel;

namespace ShopApi.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<DtProduct>> GetProducts();
        public Task<DtProduct> GetProduct(int id);
        public Task<DtProduct> AddProduct(ProductRequestInsertModel data);
        public Task<DtProduct> UpdateProduct(int id, ProductRequestUpdateModel? data);
        public Task DeleteProduct(int id);
    }
}
