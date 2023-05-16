using Clean_arch.Domain.Shared;

namespace Clean_arch.Domain.ProductAgg.Events;

public class ProductCreated : BaseDomainEvent
{
    public ProductCreated(long id, string title)
    {
        Id = id;
        Title = title;
    }

    public long Id { get; set; }
    public string Title { get; set; }
}