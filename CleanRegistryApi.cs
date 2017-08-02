using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using UserRegisterSpecs.Domain;

namespace UserRegisterSpecs
{
    public class CleanRegistryApi : RestApiClient
    {
        public RegisteredUser deleteAll()
        {
            var request = new RestRequest();

            request.Method = Method.DELETE;
            request.Resource = "users";

            return Execute<RegisteredUser>(request);
        }
    }
}
