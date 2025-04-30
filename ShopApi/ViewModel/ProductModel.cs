using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModel
{
    public class ProductRequestInsertModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? Stock { get; set; } = 0;
    }

    public class ProductRequestUpdateModel
    {
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public int? Stock { get; set; }
    }
}
