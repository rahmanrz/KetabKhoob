using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg.ValueObjects;

public class OrderItem : BaseEntity
{
    public OrderItem(long inventoryId, int count, int price)
    {
        CountGuard(count);
        PriceGuard(price);
        InventoryId = inventoryId;
        Count = count;
        Price = price;
    }

    public long OrederId { get; internal set; }

    public long InventoryId { get; private set; }

    public int Count { get; private set; }

    public int Price { get; private set; }

    public int TotalPrice => Price * Count;


    public void ChangeCount(int newCount)
    {
        CountGuard(newCount);
        Count = newCount;
    }

    public void SetPrice(int newPrice)
    {
        PriceGuard(newPrice);
        Price = newPrice;
    }

    public void PriceGuard(int newPrice)
    {
        if (newPrice < 1)

            throw new InvalidDomainDataException("مبلغ کالا نامعتبر است !");

    }

    public void CountGuard(int count)
    {
        if (count < 1)

            throw new InvalidDomainDataException ();

    }
}