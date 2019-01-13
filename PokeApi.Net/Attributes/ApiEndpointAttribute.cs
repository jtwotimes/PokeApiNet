using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi.Net.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    class ApiEndpointAttribute : Attribute
    {
        public string ApiEndpoint { get; }

        public ApiEndpointAttribute(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }
    }
}
