using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderGrpcService;
using ServerSide;

namespace WorkerService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var server = new Server()
            {

                Services = { OrderRpcService.BindService(new GrpcOrderService()) },
                Ports = { new ServerPort("localhost", 8888, ServerCredentials.Insecure) }
            };
            server.Start();
            Console.ReadLine();
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
