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

            //laver en ny json server så vi kan få fat i vores start metode
            JsonServer server = new JsonServer();

            //her bruger vi så vores start metode 
            server.Start();

            Console.ReadLine();

        }
    }
}
