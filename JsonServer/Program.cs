using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonServer
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonServer server = new JsonServer();

            server.Start();

            Console.ReadLine();

        }
    }
}
