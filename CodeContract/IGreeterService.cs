using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace gRpcDemo.CodeContract
{
    [ServiceContract]
    public interface IGreeterService
    {
        [OperationContract]
        Task<HelloReply> SayHelloAsync(HelloRequest request,
            CallContext context = default);
    }
}
