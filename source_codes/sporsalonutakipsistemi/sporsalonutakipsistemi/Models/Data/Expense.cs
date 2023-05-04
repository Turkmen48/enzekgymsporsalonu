using Microsoft.EntityFrameworkCore.Metadata.Internal;
using sporsalonutakipsistemi.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sporsalonutakipsistemi.Models.Data
{
    public class Expense : IEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public double ExpenseValue { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        [StringLength(50, ErrorMessage = "Lütfen 50 karakterden fazla değer girmeyiniz")]
        public string Month { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        [StringLength(50, ErrorMessage = "Lütfen 50 karakterden fazla değer girmeyiniz")]
        public string Year { get; set; }

        public string Description { get; set; }
    }
}
