using System.Linq;
using System.Web;
using ivNet.Store.Models;
using Orchard;
using System.Collections.Generic;
using Orchard.ContentManagement;

namespace ivNet.Store.Services
{
    public interface IShoppingCart : IDependency
    {
        IEnumerable<ShoppingCartItem> Items { get; }
        void Add(int productId, int quantity = 1);
        void Remove(int productId);
        ProductPart GetProduct(int productId);
        IEnumerable<ProductQuantity> GetProducts();
        decimal Subtotal();
        decimal Vat();
        decimal Total();
        int ItemCount();
        void UpdateItems();
    }

    public class ShoppingCart : IShoppingCart
    {
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IContentManager _contentManager;
        public IEnumerable<ShoppingCartItem> Items { get { return ItemsInternal.AsReadOnly(); } }

        public ShoppingCart(IWorkContextAccessor workContextAccessor, IContentManager contentManager)
        {
            _workContextAccessor = workContextAccessor;
            _contentManager = contentManager;
        }

        public void Add(int productId, int quantity = 1)
        {
            var item = Items.SingleOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                item = new ShoppingCartItem(productId, quantity);
                ItemsInternal.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void Remove(int productId)
        {
            var item = Items.SingleOrDefault(x => x.ProductId == productId);

            if (item == null)
                return;

            ItemsInternal.Remove(item);
        }

        public ProductPart GetProduct(int productId)
        {
            return _contentManager.Get<ProductPart>(productId);
        }

        public IEnumerable<ProductQuantity> GetProducts()
        {
            // Get a list of all product IDs from the shopping cart
            var ids = Items.Select(x => x.ProductId).ToList();

            // Load all product parts by the list of IDs
            var productParts = _contentManager.GetMany<ProductPart>(ids, VersionOptions.Latest, QueryHints.Empty).ToArray();

            // Create a LINQ query that projects all items in the shoppingcart into shapes
            var query = from item in Items
                        from productPart in productParts
                        where productPart.Id == item.ProductId
                        select new ProductQuantity
                        {
                            ProductPart = productPart,
                            Quantity = item.Quantity
                        };

            return query;
        }

        public void UpdateItems()
        {
            ItemsInternal.RemoveAll(x => x.Quantity == 0);
        }

        public decimal Subtotal()
        {
            return Items.Select(x => GetProduct(x.ProductId).UnitPrice * x.Quantity).Sum();
        }

        public decimal Vat()
        {
            return Subtotal() * .20m;
        }

        public decimal Total()
        {
            return Subtotal() + Vat();
        }

        public int ItemCount()
        {
            return Items.Sum(x => x.Quantity);
        }

        private void Clear()
        {
            ItemsInternal.Clear();
            UpdateItems();
        }
 
        private List<ShoppingCartItem> ItemsInternal
        {
            get
            {
                
                var items = (List<ShoppingCartItem>)HttpContext.Current.Session["ShoppingCart"];

                if (items == null)
                {
                    items = new List<ShoppingCartItem>();
                    HttpContext.Current.Session["ShoppingCart"] = items;
                }

                return items;
            }
        }
 
    }
}