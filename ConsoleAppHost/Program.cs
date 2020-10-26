using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleAppHost
{
    class Program
    {
        static void Main()
        {
            using(ServiceHost host = new ServiceHost(typeof(ClassLibrary.Service1)))
            {
                host.Open();
                Console.WriteLine("Host started @" + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
