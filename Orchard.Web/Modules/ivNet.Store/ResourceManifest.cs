
using Orchard.UI.Resources;

namespace ivNet.Store
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            // Create and add a new manifest
            var manifest = builder.Add();

            // Define a "common" style sheet
            manifest.DefineStyle("ivNet.Store").SetUrl("store.css");
       
        }
    }
}