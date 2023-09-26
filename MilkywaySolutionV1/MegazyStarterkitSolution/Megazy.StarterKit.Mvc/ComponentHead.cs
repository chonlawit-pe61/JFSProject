
namespace Megazy.StarterKit.Mvc
{
    public class ComponentHead
    {
        public string Title { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string Canonical { get; set; }
        public OgFacebookData OgFacebook { get; set; }

    }
    public class OgFacebookData
    {
        public string ShareURL { get; set; }
        public string Type { get; set; } = "article";
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagUrl { get; set; }
        public string ImageAlt { get; set; } = "";
        public string ImageType { get; set; } = "image/jpeg";
        public int ImageCoverWidth { get; set; } = 800;
        public int ImageCoverHeight { get; set; } = 420;
        public string SiteName { get; set; } = "";// CSystems.Website;
        public string AppID { get; set; } = "";

    }
}
