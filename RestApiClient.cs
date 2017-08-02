using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace UserRegisterSpecs
{
    public class RestApiClient
    {
        private const string APIBaseUrl = "http://amidotestapp.herokuapp.com/api/";

        public HttpStatusCode LastStatusCode { get; set; }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var response = RestClient().Execute<T>(request);
        
            LastStatusCode = response.StatusCode;

            EnsureNoErrorOccured(response);

            return response.Data;
        }

        private static void EnsureNoErrorOccured(IRestResponse response) 
        {
            if (response.ErrorException != null)
            {
                throw new ApplicationException("Error retrieving response.",
                    response.ErrorException);
            }
        }

        private static RestClient RestClient() 
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(APIBaseUrl);
            return client;
        }

        public IRestResponse Execute(RestRequest request)
        {
            IRestResponse response = RestClient().Execute(request);

            LastStatusCode = response.StatusCode;

            EnsureNoErrorOccured(response);

            return response;
        }

    }
}
