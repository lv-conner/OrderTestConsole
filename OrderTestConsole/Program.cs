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
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            //when use this channel will throw connection abort connection exceptioin;
            var channel = GrpcChannel.ForAddress("http://localhost:8888",new GrpcChannelOptions()
            {
                Credentials = ChannelCredentials.Insecure
            });
            //use this channel can work;
            var chanel1 = new Channel("localhost:8888", ChannelCredentials.Insecure);
            var client = new OrderGrpcService.OrderRpcService.OrderRpcServiceClient(channel);
            try
            {
                var res = client.GetOrderList(new OrderListRequest());

            }
            catch(Exception ex)
            {

            }
        }
    }
}
