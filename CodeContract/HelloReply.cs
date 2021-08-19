using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace gRpcDemo.CodeContract
{
    [DataContract]
    public class HelloReply
    {
        [DataMember(Order = 1)]
        public string Message { set; get; }
    }
}
