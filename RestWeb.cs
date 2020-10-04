using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_Tests_by_IrynaShelevii
{
    public class RestWeb
    {
        private string _baseUrl = "https://reqres.in";

        
        public IRestResponse CreateNewUser(string name, string job, string endpoint)
        {
            RestClient restClient = new RestClient(_baseUrl + endpoint);
            RestRequest request = new RestRequest();
            request.AddJsonBody("{\"name\": \"" + name + "\", \"job\":\""+ job +"\"}");
            request.Method = Method.POST;
            var response = restClient.Execute(request);
            return response;
        }


    }
}
