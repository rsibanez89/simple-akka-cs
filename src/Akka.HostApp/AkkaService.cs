using Akka.Actor;
using Akka.HostApp.Actors;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Akka.HostApp
{
	public class AkkaService : IHostedService
	{
		public static ActorSystem GlobalActorSystem { get; private set; }

		public Task StartAsync(CancellationToken cancellationToken)
		{
			GlobalActorSystem = ActorSystem.Create("GlobalActorSystem");

			GlobalActorSystem.ActorOf(WeatherForecastActor.Props(), "WeatherForecastActor");

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return CoordinatedShutdown.Get(GlobalActorSystem)
				.Run(CoordinatedShutdown.ClrExitReason.Instance);
		}
	}
}
