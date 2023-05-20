using sporsalonutakipsistemi.Repositories;
using System.ComponentModel.DataAnnotations;

namespace sporsalonutakipsistemi.Models.Data
{
    public class EmailSetting : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email adresi girmeniz zorunludur!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Smtp adresi girmeniz zorunludur!")]
        public string SmtpAddress { get; set; }

        [Required(ErrorMessage = "Port girmeniz zorunludur!")]
        public string Port { get; set; }

        [Required(ErrorMessage = "Şifre girmeniz zorunludur!")]
        public string Password { get; set; }

        public string EmailTemplate { get; set; }




    }
}
