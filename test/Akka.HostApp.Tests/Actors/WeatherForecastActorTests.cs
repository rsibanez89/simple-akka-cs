using Akka.Actor;
using Akka.HostApp.Actors;
using Akka.HostApp.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Akka.HostApp.Tests.Actors
{
	public class WeatherForecastActorTests : Akka.TestKit.Xunit2.TestKit
	{
		[Fact]
		public async Task WeatherForecastActor_Test_Response()
		{
			var actor = ActorOf<WeatherForecastActor>();
			var response = await actor.Ask<IEnumerable<WeatherForecast>>(new GetWeatherForecast());
			Assert.NotNull(response);
		}
	}
}