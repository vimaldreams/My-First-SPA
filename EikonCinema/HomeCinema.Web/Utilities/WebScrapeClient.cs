using HomeCinema.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Utilities
{
    public class WebScrapeClient : IWebScrapeClient
    {      
        public WebScrapeClient()
        {
        }

        public WebScrapeResponse Get(string url)
        {
            return this.GetResponse(url, "GET");
        }
        private WebScrapeResponse GetResponse(string url, string method)
        {
            try
            {
                var httpRequest = this.GetHttpWebRequest(url, method);
                
                var responseString = string.Empty;

                using (var response = (HttpWebResponse) httpRequest.GetResponse())
                {
                    using (var receiveStream = response.GetResponseStream())
                    {
                        var characterSet = "utf-8";

                        if (!string.IsNullOrEmpty(response.CharacterSet))
                        {
                            characterSet = response.CharacterSet.Replace("\"", "");
                        }

                        var encode = Encoding.GetEncoding(characterSet);

                        using (var reader = new StreamReader(receiveStream, encode))
                        {
                            responseString = reader.ReadToEnd();
                        }
                    }

                    //FileStream fs = File.OpenWrite(@"C:\Users\lavanyavimal\STLGroup.htm");
                    //StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
                    //writer.Write(responseString);
                    //writer.Close(); 
                    
                    return new WebScrapeResponse
                    {
                        Value = responseString,
                    };
                }
            }
            catch (Exception ex)
            {
                throw new ApiException("Exception on Api call -" + url, ex);
            }
        }
        
        private HttpWebRequest GetHttpWebRequest(string url, string method)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;                       

            return request;
        }
    }
}
