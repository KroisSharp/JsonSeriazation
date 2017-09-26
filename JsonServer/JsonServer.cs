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
        //ctor god at ha med
        public JsonServer()
        {

        }

        //vi laver en start metode så vi kan starte det hele (starte server så den lytter)
        public void Start()
        {
            //vi laver en lytter så den venter på clenter bemærk vi bruger her loopback, 10001 er port
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 10001);
            //her starter vi så vores lytter 
            tcpListener.Start();

            //vi laver en while så den bliver ved med at accpetere tcp clienter 
            //vi laver en task som siger bliv ved med at kør dem og giv dem et socket og gå derefter til "DoClient(med clienten)
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


        //vores Doclient er den som har de forskellige streams bemærk parameter, vi får sendt en client med 
        private static void DoClient(TcpClient client)
        {
            //her er vores streams først get stream så vi kan læse og skrive på den stream
            using (Stream ns = client.GetStream())
            //vores stream reader så vi kan læse fra den stream bemærk vi ønsker at læse fra ns
            using (StreamReader sr = new StreamReader(ns))
                //writer bliver ikke brug da vi kun vil læse fra stream
            using (StreamWriter sw = new StreamWriter(ns))
            {

                //vi siger at når der kommer en linje skal den hedde linje
                string linje = sr.ReadLine();


                //vi ved at vores client sender Json så vi bliver nød til at håndtere den string vi får som json
                //derfor deserializer vi den til det object der nu engang kommer Car - her kunne man lave en masse if til forskellige classes 'cast as'
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
