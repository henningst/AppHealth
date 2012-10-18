using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace DucksboardClient
{
    public class Client
    {
        public string Push(string widget, object values)
        {
            var client = new RestClient();

            var request = new RestRequest()
                              {
                                  Resource = string.Format("http://push.ducksboard.com/v/{0}", widget),
                                  RequestFormat = DataFormat.Json,
                                  Method = Method.POST,
                                  Credentials = new NetworkCredential("xxx", "~")
                              };

            request.AddBody(values);

            var response = client.Execute(request);
            return response.Content;
        }

        public double GetUnixTimestamp()
        {
            return (DateTime.UtcNow - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }
        
    }
}
