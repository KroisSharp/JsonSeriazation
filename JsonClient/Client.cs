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

        //vi laver en metode til at starte det hele
        public void Start()
        {
            //vi laver en client og siger det er localhost da vi ikke er på nettet. 10001 er vores port
            using (TcpClient client = new TcpClient("localhost", 10001))

            //vi laver en network stream og på den kalder vi metoden getstream så har vi den kørende og kan læse og skrive den vej
            using (NetworkStream ns = client.GetStream())
            //vi bruger ikke vores læser i dette tilfælde da vi ikke skal læse noget fra serveren men god at ha med
            using (StreamReader sr = new StreamReader(ns))
                //vores StreamWriter kan skrive på vores Stream derfor har vi (ns) som ref -> til networkstream
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
                //vi ved json er en string derfor siger vi string json. og så serializeobject på den vi har lavet altså bil dette bliver til en string nu
                string json = JsonConvert.SerializeObject(bil);


                //da vi ved det er en string kan vi bare sende den af sted som en normal besked
                //men på server skal vi huske at gribe den besked som json og pakke de ud som json så det giver mening.
                sw.Write(json);
                //flush så vi husker at sende alt afsted
                sw.Flush();
            }
        }

    }
}
