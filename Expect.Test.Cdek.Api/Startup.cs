using Expect.Test.Cdek.Infrastructure;
using Expect.Test.Cdek.Infrastructure.Clients;
using Expect.Test.Cdek.Infrastructure.Clients.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace Expect.Test.Cdek.Api
{
	/// <summary>
	/// Конфигурация API
	/// </summary>
	public class Startup
	{
		private readonly IConfiguration _configuration;

		/// <summary>
		/// Внедрение конфигурации
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		/// <summary>
		/// Конфигурация пайплайна
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseRouting();
			app.UseAuthorization();


			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		/// <summary>
		/// Регистрация сервисов
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.ContractResolver = new DefaultContractResolver
					{
						NamingStrategy = new CamelCaseNamingStrategy()
					};
					options.SerializerSettings.Formatting = Formatting.Indented;
				});
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddInfrastructure();
			services.AddHttpClient<ICdekClient, CdekClient>(config =>
			{
				config.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["CdekApiKey"]);
			});
		}
	}
}
