using sporsalonutakipsistemi.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sporsalonutakipsistemi.Models.Data
{
    public class SiteAdressInfo : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Adres alanı boş geçilemez")]
        [StringLength(200, ErrorMessage = "Adres alanı 200 karakterden fazla olamaz")]
        [Column(TypeName = "Nvarchar(200)")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş geçilemez")]
        [StringLength(50, ErrorMessage = "Telefon alanı 50 karakterden fazla olamaz")]
        [Column(TypeName = "Nvarchar(50)")]
        public string Phone { get; set; }

        [StringLength(50, ErrorMessage = "Telefon alanı 50 karakterden fazla olamaz")]
        [Column(TypeName = "Nvarchar(50)")]
        public string Phone2 { get; set; }

        [StringLength(50, ErrorMessage = "Email alanı 50 karakterden fazla olamaz")]
        [Column(TypeName = "Nvarchar(50)")]
        public string Email { get; set; }

        [StringLength(500, ErrorMessage = "Map Url alanı 500 karakterden fazla olamaz")]
        [Column(TypeName = "Nvarchar(500)")]
        public string MapUrl { get; set; }
    }
}
