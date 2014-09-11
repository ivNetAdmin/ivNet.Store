
using Orchard.UI.Resources;

namespace ivNet.Store
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            // Create and add a new manifest
            var manifest = builder.Add();

            // Define a "store" style sheet
            manifest.DefineStyle("ivNet.Store").SetUrl("store.css");

            // Define a "store" script
            manifest.DefineScript("AngularJS").SetUrl("angular.min.js").SetDependencies("jQuery");
            manifest.DefineScript("ivNet.Store").SetUrl("store.js").SetDependencies("AngularJS");
       
        }
    }
}