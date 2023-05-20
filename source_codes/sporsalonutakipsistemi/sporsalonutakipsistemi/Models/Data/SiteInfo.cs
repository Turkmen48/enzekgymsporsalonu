using sporsalonutakipsistemi.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sporsalonutakipsistemi.Models.Data
{
    public class SiteInfo : IEntity
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public string LogoUrl { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwUrl { get; set; }
        public string YoutubeUrl { get; set; }

        public string SiteName { get; set; }

    }
}
