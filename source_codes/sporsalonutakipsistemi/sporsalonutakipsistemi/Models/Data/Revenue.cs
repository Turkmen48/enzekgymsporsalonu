using Microsoft.EntityFrameworkCore.Metadata.Internal;
using sporsalonutakipsistemi.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sporsalonutakipsistemi.Models.Data
{
    public class Revenue : IEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public double PriceValue { get; set; }


        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Month { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Year { get; set; }


        public string Description { get; set; }

    }
}
