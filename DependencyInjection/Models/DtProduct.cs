using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models;

public partial class DtProduct
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public DateOnly? DateCreate { get; set; }
}
