using System;


namespace CSHARP
{
     class Program
    {
        static void Main(string[] args)
        {
            //Enter App ID
            int app_id = 349009;

            //Enter Api Key
            string api_key = "";

            //Create an instance of Redde Package
            Redde red = new Redde(api_key, app_id);

            //Client Reference
            string client_ref = red.clientReferenceNumber(6);

            //Client ID
            string client_id = red.randomClientID(6);

            Console.WriteLine(red.receiveMoney(1, "233200000000", client_ref, client_id, "MTN"));

        }

}

}
