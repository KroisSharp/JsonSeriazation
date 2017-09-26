using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //laver en ny client så vi kan lave en start metode
            Client client = new Client();

            //køre hele vores metode med NS SW SR 
            client.Start();


            //så den ikke lukker med det samme.
            Console.ReadLine();



        }
    }
}
