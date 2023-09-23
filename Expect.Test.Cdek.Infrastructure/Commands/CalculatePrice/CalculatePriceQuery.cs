using Expect.Test.Cdek.Domain.Models;
using Expect.Test.Cdek.Domain.Responses;
using MediatR;

namespace Expect.Test.Cdek.Infrastructure.Commands.CalculatePrice
{
	public class CalculatePriceQuery : IRequest<CalculatePriceResponse>
	{
		public CalculatorDto Dto { get; set; }

		public CalculatePriceQuery(CalculatorDto dto)
		{
			Dto = dto;
		}
	}
}
