using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class Log
    {
        
        public static async Task Post(string actionMessage, string statusCode, string time)
        {
            //Posto nemam url mikro servisa za logovanje zakomentarisao sam deo koda
            /*string myJson = "{'ActionMessage':'"+actionMessage+"','StatusCode':'"+statusCode+"','Time':'"+time+"'}";
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://yourUrl",
                     new StringContent(myJson, Encoding.UTF8, "application/json"));
            }*/
        }
    }
}
