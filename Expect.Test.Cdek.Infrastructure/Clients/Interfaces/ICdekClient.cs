using Expect.Test.Cdek.Domain.Models;
using Expect.Test.Cdek.Domain.Responses;

namespace Expect.Test.Cdek.Infrastructure.Clients.Interfaces
{
	public interface ICdekClient
	{
		public Task<CalculatePriceResponse> CalculatePrice(CalculatorDto calculatorDto, CancellationToken cancellationToken);
	}
}
