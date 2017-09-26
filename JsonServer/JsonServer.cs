using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JsonServer
{
    class JsonServer
    {
        public JsonServer()
        {

        }


        public void Start()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 10001);
            tcpListener.Start();


            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Task.Run(() =>
                    {
                        TcpClient socket = client;
                        DoClient(client);
                    }
                );
            }
        }

        private static void DoClient(TcpClient client)
        {
            using (Stream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                string linje = sr.ReadLine();

                Car print = JsonConvert.DeserializeObject<Car>(linje);


                Console.WriteLine(print.Model);
               

            }
        }


        public static String HandleClient(String line)
        {
            Console.WriteLine("server modtaget : " + line);
            return line;
        }


    }
}
