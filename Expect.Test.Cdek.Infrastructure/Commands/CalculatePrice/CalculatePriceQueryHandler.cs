using Expect.Test.Cdek.Domain.Responses;
using Expect.Test.Cdek.Infrastructure.Clients.Interfaces;
using MediatR;

namespace Expect.Test.Cdek.Infrastructure.Commands.CalculatePrice
{
	public class CalculatePriceQueryHandler : IRequestHandler<CalculatePriceQuery, CalculatePriceResponse>
	{
		private readonly ICdekClient _client;

		public CalculatePriceQueryHandler(ICdekClient client)
		{
			_client = client;
		}

		public async Task<CalculatePriceResponse> Handle(CalculatePriceQuery request, CancellationToken cancellationToken)
		{
			var response = await _client.CalculatePrice(request.Dto, cancellationToken);

			return response;
		}
	}
}
