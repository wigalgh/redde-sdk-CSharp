using System;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.IO;


namespace CSHARP{

    public class Payload
    {
        public int amount { get; set; }
        public int appid { get; set; }
        public string clientreference { get; set; }
        public string clienttransid { get; set; }
        public string description { get; set; }
        public string nickname { get; set; }
        public string paymentoption { get; set; }
        public string walletnumber { get; set; }

    }


   public class Redde{
        private string apiKey;
        private int appID; 

       public Redde(string apiKey, int appID){
            this.apiKey = apiKey;
            this.appID = appID;
        }

    public string randomClientID(int Size){
            string randomno = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghjklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder();
            char ch;
            Random random = new Random();
            for (int i = 0; i < Size; i++)
            {
                ch = randomno[random.Next(0, randomno.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
    }

    public string clientReferenceNumber (int Size){
            string randomno = "1234567890";
            StringBuilder builder = new StringBuilder();
            char ch;
            Random random = new Random();
            for (int i = 0; i < Size; i++)
            {
                ch = randomno[random.Next(0, randomno.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
    }

    public string receiveMoney(int amount, string walletnumber, string clientref, string clientid, string network){
            
            
            Payload redde = new Payload();
            redde.amount = amount;
            redde.appid = this.appID;
            redde.clientreference = clientref;
            redde.clienttransid = clientid;
            redde.nickname = "wigal";
            redde.paymentoption = network;
            redde.walletnumber = walletnumber;


            try
            {
                string receive_url = "https://api.reddeonline.com/v1/receive";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(receive_url);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("ApiKey", this.apiKey);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(redde, Formatting.Indented);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    return responseText.ToString();
                    //Console.WriteLine(responseText);
                }
                

            }catch (WebException ex){
              return  ex.Message;
              //Console.WriteLine(ex.Message + "You have an Error");
            }
        
    }
    public string sendMoney(int amount, string walletnumber, string clientref, string clientid, string network){
            
            Payload redde = new Payload();
            redde.amount = amount;
            redde.appid = this.appID;
            redde.clientreference = clientref;
            redde.clienttransid = clientid;
            redde.nickname = "wigal";
            redde.paymentoption = network;
            redde.walletnumber = walletnumber;


            try
            {
                string cashout_url = "https://api.reddeonline.com/v1/cashout";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(cashout_url);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("ApiKey", this.apiKey);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(redde, Formatting.Indented);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    return responseText.ToString();
                    //Console.WriteLine(responseText);
                }
                

            }catch (WebException ex){
              return  ex.Message;
              //Console.WriteLine(ex.Message + "You have an Error");
            }
        
    }
    
    }
}