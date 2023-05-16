using Clean_arch.Domain.Shared;

namespace Clean_arch.Domain.ProductAgg.Events;

public class ProductEdited : BaseDomainEvent
{
    public long ProductId { get; set; }
    public string Name { get; set; }
}