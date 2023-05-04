using sporsalonutakipsistemi.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sporsalonutakipsistemi.Models.Data
{
	public class Price : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Column(TypeName = "nvarchar(20)")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Lütfen fiyat bilgisini giriniz")]
		[Column(TypeName = "smallmoney")]
		public double PriceValue { get; set; }

		public string Description { get; set; }

		[Required(ErrorMessage = "Lütfen ay bilgisini giriniz")]
		public int Months { get; set; }

		[Required]
		public bool Status { get; set; }

	}
}
