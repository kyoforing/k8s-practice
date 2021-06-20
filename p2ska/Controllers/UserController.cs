using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using p2ska.Extensions;
using p2ska.Models;
using p2ska.Services;

namespace p2ska.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("/")]
        public async Task<IActionResult> RegisterUser()
        {
            return new JsonResult(await new UserService().GetResponse());
        }
        
        [HttpGet("/health/live")]
        public string LivenessProbe()
        {
            return "";
        }

        [HttpGet("/health/ready")]
        public string ReadinessProbe()
        {
            return "";
        }
    }
}
