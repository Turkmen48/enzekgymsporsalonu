using sporsalonutakipsistemi.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sporsalonutakipsistemi.Models.Data
{
    public class Contact : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        [Column(TypeName = "Nvarchar(30)")]
        [StringLength(30, ErrorMessage = "30 karakterden fazla giremezsiniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        [Column(TypeName = "Nvarchar(20)")]
        [StringLength(20, ErrorMessage = "20 karakterden fazla giremezsiniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        [Column(TypeName = "Nvarchar(30)")]
        [StringLength(30, ErrorMessage = "30 karakterden fazla giremezsiniz")]

        public string Subject { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        [Column(TypeName = "Nvarchar(30)")]
        [StringLength(30, ErrorMessage = "30 karakterden fazla giremezsiniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        [Column(TypeName = "Nvarchar(500)")]
        [StringLength(500, ErrorMessage = "500 karakterden fazla giremezsiniz")]
        public string Message { get; set; }


        public bool IsRead { get; set; }
    }
}
