
using ivNet.Store.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace ivNet.Store.Handlers
{
    public class ProductPartHandler : ContentHandler
    {
        public ProductPartHandler(IRepository<ProductPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}
