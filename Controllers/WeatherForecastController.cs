using Grpc.Net.Client;
using gRpcDemo.CodeContract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRpcDemo.Controllers
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
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            try
            {

                //1-  Define the Code Contract (Request & Reply)
                //2-  Define the OperationContract - Interface for your service
                //3-  Define the Service Contract for your service. Impliment your interface. 
                //4-  Create a GRPCChannel via ForAddress Method. 
                //5-  Hand over your interface to grpc channel creategrpc service method. It will construct the client. 
                //6-  Call You service method by following your contract classes. 

                //https://docs.microsoft.com/en-us/aspnet/core/grpc/code-first?view=aspnetcore-5.0
                // GRPC Implimentation 
                // It will use the API service contract and call the method. 
                // First it will create the channel. 
                // VIA channel it creates service to grpc service. and then with same client you can call you method. 

                using var channel = GrpcChannel.ForAddress("https://localhost:44340");
                var client = channel.CreateGrpcService<IGreeterService>();

                var reply = await client.SayHelloAsync(
                    new HelloRequest { Name = "GreeterClient" });

                Console.WriteLine($"Greeting: {reply.Message}");


                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
