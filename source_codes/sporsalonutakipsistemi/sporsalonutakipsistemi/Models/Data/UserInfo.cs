using sporsalonutakipsistemi.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace sporsalonutakipsistemi.Models.Data
{
    public class UserInfo : IEntity
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Lütfen geçerli bir TC kimlik numarası girin")]
        public long Tc { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Surname { get; set; }

        [StringLength(30, ErrorMessage = "30 karakterden fazla giremezsiniz")]
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Phone { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? PlanStartDate { get; set; }
        public DateTime? PlanEndDate { get; set; }

        [Required(ErrorMessage = "Lütfen bir plan seçiniz")]
        public int PriceId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Price Price { get; set; }


    }
}
