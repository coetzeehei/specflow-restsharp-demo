using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace UserRegisterSpecs
{
    class Headers
    {
        private IList<Parameter> headers;

        public Headers(IList<Parameter> headers)
        {
            this.headers = headers;
        }

        public static Headers FromResponse(IRestResponse response)
        {
            return new Headers(response.Headers);
        }

        public string withName(string headerName)
        {
            Parameter locationHeader =  headers.ToList().Find(header => header.Name.Equals(headerName));

            if (locationHeader == null)
            {
                return "";
            }
            return locationHeader.Value.ToString();
        }
    }
}
