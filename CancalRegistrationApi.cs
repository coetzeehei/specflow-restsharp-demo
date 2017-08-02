using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using UserRegisterSpecs.Domain;

namespace UserRegisterSpecs
{
    public class CancelRegistrationApi : RestApiClient
    {
        public void cancelRegistrationForUserWithId(string id)
        {
            var request = new RestRequest();

            request.Method = Method.DELETE;
            request.Resource = "user/{id}";

            request.AddUrlSegment("id", id);

            Execute<RegisteredUser>(request);
        }
    }
}
