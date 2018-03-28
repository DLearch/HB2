using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding binding = new NetTcpBinding();
            Type contract = typeof(IContract);
            ServiceHost host = new ServiceHost(typeof(Serv));
            host.AddServiceEndpoint(contract, binding, address);
            host.Open();
            Console.ReadKey();
        }
    }
}
