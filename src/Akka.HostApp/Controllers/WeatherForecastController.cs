using Akka.Actor;
using Akka.HostApp.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akka.HostApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public async Task<IEnumerable<WeatherForecast>> Get()
		{
			var actor = AkkaService.GlobalActorSystem.ActorSelection("/user/WeatherForecastActor");
			return await actor.Ask<IEnumerable<WeatherForecast>>(new GetWeatherForecast());
		}
	}
}
