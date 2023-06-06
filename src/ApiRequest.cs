using Microsoft.OData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FYS_SDK.src
{
    public class ApiRequest
    {
        public string Endpoint { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public object Body { get; set; }
        public string AccessToken { get; set; }
        public TimeSpan Timeout { get; set; }
        public string ContentType { get; set; }

        public ApiRequest(string endpoint, HttpMethod httpMethod)
        {
            Endpoint = endpoint;
            HttpMethod = httpMethod;
            Headers = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
            Timeout = TimeSpan.FromSeconds(30); // Default timeout value
            ContentType = "application/json"; // Default content type
        }

        public string SerializeBody()
        {
            if (Body != null)
            {
                if (ContentType == "application/json")
                {
                    return JsonConvert.SerializeObject(Body);
                }
                else if (ContentType == "application/xml")
                {
                    var serializer = new XmlSerializer(Body.GetType());
                    using (var writer = new StringWriter())
                    {
                        serializer.Serialize(writer, Body);
                        return writer.ToString();
                    }
                }
                else if (ContentType == "application/odata")
                {

                    var settings = new ODataMessageWriterSettings();
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var writer = new StreamWriter(memoryStream))
                        {
                            var requestMessage = new HttpRequestMessage();
                            requestMessage.Headers.Add("Content-Type", ContentType);
                            var messageWriter = new ODataMessageWriter((IODataRequestMessage)requestMessage, settings);
                            var odataWriter = messageWriter.CreateODataResourceWriter();
                            odataWriter.WriteStart(new ODataResource());
                            // Serialize OData properties and values
                            odataWriter.WriteEnd();
                            odataWriter.Flush();
                            memoryStream.Position = 0;
                            return new StreamReader(memoryStream).ReadToEnd();
                        }
                    }
                }
                // Handle other content types and serialization formats here
            }
            return null;
        }


        public ApiRequest WithDefaultHeaders(Dictionary<string, string> defaultHeaders)
        {
            foreach (var header in defaultHeaders)
            {
                Headers[header.Key] = header.Value;
            }
            return this;
        }

        public ApiRequest WithContentType(string contentType)
        {
            ContentType = contentType;
            return this;
        }
    }



}
