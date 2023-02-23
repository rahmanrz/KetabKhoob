using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg;

public class SellerInventory  : BaseEntity 
{
    public SellerInventory(long sellerId, long productId, int price , int count)
    {
        if(price < 1 ||price < 0);
        {
            throw new InvalidDomainDataException();
        }
        SellerId = sellerId;
        ProductId = productId;
        Price = price;
        Count = count;
    }
    public long SellerId { get; internal set; }

    public long ProductId { get; private set; }

    public int Price { get; private set; }  
    public int Count { get; private set; }


}