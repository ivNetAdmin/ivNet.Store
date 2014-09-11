using Orchard.UI.Resources;

namespace PJS.Bootstrap {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            manifest.DefineScript("Bootstrap").SetUrl("bootstrap-3.1.1/js/bootstrap.min.js", "bootstrap-3.1.1/js/bootstrap.js").SetDependencies("jQuery");
            manifest.DefineScript("HoverDropdown").SetUrl("hover-dropdown.js").SetDependencies("Bootstrap");
            manifest.DefineScript("Custom").SetUrl("custom.js").SetDependencies("jQuery");
            manifest.DefineScript("Theme-ValidationEngine-en").SetUrl("validationEngine/jquery.validationEngine-en.js").SetVersion("2.6.2").SetDependencies("jQuery");
            manifest.DefineScript("Theme-ValidationEngine").SetUrl("validationEngine/jquery.validationEngine.js").SetVersion("2.6.2").SetDependencies("ValidationEngine-en");
            manifest.DefineScript("Isotope").SetUrl("isotope/jquery.isotope.min.js").SetVersion("1.5.25").SetDependencies("jQuery");
            manifest.DefineScript("prettyPhoto").SetUrl("prettyPhoto/jquery.prettyPhoto.min.js").SetVersion("3.1.5").SetDependencies("jQuery");

            manifest.DefineStyle("prettyPhoto").SetUrl("prettyPhoto/prettyPhoto.css");
        }
    }
}
