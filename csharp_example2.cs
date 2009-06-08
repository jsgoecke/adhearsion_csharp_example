using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSONSharp;
using System.Net;
using System.IO;

namespace adhearsion
{//adhearsion server is http://192.168.1.62:5000
    class Program
    {
        static void Main(string[] args)
        {
            Program.connect();
        }
        static void connect()
        {
            try
            {     
                ahnparams ahn = new ahnparams();
                ahn.src = @"SIP/4031234567@192.168.1.200";
                ahn.dest = @"7801234567";
                //Pass it to our static reflector, which will build
                JSONReflector jsonReflector = new JSONReflector(ahn);   //JSONSharp converts the class to JSON format
                //Console.WriteLine(jsonReflector.ToString());
                NetworkCredential myCred = new NetworkCredential("jicksta", "roflcopterz");

                CredentialCache myCache = new CredentialCache();

                myCache.Add(new Uri("http://192.168.1.62:5000"), "Basic", myCred);


                WebRequest request = WebRequest.Create("http://192.168.1.62:5000/launch_call_rpc");
                request.Credentials = myCache;
                string postData = "["+jsonReflector.ToString()+"]";  //had to add the [] for it to work with restful_rpc just like php json
                Console.WriteLine(postData);
                request.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception e)
                {
                    throw e;
                }

        }
    }
}
