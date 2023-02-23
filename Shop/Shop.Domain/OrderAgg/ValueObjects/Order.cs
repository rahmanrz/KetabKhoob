using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class Order : AggregateRoot
    {
        private Order()
        {
            
        }

        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public OrderAddress? Address { get;  set; }
        public ShippingMethod? ShippingMethod { get; set; }

        public DateTime ? LastUpdate  { get; set; }

        public List<OrderItem> Items { get; private set; }

        public int TotalPrice
        {
            get
            {
                var TotalPrice = Items.Sum(s => s.TotalPrice);
                if (TotalPrice != null)
                    TotalPrice += ShippingMethod.ShippingCost;

                if (Discount != null)
                    TotalPrice -= Discount.DiscountAmount;
                    return 0;
            }
        }

        public int ItemCount => Items.Count;


        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(long itemId)
        {
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem != null) 
            Items.Remove(currentItem);
        }

        public void ChangeCountItem(long itemId, int newCount)
        {
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem != null)
                throw new NullOrEmptyDomainDataException();
            currentItem.ChangeCount(newCount);
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void CheackOut(OrderAddress orderAddress )
        {
             Address = orderAddress; 
              
        }
    }


    public enum OrderStatus
    {
        Pending,
        Finally,
        Shipping,
        Regicted
    }

  
}
