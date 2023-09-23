using Expect.Test.Cdek.Domain.Models;
using Expect.Test.Cdek.Domain.Responses;
using Expect.Test.Cdek.Infrastructure.Clients.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Expect.Test.Cdek.Infrastructure.Clients
{
	public class CdekClient : ICdekClient
	{
		private readonly HttpClient _httpClient;

		public CdekClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<CalculatePriceResponse> CalculatePrice(CalculatorDto calculatorDto, CancellationToken cancellationToken)
		{
			var jsonRequest = JsonConvert.SerializeObject(calculatorDto, Formatting.Indented);

			var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("https://api.edu.cdek.ru/v2/calculator/tariff", content, cancellationToken);

			if (response.IsSuccessStatusCode)
			{
				var jsonResponse = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<CalculatePriceResponse>(jsonResponse);

				return result ?? throw new ArgumentNullException("Result was null");
			}

			throw new ArgumentNullException("Response was null");
		}
	}
}
