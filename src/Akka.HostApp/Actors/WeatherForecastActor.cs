using Akka.Actor;
using Akka.HostApp.Contracts;
using System;
using System.Linq;
using System.Threading;

namespace Akka.HostApp.Actors
{
	public class WeatherForecastActor : ReceiveActor
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public WeatherForecastActor()
		{
			Receive<GetWeatherForecast>(message =>
			{
				var rng = new Random();
				var ret = Enumerable.Range(1, 5).Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = rng.Next(-20, 55),
					Summary = Summaries[rng.Next(Summaries.Length)]
				})
				.ToArray();

				// Long processing task
				Thread.Sleep(1000);

				// Response to the Ask method
				Sender.Tell(ret, Self);
			});
		}

		public static Props Props()
		{
			return Akka.Actor.Props.Create(() => new WeatherForecastActor());
		}
	}
}
