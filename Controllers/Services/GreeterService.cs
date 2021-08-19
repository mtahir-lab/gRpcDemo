using gRpcDemo.CodeContract;
using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRpcDemo.Controllers.Services
{
    public class GreeterService : IGreeterService
    {
        public Task<HelloReply> SayHelloAsync(HelloRequest request, CallContext context = default)
        {
            return Task.FromResult(
                   new HelloReply
                   {
                       Message = $"Hello {request.Name}"
                   });
        }

    }
}
