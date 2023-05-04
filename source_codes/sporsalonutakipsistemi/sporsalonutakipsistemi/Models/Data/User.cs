using sporsalonutakipsistemi.Repositories;
using System.ComponentModel.DataAnnotations;

namespace sporsalonutakipsistemi.Models.Data
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen email alanını doldurunuz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifre alanını doldurunuz")]
        public string Password { get; set; }


        public bool IsActive { get; set; }


    }
}
