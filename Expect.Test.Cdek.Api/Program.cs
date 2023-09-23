
using Microsoft.AspNetCore;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Expect.Test.Cdek.Api
{
	/// <summary>
	/// Точка входа программы
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Точка входа программы
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			host.Run();
		}

		/// <summary>
		/// Создание хоста с использованием класса Startup и Serilog для логгирования
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseSerilog((contxt, cfg) =>
				{
					cfg
						.MinimumLevel.Debug()
						.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code);
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}