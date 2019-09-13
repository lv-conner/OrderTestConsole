using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OrderGrpcService;
using System;
using System.Threading.Tasks;

namespace ServerSide
{
    public class GrpcOrderService : OrderRpcService.OrderRpcServiceBase
    {
        private static Empty SuccessResponse = new Empty();
        public GrpcOrderService()
        {
        }
        public override Task<Empty> AddOrder(Order request, ServerCallContext context)
        {
            return Task.FromResult(SuccessResponse);
        }
        public override  Task<OrderListReply> GetOrderList(OrderListRequest request, ServerCallContext context)
        {

            var reply = new OrderListReply();
            return Task.FromResult(reply);
        }
    }
}
