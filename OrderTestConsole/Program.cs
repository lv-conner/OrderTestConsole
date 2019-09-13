using System;
using Grpc.Core;
using Grpc.Net.Client;
using OrderGrpcService;

namespace OrderTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("localhost:8888",new GrpcChannelOptions()
            {
                Credentials = ChannelCredentials.Insecure
            });
            var chanel1 = new Channel("localhost:8888", ChannelCredentials.Insecure);
            var client = new OrderGrpcService.OrderRpcService.OrderRpcServiceClient(chanel1);
            try
            {
                var res = client.GetOrderList(new OrderListRequest());

            }
            catch(Exception ex)
            {

            }
            Console.WriteLine("Hello World!");
        }
    }
}
