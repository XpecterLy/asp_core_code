using ShopApi.Exceptions;
using ShopApi.Interfaces;
using ShopApi.Models;
using ShopApi.ViewModel;

namespace ShopApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DtProduct> AddProduct(ProductRequestInsertModel data)
        {
            var product = await _productRepository.GetProductByName(data.Name);

            if (product != null) throw new ConflictException("Producto already exist");

            return await _productRepository.AddProduct(new DtProduct
            {
                Name = data.Name,
                Price = data.Price,
                Stock = data.Stock,
                DateCreate = DateOnly.FromDateTime(DateTime.UtcNow)
            });
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);

            if (product == null) throw new NotFoundException("Producto not found");

            await _productRepository.DeleteProduct(product);
        }

        public async Task<DtProduct> GetProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);

            if (product == null) throw new NotFoundException("Producto not found");

            return product;
        }

        public async Task<IEnumerable<DtProduct>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<DtProduct> UpdateProduct(int id, ProductRequestUpdateModel? data)
        {
            if (data == null) throw new ArgumentNullException();

            var product = await _productRepository.GetProductById(id);

            if (product == null) throw new NotFoundException("Producto not found");

            product.Name = data.Name ?? product.Name;
            product.Price = data.Price ?? product.Price;
            product.Stock = data.Stock ?? product.Stock;

            return await _productRepository.UpdateProduct(id, product);
        }
    }
}
