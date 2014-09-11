
using ivNet.Store.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace ivNet.Store.Drivers
{
    public class ProductPartDriver : ContentPartDriver<ProductPart>
    {
        protected override string Prefix
        {
            get { return "ProductPart"; }
        }

        protected override DriverResult Editor(ProductPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Product_Edit", () => shapeHelper
                .EditorTemplate(TemplateName: "Parts.Product", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(ProductPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override DriverResult Display(ProductPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_Product", () => shapeHelper.Parts_Product(
                    Price: part.UnitPrice,
                    Sku: part.Sku
                ));
        }
    }
}