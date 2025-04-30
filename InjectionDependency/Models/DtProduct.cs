using System;
using System.Collections.Generic;

namespace InjectionDependency.Models;

public partial class DtProduct
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Count { get; set; }

    public DateOnly? DateCreate { get; set; }
}
