
using Newtonsoft.Json;

namespace Expect.Test.Cdek.Domain.Models
{
	public class CalculatorDto
	{
		[JsonProperty("tariff_code")]
		public int TarrifCode { get; set; } //Тариф Эксперсс Склад-Склад (483)
		[JsonProperty("from_location")]
		public Location FromLocation { get; set; } // Москва 44
		[JsonProperty("to_location")]
		public Location ToLocation { get; set; } // Санкт-Петербург 137
		public IEnumerable<Package> Packages { get; set; }
		public IEnumerable<Service>? Services { get; set; }
	}
}
