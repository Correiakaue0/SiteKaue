using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace FrgStore.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public RestResponse ExecutaApi(string resource, Method metodo, object obj )
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest(resource, metodo)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(obj);

            return client.Execute(request);
        }
    }
}
