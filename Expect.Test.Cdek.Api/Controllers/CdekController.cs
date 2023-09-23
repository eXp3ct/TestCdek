using Expect.Test.Cdek.Domain.Models;
using Expect.Test.Cdek.Domain.Responses;
using Expect.Test.Cdek.Infrastructure.Commands.CalculatePrice;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Expect.Test.Cdek.Api.Controllers
{
	/// <summary>
	/// Контроллер 
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class CdekController : ControllerBase
	{
		private readonly IMediator _mediator;

		/// <summary>
		/// Внедрение зависимостей
		/// </summary>
		/// <param name="mediator"></param>
		public CdekController(IMediator mediator)
		{
			_mediator = mediator;
		}

		/// <summary>
		/// Расчет цены 
		/// </summary>
		/// <param name="dto">Информация о товаре</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="CalculatePriceResponse"/>Ответ от СДЭК API</returns>
		[HttpPost]
		[Produces("application/json")]
		[ProducesDefaultResponseType(typeof(CalculatePriceResponse))]
		public async Task<IActionResult> CalculatePrice([FromBody] CalculatorDto dto, CancellationToken cancellationToken)
		{
			var query = new CalculatePriceQuery(dto);

			var result = await _mediator.Send(query, cancellationToken);

			return Ok(result);
		}
	}
}
