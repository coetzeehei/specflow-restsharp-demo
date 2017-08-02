using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using UserRegisterSpecs.Domain;

namespace UserRegisterSpecs
{
    public class RegisterUserApi : RestApiClient
    {
        public string Register(User newUser)
        {
            var request = new RestRequest();

            request.Method = Method.POST;
            request.Resource = "user";

            request.AddJsonBody(newUser);

            IRestResponse response = Execute(request);

            return Headers.FromResponse(response).withName("Location");
        }
    }
}

