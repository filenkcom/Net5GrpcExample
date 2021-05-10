using Grpc.Core;
using Grpc.Net.Client;
using System;

namespace Grpc.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloRequest request = new HelloRequest()
            {
                Name = "World",
            };

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            try
            {
                var reply = client.SayHello(request);
                Console.WriteLine(reply.Message);
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
