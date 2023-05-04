using sporsalonutakipsistemi.Repositories;
using System.ComponentModel.DataAnnotations;

namespace sporsalonutakipsistemi.Models.Data
{
    public class Admin : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Kullanıcı adı* boş geçilemez.")]

        public string Username { get; set; }

        [Required(ErrorMessage = "*Şifre* boş geçilemez.")]
        public string Password { get; set; }
    }
}
