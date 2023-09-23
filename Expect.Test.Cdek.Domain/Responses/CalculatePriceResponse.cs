using Expect.Test.Cdek.Domain.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Expect.Test.Cdek.Domain.Responses
{
	public class CalculatePriceResponse
	{
		[JsonProperty("delivery_sum")]
		public float DeliverySum { get; set; }
		[JsonProperty("period_min")]
		public int PeriodMin { get; set; }
		[JsonProperty("period_max")]
		public int PeriodMax { get; set; }
		[JsonProperty("weight_calc")]
		public int WeightCalc { get; set; }
		public IEnumerable<ServiceResponse> Services { get; set; }
		[JsonProperty("total_sum")]
		public float TotalSum { get; set; }
		public string Currency { get; set; }
	}
}
