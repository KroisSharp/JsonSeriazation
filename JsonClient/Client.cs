using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JsonClient
{
    class Client
    {


        public void Start()
        {

            using (TcpClient client = new TcpClient("localhost", 10001))
            using (NetworkStream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                //her kan vi sende

                #region Opretter Bil
                var bil = new ModelLib.Car();
                bil.Color = "Red";
                bil.Model = "Tesla";
                bil.Registration_number = "AB12345";
                #endregion

                //starter json til vores bil
                string json = JsonConvert.SerializeObject(bil);

                sw.Write(json);
                sw.Flush();
            }
        }

    }
}
