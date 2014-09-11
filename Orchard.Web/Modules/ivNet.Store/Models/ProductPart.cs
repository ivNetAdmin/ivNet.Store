
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace ivNet.Store.Models
{
    public class ProductPart: ContentPart<ProductPartRecord>
    {
        public decimal UnitPrice
        {
            get { return Record.UnitPrice; }
            set { Record.UnitPrice = value; }
        }
 
        public string Sku
        {
            get { return Record.Sku; }
            set { Record.Sku = value; }
        }
    }

    public class ProductPartRecord : ContentPartRecord
    {
        public virtual decimal UnitPrice { get; set; }
        public virtual string Sku { get; set; }
    }
}