using MasterApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

namespace MasterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DeploymentManagerController : Controller
    {
        //static readonly HttpClient ApiCall = new HttpClient();


        [HttpPost]
        [Route("Manager/CreateWebsite")]
        public async Task<HttpStatusCode> CreateWebsite(string server, string name, int port, string ipAddr)
        {
            try
            {
                Website website = new(name, ipAddr, port);
                
                
               return HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;

            }


        }

        


    }

}
