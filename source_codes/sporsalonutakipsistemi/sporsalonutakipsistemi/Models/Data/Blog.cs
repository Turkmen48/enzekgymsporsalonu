using sporsalonutakipsistemi.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sporsalonutakipsistemi.Models.Data
{
    public class Blog : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur!")]
        public string Content { get; set; }

        [Column(TypeName = "Date")]
        public DateTime BlogDate { get; set; }


        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur!")]
        public string ReadTime { get; set; }
    }
}
