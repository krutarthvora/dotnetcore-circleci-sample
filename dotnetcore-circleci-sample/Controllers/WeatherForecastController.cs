using dotnetcore_git_submodule_sample;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnetcore_circleci_sample.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
						"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
				};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			Random oRandom = new Random();
			IEnumerable<WeatherForecast> retu = Enumerable.Range(1, 5)
				.Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = oRandom.Next(-20, 55),
					Summary = JsonHelper.Serialize(Summaries[oRandom.Next(Summaries.Length)])
				})
			.ToArray();
			return retu;
		}
	}
}
