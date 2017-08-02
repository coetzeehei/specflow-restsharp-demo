using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using UserRegisterSpecs.Domain;

namespace UserRegisterSpecs
{
    public class FindUsersApi : RestApiClient
    {
        public RegisteredUser FindByName(string name)
        {
            var request = new RestRequest();

            request.Method = Method.GET;
            request.Resource = "user";

            request.AddQueryParameter("name", name);

            return Execute<RegisteredUser>(request);
        }

        public List<RegisteredUser> FindAll()
        {
            var request = new RestRequest();

            request.Method = Method.GET;
            request.Resource = "users";

            return Execute<List<RegisteredUser>>(request);
        }


        public RegisteredUser FindById(string id)
        {
            var request = new RestRequest();

            request.Method = Method.GET;
            request.Resource = "user/{id}";

            request.AddUrlSegment("id", id);

            return Execute<RegisteredUser>(request);
        }
    }
}
