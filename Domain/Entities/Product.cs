using Domain.Common;

namespace Domain.Entities;

public record Product : BaseEntity<int>
{
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public decimal Rate { get; set; }
}
