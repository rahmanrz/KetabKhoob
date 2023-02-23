using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using FsCheck.Experimental;

namespace Shop.Domain.SellerAgg
{
    public class Seller:AggregateRoot
    {
      
        public long  SellerId { get; set; }

        public string  ShopName { get; private set; }

        public string  NationalCode { get; private set; }

        public SellerStatus   Status { get; private set; }
        public DateTime LastUpdate { get; private set; }    
        public List<SellerInventory> Inventories { get; private set; }

        private Seller()
        {

        }
        public Seller(long sellerId, string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);
            SellerId = sellerId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories  = new List<SellerInventory>();
        }


        public void AddInventor(SellerInventory inventory)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId)) ;
            throw new InvalidDomainDataException("این محصول قبلا ثیت شده است !");
            Inventories.Add(inventory);
        }
        public void EditInventor(SellerInventory newInventory)
        {
            var currentInventory = Inventories.FirstOrDefault(f => f.Id == newInventory.Id);
            if(currentInventory == null) 
                return;
            Inventories.Remove(currentInventory);
                Inventories.Add(newInventory);

        }
        public void DeleteInventor(long inventoryId)
        {
            var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد!");
            Inventories.Remove(currentInventory);
         

        }
        public void ChangeStatus(SellerStatus status)
        {

            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);
            ShopName = shopName;

            NationalCode = nationalCode;

        }

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName,nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کدملی نامعتبر است !");

        }

    }
}
